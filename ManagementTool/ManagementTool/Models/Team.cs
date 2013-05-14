using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementTool.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }
        [Required(ErrorMessage="A team name is a required field")]
        public string Name { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
    }
      
}