using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementTool.Models
{
    public class CompanyDBContext :DbContext
    {
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Employee> Employees { get; set; }
    }
}