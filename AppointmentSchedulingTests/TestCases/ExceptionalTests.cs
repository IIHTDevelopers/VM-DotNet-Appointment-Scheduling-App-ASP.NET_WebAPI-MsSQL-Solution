

using Moq;
using AppointmentScheduling.BAL;
using AppointmentScheduling.DAL.Repository;
using AppointmentScheduling.DAL;
using AppointmentScheduling.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppointmentScheduling.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly AppointmentDbContext _dbContext;

        private readonly IAppointmentService _appointmentService;
        public readonly Mock<IAppointmentRepository> appointmentservice = new Mock<IAppointmentRepository>();

        private readonly Appointment _appointment;
        private readonly Appointment _appointment1;
        private readonly IEnumerable<Appointment> _appointmentlist;


        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _appointmentService = new AppointmentService(appointmentservice.Object);

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
            _appointmentlist=_appointmentlist.Append(_appointment);
            _appointmentlist=_appointmentlist.Append(_appointment1);

        }


        [TestMethod]
        public async Task<bool> Testfor_Validate_ifInvalidPatientIDIsPassed()
        {
            //Arrange
            bool res = false;
            _appointment.PatientID = "0";
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                if (result != null || result.PatientID != "0")
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
        public async Task<bool> Testfor_Validate_ifInvalidGetAppointmentIdIsPassed()
        {
            //Arrange
            bool res = false;
            int id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.GetAppointment(id)).ReturnsAsync(_appointment);
                var result = await _appointmentService.GetAppointment(id);
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
        public async Task<bool> Testfor_Validate_ifInvalidUpdateAppointmentIdIsPassed()
        {
            //Arrange
            bool res = false;
            int id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.UpdateAppointment(id, _appointment)).ReturnsAsync(_appointment);
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
        public async Task<bool> Testfor_Validate_ifInvalidStartDateEndDateIsPassed()
        {
            //Arrange
            bool res = false;
            long id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.GetAppointmentsByRange(_appointment.StartDate, _appointment.EndDate)).ReturnsAsync(_appointmentlist);
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
        public async Task<bool> Testfor_Validate_ifInvalidPatientIdIsPassed()
        {
            //Arrange
            bool res = false;
            long id = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.GetAppointmentsByPatientId(_appointment.PatientID)).ReturnsAsync(_appointmentlist);
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