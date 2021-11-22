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
    public class TblMasterJobsController : ControllerBase
    {
        private readonly ProjectLoanApplicationContext _context;

        public TblMasterJobsController(ProjectLoanApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TblMasterJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMasterJob>>> GetTblMasterJobs()
        {
            return await _context.TblMasterJobs.ToListAsync();
        }

        // GET: api/TblMasterJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMasterJob>> GetTblMasterJob(int id)
        {
            var tblMasterJob = await _context.TblMasterJobs.FindAsync(id);

            if (tblMasterJob == null)
            {
                return NotFound();
            }

            return tblMasterJob;
        }

        // PUT: api/TblMasterJobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMasterJob(int id, TblMasterJob tblMasterJob)
        {
            if (id != tblMasterJob.JobId)
            {
                return BadRequest();
            }

            _context.Entry(tblMasterJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMasterJobExists(id))
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

        // POST: api/TblMasterJobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMasterJob>> PostTblMasterJob(TblMasterJob tblMasterJob)
        {
            _context.TblMasterJobs.Add(tblMasterJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMasterJob", new { id = tblMasterJob.JobId }, tblMasterJob);
        }

        // DELETE: api/TblMasterJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMasterJob(int id)
        {
            var tblMasterJob = await _context.TblMasterJobs.FindAsync(id);
            if (tblMasterJob == null)
            {
                return NotFound();
            }

            _context.TblMasterJobs.Remove(tblMasterJob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblMasterJobExists(int id)
        {
            return _context.TblMasterJobs.Any(e => e.JobId == id);
        }
    }
}
