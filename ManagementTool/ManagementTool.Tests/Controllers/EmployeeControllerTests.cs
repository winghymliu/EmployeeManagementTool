using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ManagementTool.Controllers;
using ManagementTool.Models;
using ManagementTool.Tests.FakeClasses;
using NUnit.Framework;
using Rhino.Mocks;

namespace ManagementTool.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        private CompanyDBContext _companyDbContextStub;
        private EmployeeController _employeeController;

        [SetUp]
        public void SetUp()
        {
            _companyDbContextStub = MockRepository.GenerateMock<CompanyDBContext>();
            _employeeController = new EmployeeController(_companyDbContextStub);
        }

        [Test]
        public void CannotCreateEmployeeWithoutTeam()
        {
            _companyDbContextStub.Teams = null;
            var newEmployee = new Employee {DateOfBirth = DateTime.Now, TeamID = 1, FirstName = "Foo", LastName = "Bar"};
            var result = _employeeController.Create(newEmployee) as ViewResult;
            Assert.NotNull(result);
            Assert.AreEqual(result.ViewName, "Index");
        }

        [Test]
        public void CreateEmployeeWithTeam()
        {
            _companyDbContextStub.Teams = new FakeDbSet<Team> { new Team{ TeamID = 1, CreationTime = DateTime.Now, Name = "AlphaTeam"}};
            var newEmployee = new Employee { EmployeeID = 1,DateOfBirth = DateTime.Now, TeamID = 1, FirstName = "Foo", LastName = "Bar" };
            var result = _employeeController.Create(newEmployee) as RedirectToRouteResult;
            Assert.NotNull(result);
            Assert.AreEqual(_companyDbContextStub.Employees.Find(1), newEmployee);
        }

        [TearDown]
        public void TearDown()
        {
            _companyDbContextStub = null;
            _employeeController = null;
        }
    }
}
