using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceManagementApp.Models
{
    public class EmployeeCreateModel
    {

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
