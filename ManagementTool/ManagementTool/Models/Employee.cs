using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementTool.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "A first name is a required field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "A last name is a required field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The date of birth is a required field")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        
        [ForeignKey("Team")]
        [Required(ErrorMessage = "The team the employee works for is a required field")]
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
       
}