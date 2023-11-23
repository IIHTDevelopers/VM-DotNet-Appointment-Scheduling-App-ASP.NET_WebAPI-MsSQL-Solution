using System;
using AppointmentScheduling.DAL;
using AppointmentScheduling.DAL.Repository;
using AppointmentScheduling.Entities;
namespace AppointmentScheduling.BAL
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await repository.GetAppointments();
        }

        public async Task<Appointment> GetAppointment(int appointmentId)
        {
            return await repository.GetAppointment(appointmentId);
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            var appointmentObj = await repository.AddAppointment(appointment);
            return appointmentObj;
        }

        public async Task<Appointment> UpdateAppointment(int id, Appointment appointment)
        {
            return await repository.UpdateAppointment(id,appointment);
        }

        public async void DeleteAppointment(int appointmentId)
        {
            repository.DeleteAppointment(appointmentId);

        }
        public bool AppointmentExists(DateTime start, DateTime end)
        {
            return repository.AppointmentExists(start, end);
        }

        public bool AppointmentExists(int id)
        {
            return repository.AppointmentExists(id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByRange(DateTime start, DateTime end)
        {
            return await repository.GetAppointmentsByRange(start,end);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId)
        {
            return await repository.GetAppointmentsByPatientId(patientId);
        }
        
    }
}