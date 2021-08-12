using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insurance.Insurance;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelInsurancesController : ControllerBase
    {
        private readonly GeneralInsuranceContext _context;

        public TravelInsurancesController(GeneralInsuranceContext context)
        {
            _context = context;
        }

        // GET: api/TravelInsurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelInsurance>>> GetTravelInsurances()
        {
            return await _context.TravelInsurances.ToListAsync();
        }

        // GET: api/TravelInsurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelInsurance>> GetTravelInsurance(string id)
        {
            var travelInsurance = await _context.TravelInsurances.FindAsync(id);

            if (travelInsurance == null)
            {
                return NotFound();
            }

            return travelInsurance;
        }

        // PUT: api/TravelInsurances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelInsurance(string id, TravelInsurance travelInsurance)
        {
            if (id != travelInsurance.TravelPolicyNumber)
            {
                return BadRequest();
            }

            _context.Entry(travelInsurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelInsuranceExists(id))
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

        // POST: api/TravelInsurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelInsurance>> PostTravelInsurance(TravelInsurance travelInsurance)
        {
            _context.TravelInsurances.Add(travelInsurance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TravelInsuranceExists(travelInsurance.TravelPolicyNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTravelInsurance", new { id = travelInsurance.TravelPolicyNumber }, travelInsurance);
        }

        // DELETE: api/TravelInsurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelInsurance(string id)
        {
            var travelInsurance = await _context.TravelInsurances.FindAsync(id);
            if (travelInsurance == null)
            {
                return NotFound();
            }

            _context.TravelInsurances.Remove(travelInsurance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelInsuranceExists(string id)
        {
            return _context.TravelInsurances.Any(e => e.TravelPolicyNumber == id);
        }
    }
}
