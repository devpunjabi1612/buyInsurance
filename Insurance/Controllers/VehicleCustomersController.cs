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
    public class VehicleCustomersController : ControllerBase
    {
        private readonly GeneralInsuranceContext _context;

        public VehicleCustomersController(GeneralInsuranceContext context)
        {
            _context = context;
        }

        // GET: api/VehicleCustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleCustomer>>> GetVehicleCustomers()
        {
            return await _context.VehicleCustomers.ToListAsync();
        }

        // GET: api/VehicleCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleCustomer>> GetVehicleCustomer(int id)
        {
            var vehicleCustomer = await _context.VehicleCustomers.FindAsync(id);

            if (vehicleCustomer == null)
            {
                return NotFound();
            }

            return vehicleCustomer;
        }

        // PUT: api/VehicleCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleCustomer(int id, VehicleCustomer vehicleCustomer)
        {
            if (id != vehicleCustomer.VCid)
            {
                return BadRequest();
            }

            _context.Entry(vehicleCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleCustomerExists(id))
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

        // POST: api/VehicleCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleCustomer>> PostVehicleCustomer(VehicleCustomer vehicleCustomer)
        {
            _context.VehicleCustomers.Add(vehicleCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleCustomer", new { id = vehicleCustomer.VCid }, vehicleCustomer);
        }

        // DELETE: api/VehicleCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleCustomer(int id)
        {
            var vehicleCustomer = await _context.VehicleCustomers.FindAsync(id);
            if (vehicleCustomer == null)
            {
                return NotFound();
            }

            _context.VehicleCustomers.Remove(vehicleCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleCustomerExists(int id)
        {
            return _context.VehicleCustomers.Any(e => e.VCid == id);
        }
    }
}
