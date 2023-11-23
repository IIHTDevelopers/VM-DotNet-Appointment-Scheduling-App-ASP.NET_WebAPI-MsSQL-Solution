using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentScheduling.DAL;
using AppointmentScheduling.Entities;
using AppointmentScheduling.BAL;
using System.Collections;
using System.Globalization;
using NuGet.Protocol.Core.Types;
using Microsoft.VisualBasic;

namespace AppointmentScheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentDbContext _context;
        public readonly IAppointmentService _appointmentService;

        public AppointmentsController(AppointmentDbContext context, IAppointmentService appointmentService)
        {
            _context = context;
            _appointmentService = appointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _appointmentService.GetAppointments();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointment(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return appointment;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (!AppointmentExists(id))
            {
                return NotFound();
            }
            else
            {
                await _appointmentService.UpdateAppointment(id, appointment);
                return NoContent();
            }

        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {

            if (AppointmentExists(appointment.StartDate, appointment.EndDate))
            {
                return Problem("This appointment slot is booked. Please choose another slot");
            }
            else
            {
                await _appointmentService.AddAppointment(appointment);
                return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentID }, appointment);
            }
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            _appointmentService.DeleteAppointment(id);           
            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _appointmentService.AppointmentExists(id);
        }
        private bool AppointmentExists(DateTime start, DateTime end)
        {
            return _appointmentService.AppointmentExists(start, end);
        }

        [HttpGet()]
        public async Task<IEnumerable<Appointment>> GetAppointments([FromQuery(Name = "start")] DateTime start, [FromQuery(Name = "end")] DateTime end)
        {
            return await _appointmentService.GetAppointmentsByRange(start, end);
        }

        [HttpGet("getbypatient")]
        public async Task<IEnumerable<Appointment>> GetAppointments([FromQuery(Name = "patientid")] string patientid)
        {
            return await _appointmentService.GetAppointmentsByPatientId(patientid);
        }

    }
}
