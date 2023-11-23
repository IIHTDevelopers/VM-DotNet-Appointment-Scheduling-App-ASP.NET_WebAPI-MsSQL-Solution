using AppointmentScheduling.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentScheduling.DAL.Repository
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointment(int id);
        Task<Appointment> AddAppointment(Appointment entity);
        Task<Appointment> UpdateAppointment(int id, Appointment entity);
        void DeleteAppointment(int id);
        bool AppointmentExists(DateTime start, DateTime end);
        bool AppointmentExists(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByRange(DateTime start, DateTime end);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId);

    }


}
