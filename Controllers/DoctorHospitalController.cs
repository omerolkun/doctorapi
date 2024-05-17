using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalApi.Models;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorHospitalController : ControllerBase
    {
        private readonly HospitalContext _context;

        public DoctorHospitalController(HospitalContext context)
        {
            _context = context;
        }

        // GET: api/DoctorHospital
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorHospital>>> GetDoctorHospitals()
        {
            return await _context.DoctorHospitals.ToListAsync();
        }

        // GET: api/DoctorHospital/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorHospital>> GetDoctorHospital(int id)
        {
            var doctorHospital = await _context.DoctorHospitals.FindAsync(id);

            if (doctorHospital == null)
            {
                return NotFound();
            }

            return doctorHospital;
        }
        // GET: api/DoctorHospital/junction
        [HttpGet("junction")]
        public async Task<ActionResult<IEnumerable<JuncDTO>>> GetJunc()
        {
            var itemList = await (from dh in _context.DoctorHospitals
                                    join d in _context.Doctors on dh.DoctorId equals d.Id
                                    join h in _context.Hospitals on dh.HospitalId equals h.Id 
                                    select new JuncDTO
                                    {
                                        DoctorName = d.Name,
                                        HospitalName = h.Name,
                                        DoctorId = d.Id,
                                        DoctorTCKN = d.TCKN,
                                        HospitalId = h.Id
                                    }
                                    ).ToListAsync();
            return itemList;
        }


        // PUT: api/DoctorHospital/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorHospital(int id, DoctorHospital doctorHospital)
        {
            if (id != doctorHospital.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctorHospital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorHospitalExists(id))
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

        // POST: api/DoctorHospital
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorHospital>> PostDoctorHospital(DoctorHospital doctorHospital)
        {

            var doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.TCKN == doctorHospital.DoctorId);
            doctorHospital.DoctorId = doctor.Id;

            _context.DoctorHospitals.Add(doctorHospital);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorHospital", new { id = doctorHospital.Id }, doctorHospital);
        }

        // DELETE: api/DoctorHospital/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorHospital(int id)
        {
            var doctorHospital = await _context.DoctorHospitals.FindAsync(id);
            if (doctorHospital == null)
            {
                return NotFound();
            }

            _context.DoctorHospitals.Remove(doctorHospital);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorHospitalExists(int id)
        {
            return _context.DoctorHospitals.Any(e => e.Id == id);
        }
    }
}
