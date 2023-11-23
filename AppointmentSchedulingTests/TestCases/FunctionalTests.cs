
using Moq;
using AppointmentScheduling.BAL;
using AppointmentScheduling.DAL.Repository;
using AppointmentScheduling.DAL;
using AppointmentScheduling.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppointmentScheduling.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly AppointmentDbContext _dbContext;

        private readonly IAppointmentService _appointmentService;
        public readonly Mock<IAppointmentRepository> appointmentrepository = new Mock<IAppointmentRepository >();

        private readonly Appointment _appointment;
        private readonly Appointment _appointment1;
        private readonly IEnumerable<Appointment> _appointmentlist;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _appointmentService = new AppointmentService(appointmentrepository.Object);
           
            _output = output;

            _appointment = new Appointment
            {
                AppointmentID = 1,
                PatientID = "5",
                PatientName = "Abc Xyz",
                PatientPhone = "3452765423",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1),
            };
            _appointment1 = new Appointment
            {
                AppointmentID = 2,
                PatientID = "6",
                PatientName = "Abc1 Xyz1",
                PatientPhone = "3452765423",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddHours(1),
            };
            _appointmentlist = new List<Appointment>();
            _appointmentlist = _appointmentlist.Append(_appointment);
            _appointmentlist = _appointmentlist.Append(_appointment1);

        }


        [TestMethod]
        public async Task<bool> Testfor_Add_Appointment()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentrepository.Setup(repos => repos.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        
        [TestMethod]
        public async Task<bool> Testfor_Update_Appointment()
        {
            //Arrange
            int id=0;
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                appointmentrepository.Setup(repos => repos.UpdateAppointment(id, _appointment)).ReturnsAsync(_appointment); 
                var result = await _appointmentService.UpdateAppointment(id, _appointment);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");

            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [TestMethod]
        public async Task<bool> Testfor_GetAppointmentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentrepository.Setup(repos => repos.GetAppointment(id)).ReturnsAsync(_appointment);
                var result = await _appointmentService.GetAppointment(id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [TestMethod]
        public async Task<bool> Testfor_DeleteAppointmentById()
        {
            //Arrange
            var res = false;
            int id = 0;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentrepository.Setup(repos => repos.DeleteAppointment(id));
                _appointmentService.DeleteAppointment(id);
                res=true;
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [TestMethod]
        public async Task<bool> Testfor_GetAppointmentsByRange()
        {
            //Arrange
            bool res = false;
            long id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentrepository.Setup(repo => repo.GetAppointmentsByRange(_appointment.StartDate, _appointment.EndDate)).ReturnsAsync(_appointmentlist);
                var result = await _appointmentService.GetAppointmentsByRange(_appointment.StartDate, _appointment.EndDate);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [TestMethod]
        public async Task<bool> Testfor_GetAppointmentsByPatientId()
        {
            //Arrange
            bool res = false;
            long id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentrepository.Setup(repo => repo.GetAppointmentsByPatientId(_appointment.PatientID)).ReturnsAsync(_appointmentlist);
                var result = await _appointmentService.GetAppointmentsByPatientId(_appointment.PatientID);
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}