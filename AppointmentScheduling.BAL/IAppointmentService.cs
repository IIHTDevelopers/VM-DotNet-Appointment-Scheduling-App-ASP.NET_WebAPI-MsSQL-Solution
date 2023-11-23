using AppointmentScheduling.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduling.BAL
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<Appointment>> GetAppointments();

        public Task<Appointment> GetAppointment(int appointmentId);

        public  Task<Appointment> AddAppointment(Appointment appointment);

        public Task<Appointment> UpdateAppointment(int id, Appointment appointment);

        public void DeleteAppointment(int appointmentId);
        public bool AppointmentExists(DateTime start, DateTime end);
        public bool AppointmentExists(int id);
        public Task<IEnumerable<Appointment>> GetAppointmentsByRange(DateTime start, DateTime end);
        public Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId);

    }
}
