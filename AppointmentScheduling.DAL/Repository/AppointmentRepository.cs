using AppointmentScheduling.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduling.DAL.Repository
{
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly AppointmentDbContext appointmentDbContext;

        public AppointmentRepository(AppointmentDbContext appointmentDbContext)
        {
            this.appointmentDbContext = appointmentDbContext;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await appointmentDbContext.Appointment.ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int appointmentId)
        {
            return await appointmentDbContext.Appointment
                .FirstOrDefaultAsync(e => e.AppointmentID == appointmentId);
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            var result = await appointmentDbContext.Appointment.AddAsync(appointment);
            await appointmentDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Appointment> UpdateAppointment(int id,Appointment appointment)
        {
            appointmentDbContext.Entry(appointment).State = EntityState.Modified;
            var result = await appointmentDbContext.Appointment
                .FirstOrDefaultAsync(e => e.AppointmentID == appointment.AppointmentID);

            if (result != null)
            {
                result.PatientID = appointment.PatientID;
                result.PatientName = appointment.PatientName;
                result.PatientPhone = appointment.PatientPhone;
                result.StartDate = appointment.StartDate;
                result.EndDate = appointment.EndDate;
                await appointmentDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteAppointment(int appointmentId)
        {
            var result = await appointmentDbContext.Appointment
                .FirstOrDefaultAsync(e => e.AppointmentID == appointmentId);
            if (result != null)
            {
                appointmentDbContext.Appointment.Remove(result);
                await appointmentDbContext.SaveChangesAsync();
            }
        }
        public bool AppointmentExists(DateTime start, DateTime end)
        {
            return (appointmentDbContext.Appointment?.Any(e => !((e.EndDate <= start) || (e.StartDate >= end)))).GetValueOrDefault();
        }
        public bool AppointmentExists(int id)
        {
            return (appointmentDbContext.Appointment?.Any(e => e.AppointmentID == id)).GetValueOrDefault();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByRange(DateTime start, DateTime end)
        {
            return await appointmentDbContext.Appointment.Where(e => (e.StartDate >= start) && (e.EndDate <= end)).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId)
        {
            return await appointmentDbContext.Appointment.Where(e => (e.PatientID==patientId)).ToListAsync();

        }

    }
}
