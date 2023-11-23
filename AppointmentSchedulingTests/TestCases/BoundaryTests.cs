
using Moq;
using AppointmentScheduling.BAL;
using AppointmentScheduling.DAL.Repository;
using AppointmentScheduling.DAL;
using AppointmentScheduling.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AppointmentScheduling.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly AppointmentDbContext _dbContext;

        private readonly IAppointmentService _appointmentService;
        public readonly Mock<IAppointmentRepository> appointmentRepository = new Mock<IAppointmentRepository>();

        private readonly Appointment _appointment;
        //private readonly AppointmentViewModel _appointmentViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _appointmentService = new AppointmentService(appointmentRepository.Object);

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

        }

        [Fact]
        public async void Testfor_Patient_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentRepository.Setup(repo => repo.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                var actualLength = _appointment.PatientName.ToString().Length;
                if (result.PatientName.ToString().Length == actualLength)
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
        }


        [Fact]
        public async void Testfor_Patient_ID_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentRepository.Setup(repo => repo.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                var actualLength = _appointment.PatientID.ToString().Length;
                if (result.PatientID.ToString().Length == actualLength)
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
        }

        [Fact]
        public async void Testfor_Patient_Phone_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentRepository.Setup(repo => repo.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                var actualLength = _appointment.PatientPhone.ToString().Length;
                if (result.PatientPhone.ToString().Length == actualLength)
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
        }

        [Fact]
        public async void Testfor_StartDate_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentRepository.Setup(repo => repo.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                var actualLength = _appointment.StartDate.ToString().Length;
                if (result.StartDate.ToString().Length == actualLength)
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
        }

        [Fact]
        public async void Testfor_EndDate_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentRepository.Setup(repo => repo.AddAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.AddAppointment(_appointment);
                var actualLength = _appointment.EndDate.ToString().Length;
                if (result.StartDate.ToString().Length == actualLength)
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
        }

    }
}