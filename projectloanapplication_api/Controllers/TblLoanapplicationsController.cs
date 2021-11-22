using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectloanapplication_api.Models;

namespace projectloanapplication_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblLoanapplicationsController : ControllerBase
    {
        private readonly ProjectLoanApplicationContext _context;

        public TblLoanapplicationsController(ProjectLoanApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TblLoanapplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLoanapplication>>> GetTblLoanapplications()
        {
            return await _context.TblLoanapplications.ToListAsync();
        }

        // GET: api/TblLoanapplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLoanapplication>> GetTblLoanapplication(string id)
        {
            var tblLoanapplication = await _context.TblLoanapplications.FindAsync(id);

            if (tblLoanapplication == null)
            {
                return NotFound();
            }

            return tblLoanapplication;
        }

        // PUT: api/TblLoanapplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLoanapplication(string id, TblLoanapplication tblLoanapplication)
        {
            if (id != tblLoanapplication.LoanApplicationNumber)
            {
                return BadRequest();
            }

            _context.Entry(tblLoanapplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLoanapplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblLoanapplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLoanapplication>> PostTblLoanapplication(TblLoanapplication tblLoanapplication)
        {
            int num = _context.TblLoanapplications.Count() + 1;
            string id = string.Format("LN{0}{1}{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), num.ToString().PadLeft(3, '0'));
            
            tblLoanapplication.LoanApplicationNumber = id;
            tblLoanapplication.CreatedDate = DateTime.Now.Date;
            tblLoanapplication.RecordStatus = true;

            _context.TblLoanapplications.Add(tblLoanapplication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblLoanapplicationExists(tblLoanapplication.LoanApplicationNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblLoanapplication", new { id = tblLoanapplication.LoanApplicationNumber }, tblLoanapplication);
        }

        // DELETE: api/TblLoanapplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLoanapplication(string id)
        {
            var tblLoanapplication = await _context.TblLoanapplications.FindAsync(id);
            if (tblLoanapplication == null)
            {
                return NotFound();
            }

            _context.TblLoanapplications.Remove(tblLoanapplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLoanapplicationExists(string id)
        {
            return _context.TblLoanapplications.Any(e => e.LoanApplicationNumber == id);
        }
    }
}
