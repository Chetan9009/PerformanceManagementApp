using Microsoft.AspNetCore.Mvc;
using PerformanceManagementApp.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceManagementApp.Controllers
{
    public class GoalMapperController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
       
            public async Task<IActionResult> Create()
        {
            var ctrl = new GoalController();
            ctrl.ControllerContext = ControllerContext;
            ViewBag.Emp = await ctrl.DDlEmployee();


            var goals =await GetGoals();
            Goal g = new Goal();
            g.listGoal = goals;

            //ViewBag.Emp = await goal.DDlEmployee();

            return View(g);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int AssignTo,int AssignBy, GoallistModel request)
        {
            int[] Goals = new int[request.listGoal.Count];
            int i = 0;
            foreach (var item in request.listGoal)
            {
                if (item.isSelected)
                {
                    Goals[i++] =item.Id;
                  }
              }
              AssignGoalRequest assignGoal = new AssignGoalRequest()
            {
                AssignBy = AssignBy,
                Goals = Goals
            };
                
            AssignGoalService assignGoals = new AssignGoalService();
            var response = await assignGoals.Create(AssignTo, assignGoal);
             return Redirect("Create");
            }

        
        public async Task<List<GoalResponseModel>> GetGoals()
        {
            GoalService createGoal = new GoalService();
            var responseAllGoals = await createGoal.GetAllGoals();
            List<GoalResponseModel> resopnseAllGoalsCreateModel = new List<GoalResponseModel>();

            foreach (var i in responseAllGoals)
            {
                resopnseAllGoalsCreateModel.Add(new GoalResponseModel
                {
                    Id = i.Id,
                    CreatedBy = i.CreatedBy,
                    Title = i.Title,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Score = i.Score
                });


            };
            return resopnseAllGoalsCreateModel;
        }
    }
}
