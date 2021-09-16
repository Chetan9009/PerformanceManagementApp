using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using PerformanceManagementApp.Models;
using ServiceLayer;
using ServiceLayer.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public async Task<IActionResult> Create(GoalCreateModel goal)
        {

            GoalCreateRequest requestCreateGoal = new GoalCreateRequest
            {
                CreatedBy = goal.CreatedBy,
                Title = goal.Title,
                StartDate = goal.StartDate,
                EndDate = goal.EndDate,
                Score = goal.Score
            };

            GoalService createGoal = new GoalService();
            var responseGoal =await createGoal.Create(requestCreateGoal);
            GoalResponseModel resopnseCreateModel = new GoalResponseModel()
            {
                Id = responseGoal.Id,
                CreatedBy = responseGoal.CreatedBy,
                Title = responseGoal.Title,
                StartDate = responseGoal.StartDate,
                EndDate = responseGoal.EndDate,
                Score = responseGoal.Score

            };
                      
            return View("CreatedGoal",resopnseCreateModel);
        }


      
        public async Task<IActionResult> Update(GoalUpdateModel goal)
        {

           GoalUpdateRequest requestUpdateGoal = new GoalUpdateRequest
            {
                Id=goal.Id,
                CreatedBy = goal.CreatedBy,
                Title = goal.Title,
                StartDate = goal.StartDate,
                EndDate = goal.EndDate,
                Score = goal.Score
            };

            GoalService createGoal = new GoalService();
            var responseGoal = await createGoal.Update(requestUpdateGoal);
            GoalResponseModel resopnseCreateModel = new GoalResponseModel()
            {
                Id = responseGoal.Id,
                CreatedBy = responseGoal.CreatedBy,
                Title = responseGoal.Title,
                StartDate = responseGoal.StartDate,
                EndDate = responseGoal.EndDate,
                Score = responseGoal.Score

            };

            return View("CreatedGoal", resopnseCreateModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetGoals( )
        {
              GoalService createGoal = new GoalService();
            var responseAllGoals = await createGoal.GetAllGoals();
            List<GoalResponseModel> resopnseAllGoalsCreateModel = new List<GoalResponseModel>();

            foreach(var i in responseAllGoals)
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

            return View("GetAllGoals",resopnseAllGoalsCreateModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetGoal(int id)
        {
            GoalService createGoal = new GoalService();
            var responseGoal = await createGoal.GetGoal(id);
            GoalResponseModel resopnseGoalsCreateModel = new GoalResponseModel();

            foreach (var i in responseGoal)
            {

                resopnseGoalsCreateModel.Id = i.Id;
                resopnseGoalsCreateModel.CreatedBy = i.CreatedBy;
                resopnseGoalsCreateModel.Title = i.Title;
                resopnseGoalsCreateModel.StartDate = i.StartDate;
                resopnseGoalsCreateModel.EndDate = i.EndDate;
                resopnseGoalsCreateModel.Score = i.Score;
                


            };

            return View("Edit", resopnseGoalsCreateModel);
        }




        public async Task<IActionResult> Delete(int id)
        {
            GoalService deleteGoal = new GoalService();
            HttpStatusCode response =await deleteGoal.Delete(id);
            List<GoalResponseModel> resopnseAllGoalsCreateModel = new List<GoalResponseModel>();
            //return View("Create");
            return RedirectToAction("GetGoals");
        }

        //static readonly HttpClient client = new HttpClient();
        //[HttpPost]
        //public async Task<IActionResult> Create(GoalRequest goal)
        //{
        //    GoalCreateRequest createGoalRequest = new GoalCreateRequest
        //    {
        //        CreatedBy = goal.CreatedBy,
        //        Title = goal.Title,
        //        StartDate = goal.StartDate,
        //        EndDate = goal.EndDate,
        //        Score = goal.Score
        //    };
        //    var response = await client.PostAsJsonAsync("https://localhost:44369/api/goal/create", createGoalRequest);
        //    response.EnsureSuccessStatusCode();

        //    GoalResponseModel createGoalResponse = new GoalResponseModel();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var getApiResponse = response.Content.ReadAsStringAsync().Result;
        //        createGoalResponse = JsonConvert.DeserializeObject<GoalResponseModel>(getApiResponse);

        //        //TempData["abc"] = createGoalResponse;

        //        //return RedirectToAction("Index");
        //    }

        //    return View("CreatedGoal",createGoalResponse);
        //}
    }
}
