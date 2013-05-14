using System;
using ManagementTool.Models;
using ManagementTool.Tests.FakeClasses;

namespace ManagementTool.Tests.Shared
{
    public class MockMethods
    {
        public static FakeDbSet<Team> GenerateDummyTeams(int n)
        {
            var dummyTeams = new FakeDbSet<Team>();
            for (var i = 1; i < n; i++)
            {
                var tmp = new Team { CreationTime = DateTime.Now, Name = "Team" + n, TeamID = n };
                dummyTeams.Add(tmp);
            }
            return dummyTeams;
        }

        public static FakeDbSet<Employee> GenerateDummyEmployees(int n, int t)
        {
            var dummyTeams = new FakeDbSet<Employee>();
            for (var i = 0; i < n; i++)
            {
                var tmp = new Employee { EmployeeID = n, FirstName = "Employee" + n, LastName = "Smith", TeamID = t, DateOfBirth = DateTime.Now };
                dummyTeams.Add(tmp);
            }

            return dummyTeams;
        }
    }
}
