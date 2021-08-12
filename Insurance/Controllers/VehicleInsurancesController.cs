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
    public class VehicleInsurancesController : ControllerBase
    {
        private readonly GeneralInsuranceContext _context;

        public VehicleInsurancesController(GeneralInsuranceContext context)
        {
            _context = context;
        }

        // GET: api/VehicleInsurances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleInsurance>>> GetVehicleInsurances()
        {
            return await _context.VehicleInsurances.ToListAsync();
        }

        // GET: api/VehicleInsurances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleInsurance>> GetVehicleInsurance(string id)
        {
            var vehicleInsurance = await _context.VehicleInsurances.FindAsync(id);

            if (vehicleInsurance == null)
            {
                return NotFound();
            }

            return vehicleInsurance;
        }

        // PUT: api/VehicleInsurances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleInsurance(string id, VehicleInsurance vehicleInsurance)
        {
            if (id != vehicleInsurance.VehiclePolicyNumber)
            {
                return BadRequest();
            }

            _context.Entry(vehicleInsurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleInsuranceExists(id))
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

        // POST: api/VehicleInsurances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleInsurance>> PostVehicleInsurance(VehicleInsurance vehicleInsurance)
        {
            _context.VehicleInsurances.Add(vehicleInsurance);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VehicleInsuranceExists(vehicleInsurance.VehiclePolicyNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVehicleInsurance", new { id = vehicleInsurance.VehiclePolicyNumber }, vehicleInsurance);
        }

        // DELETE: api/VehicleInsurances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleInsurance(string id)
        {
            var vehicleInsurance = await _context.VehicleInsurances.FindAsync(id);
            if (vehicleInsurance == null)
            {
                return NotFound();
            }

            _context.VehicleInsurances.Remove(vehicleInsurance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleInsuranceExists(string id)
        {
            return _context.VehicleInsurances.Any(e => e.VehiclePolicyNumber == id);
        }
    }
}
