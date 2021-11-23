using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using projectloanapplication.Helper;
using projectloanapplication.Models;

namespace projectloanapplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        LoanApplicationAPI _api = new LoanApplicationAPI();


        public IActionResult Home()
        {
            return View();
        }

        //List 
        public async Task<IActionResult> LoanReport()
        {
            List<TblLoanapplication> loandata = new List<TblLoanapplication>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync("api/TblLoanapplications");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                loandata = JsonConvert.DeserializeObject<List<TblLoanapplication>>(res);
            }


            return View(loandata);
        }
        //Create New
        public async Task<IActionResult> ApplicationForm()
        {
            List<TblMasterJob> jobdata = new List<TblMasterJob>();
            List<TblMasterLoantype> loantypedata = new List<TblMasterLoantype>();
            HttpClient cli = _api.Initial();
            HttpResponseMessage jobresult = await cli.GetAsync("api/TblMasterJobs");
            HttpResponseMessage loanresult = await cli.GetAsync("api/TblMasterLoantypes");
            if (jobresult.IsSuccessStatusCode)
            {
                var job = jobresult.Content.ReadAsStringAsync().Result;
                jobdata = JsonConvert.DeserializeObject<List<TblMasterJob>>(job);
                ViewBag.JobType = new SelectList(jobdata, "JobName", "JobName");
            }
            if(loanresult.IsSuccessStatusCode)
            {
                var loan = loanresult.Content.ReadAsStringAsync().Result;
                loantypedata = JsonConvert.DeserializeObject<List<TblMasterLoantype>>(loan);
                ViewBag.LoanType = new SelectList(loantypedata, "LoanName", "LoanName");
            }
            return View();

        }

        [HttpPost]
        public IActionResult ApplicationForm(TblLoanapplication loanapplication)
        {

            HttpClient cli = _api.Initial();
            string loandata = JsonConvert.SerializeObject(loanapplication);
            StringContent content = new StringContent(loandata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = cli.PostAsync(cli.BaseAddress + "api/TblLoanapplications", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Name"] = loanapplication.FullName;
                return RedirectToAction("Confirmation");

            }


            return View();

        }

        public async Task<IActionResult> ApplicationDetail(string id)
        {
            var loanapp = new TblLoanapplication();
            HttpClient cli = _api.Initial();
            HttpResponseMessage result = await cli.GetAsync($"api/TblLoanapplications/{id}");
            if (result.IsSuccessStatusCode)
            {
                var res = result.Content.ReadAsStringAsync().Result;
                loanapp = JsonConvert.DeserializeObject<TblLoanapplication>(res);
            }
            return View(loanapp);
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
