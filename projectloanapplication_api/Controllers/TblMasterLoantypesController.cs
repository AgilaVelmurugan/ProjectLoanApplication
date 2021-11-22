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
    public class TblMasterLoantypesController : ControllerBase
    {
        private readonly ProjectLoanApplicationContext _context;

        public TblMasterLoantypesController(ProjectLoanApplicationContext context)
        {
            _context = context;
        }

        // GET: api/TblMasterLoantypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMasterLoantype>>> GetTblMasterLoantypes()
        {
            return await _context.TblMasterLoantypes.ToListAsync();
        }

        // GET: api/TblMasterLoantypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblMasterLoantype>> GetTblMasterLoantype(int id)
        {
            var tblMasterLoantype = await _context.TblMasterLoantypes.FindAsync(id);

            if (tblMasterLoantype == null)
            {
                return NotFound();
            }

            return tblMasterLoantype;
        }

        // PUT: api/TblMasterLoantypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMasterLoantype(int id, TblMasterLoantype tblMasterLoantype)
        {
            if (id != tblMasterLoantype.LoanTypeId)
            {
                return BadRequest();
            }

            _context.Entry(tblMasterLoantype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMasterLoantypeExists(id))
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

        // POST: api/TblMasterLoantypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMasterLoantype>> PostTblMasterLoantype(TblMasterLoantype tblMasterLoantype)
        {
            _context.TblMasterLoantypes.Add(tblMasterLoantype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblMasterLoantype", new { id = tblMasterLoantype.LoanTypeId }, tblMasterLoantype);
        }

        // DELETE: api/TblMasterLoantypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMasterLoantype(int id)
        {
            var tblMasterLoantype = await _context.TblMasterLoantypes.FindAsync(id);
            if (tblMasterLoantype == null)
            {
                return NotFound();
            }

            _context.TblMasterLoantypes.Remove(tblMasterLoantype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblMasterLoantypeExists(int id)
        {
            return _context.TblMasterLoantypes.Any(e => e.LoanTypeId == id);
        }
    }
}
