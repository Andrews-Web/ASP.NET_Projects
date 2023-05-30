using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacilitatorSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter all fields!")]
        public string EmployeeName { get; set; }


        
        
        [Required(ErrorMessage = "Please enter all fields!")]
        public string Password { get; set; }

    }
}