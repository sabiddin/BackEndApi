using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using BackEndApi.Domain.Interfaces;
using BackEndApi.Domain.Models;
using System.Linq;

namespace BackEndApi.Tests
{
    public class PatientRepositoryFacts
    {
        [Fact]
        public void GetAll_ShouldRetunPatients() {
            //Arrange
            var patientRepository = new Mock<IPatientRepository>();
            var patients = new List<Patient>() {
                new Patient { Id = 0, FirstName = "Syed", LastName ="Abiddin"},
                new Patient { Id = 0, FirstName = "Farah", LastName ="Sultana"},
                new Patient { Id = 0, FirstName = "Shareef", LastName ="Syed"},
            };
            //Act 
            patientRepository.Setup(m => m.GetAll()).Returns(patients.AsQueryable());
            //Assert
            var expected = 3;
            var actual = patientRepository.Object.GetAll().Count();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Create_ShouldBeAbleToSave() {
            //Arrange
            var patient = new Patient {Id=0, FirstName = "Fatima", MiddleName ="Zoha", LastName="Syed" };
            var existingPatients = new List<Patient>() {
                new Patient { Id = 0, FirstName = "Syed", LastName ="Abiddin"},
                new Patient { Id = 0, FirstName = "Farah", LastName ="Sultana"},
                new Patient { Id = 0, FirstName = "Shareef", LastName ="Syed"},
            };
            var updatePatients = new List<Patient>() {
                new Patient { Id = 0, FirstName = "Syed", LastName ="Abiddin"},
                new Patient { Id = 0, FirstName = "Farah", LastName ="Sultana"},
                new Patient { Id = 0, FirstName = "Shareef", LastName ="Syed"},
                new Patient {Id = 0, FirstName = "Fatima", MiddleName = "Zoha", LastName = "Syed" }
        };
            var patientRepository = new Mock<IPatientRepository>();
            //Act
            patientRepository.Setup(x => x.GetAll()).Returns(existingPatients.AsQueryable());
            var previousList = patientRepository.Object.GetAll().Count();
            patientRepository.Setup(x => x.Create(patient)).Verifiable();
            var updatedList = patientRepository.Setup(x => x.GetAll()).Returns(updatePatients.AsQueryable());
            //Assert
            var expected = patientRepository.Object.GetAll().Count();
            var actual = previousList + 1;
            Assert.Equal(expected, actual);
        }       
    }
}
