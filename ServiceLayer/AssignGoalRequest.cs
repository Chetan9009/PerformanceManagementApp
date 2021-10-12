using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
   public class AssignGoalRequest
    {
        public int AssignBy { get; set; }
        public int[] Goals { get; set; }
    }
}
