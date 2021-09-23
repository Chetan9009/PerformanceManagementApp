using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceManagementApp.Models
{
    public class GoalUpdateModel
    {
        public int Id { get; set; }


        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; }

        public string Title { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Score")]
        public string Score { get; set; }
    }
}
