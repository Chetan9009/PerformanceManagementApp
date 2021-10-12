using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceManagementApp.Models
{
    public class AssignGoalModel
    {
        public int AssignBy { get; set; }
        public int[] Goals { get; set; }
        //public bool isSelected { get; set; }
        //public List<GoalResponseModel> GoalList { get; set; }
    }
}
