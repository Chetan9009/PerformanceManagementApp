using Microsoft.AspNetCore.Mvc;
using MidLayer;
using PerformanceManagementApp.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PerformanceManagementApp.Controllers
{
    public class GoalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GoalCreateModel goal)
        {

            GoalRequest requestCreateGoal = new GoalRequest();
            requestCreateGoal.CreatedBy = goal.CreatedBy;
            requestCreateGoal.Title = goal.Title;
            requestCreateGoal.StartDate = goal.StartDate;
            requestCreateGoal.EndDate = goal.EndDate;
            requestCreateGoal.Score = goal.Score;

            GoalService createGoal = new GoalService();
                
           _= createGoal.Create(requestCreateGoal);
                     
            return View(goal);
        }
    }
}
