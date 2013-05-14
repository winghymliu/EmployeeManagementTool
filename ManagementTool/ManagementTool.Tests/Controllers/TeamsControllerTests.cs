using System;
using ManagementTool.Controllers;
using System.Web.Mvc;
using ManagementTool.Tests.Shared;
using NUnit.Framework;
using Rhino.Mocks;
using ManagementTool.Models;
using ManagementTool.Tests.FakeClasses;

namespace ManagementTool.Tests.Controllers
{
    [TestFixture]
    public class TeamsControllerTests
    {
        private CompanyDBContext _companyDbContextStub;
        private TeamsController _teamsController;

        [SetUp]
        public void SetUp()
        {
            _companyDbContextStub = MockRepository.GenerateMock<CompanyDBContext>();
            _teamsController = new TeamsController(_companyDbContextStub);
        }

        [TearDown]
        public void TearDown()
        {
            _companyDbContextStub = null;
            _teamsController = null;
        }

        [Test]
        public void NotExistingTeamDeleteFixture()
        {
            _companyDbContextStub.Teams = MockMethods.GenerateDummyTeams(2);
            _companyDbContextStub.Employees = MockMethods.GenerateDummyEmployees(1, 2);
            
            var result = _teamsController.Delete(int.MaxValue) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, "TeamNotFound");
        }

        [Test]
        public void TeamDeleteComfirmedFixture()
        {
            _companyDbContextStub.Teams = MockMethods.GenerateDummyTeams(2);
            _companyDbContextStub.Employees = MockMethods.GenerateDummyEmployees(1, 2);
            
            var result = _teamsController.DeleteConfirmed(1) as RedirectToRouteResult;
            Assert.IsNotNull(result);            
            
        }

        [Test]
        public void CannotDeleteTeamWithEmployeesFixture()
        {
            _companyDbContextStub.Teams = MockMethods.GenerateDummyTeams(1);
            _companyDbContextStub.Employees = MockMethods.GenerateDummyEmployees(1, 1);
            
            var result = _teamsController.DeleteConfirmed(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewName, "DeleteFail");            

        }

        [Test]
        public void CreateTeamFixture()
        {                                
            _companyDbContextStub.Teams = new FakeDbSet<Team>();
            var newTeam = new Team {CreationTime = DateTime.Now, Name = "AlphaTeam", TeamID = 1};
            var result = _teamsController.Create(newTeam) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(_companyDbContextStub.Teams.Find(1), newTeam);

        }

        
    }
}
