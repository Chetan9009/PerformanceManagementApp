
using Newtonsoft.Json;
using ServiceLayer.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class GoalService
    {               
        static readonly HttpClient client = new HttpClient();
        public async Task<GoalCreateResponse> Create(GoalCreateRequest createGoalRequest)
        {
            //GoalCreateRequest createGoalRequest = new GoalCreateRequest
            //{
            //    CreatedBy = goal.CreatedBy,
            //    Title = goal.Title,
            //    StartDate = goal.StartDate,
            //    EndDate = goal.EndDate,
            //    Score = goal.Score
            //};
           
             var response = await client.PostAsJsonAsync("https://localhost:44369/api/goal/create", createGoalRequest);
            response.EnsureSuccessStatusCode();

            GoalCreateResponse createGoalResponse = new GoalCreateResponse();
            if (response.IsSuccessStatusCode)
             {              
                var getApiResponse = response.Content.ReadAsStringAsync().Result;
               createGoalResponse = JsonConvert.DeserializeObject<GoalCreateResponse>(getApiResponse);
            }          
         return createGoalResponse;
                        
        }
        public async Task<GoalCreateResponse> Update(GoalUpdateRequest updateGoalRequest)
        {
            //GoalCreateRequest createGoalRequest = new GoalCreateRequest
            //{
            //    CreatedBy = goal.CreatedBy,
            //    Title = goal.Title,
            //    StartDate = goal.StartDate,
            //    EndDate = goal.EndDate,
            //    Score = goal.Score
            //};

            var response = await client.PutAsJsonAsync("https://localhost:44369/api/goal/update", updateGoalRequest);
            response.EnsureSuccessStatusCode();

            GoalCreateResponse createGoalResponse = new GoalCreateResponse();
            if (response.IsSuccessStatusCode)
            {
                var getApiResponse = response.Content.ReadAsStringAsync().Result;
                createGoalResponse = JsonConvert.DeserializeObject<GoalCreateResponse>(getApiResponse);
            }
            return createGoalResponse;

        }

        public async Task<List<GoalCreateResponse>> GetAllGoals()
        {           
            var response = await client.GetAsync("https://localhost:44369/api/goal/get");
            response.EnsureSuccessStatusCode();
            List<GoalCreateResponse> createGoalAllResponse = new List<GoalCreateResponse>();
            if (response.IsSuccessStatusCode)
            {
                var getAllGoalsApiResponse = response.Content.ReadAsStringAsync().Result;
                var allGoals = JsonConvert.DeserializeObject<List<GoalCreateResponse>>(getAllGoalsApiResponse);

                foreach( var i in allGoals)
                {
                    createGoalAllResponse.Add(new GoalCreateResponse
                    {
                        Id=i.Id,
                        CreatedBy = i.CreatedBy,
                        Title = i.Title,
                        StartDate = i.StartDate,
                        EndDate = i.EndDate,
                        Score = i.Score
                      });

                }
            }
            return createGoalAllResponse;

        }

        public async Task<List<GoalCreateResponse>> GetGoal(int id)
        {
            var response = await client.GetAsync("https://localhost:44369/api/goal/get/"+id);
            response.EnsureSuccessStatusCode();
            List<GoalCreateResponse> createGoalResponse = new List<GoalCreateResponse>();
            if (response.IsSuccessStatusCode)
            {
                var getGoalsApiResponse = response.Content.ReadAsStringAsync().Result;
                var Goal = JsonConvert.DeserializeObject<List<GoalCreateResponse>>(getGoalsApiResponse);

                foreach (var i in Goal)
                {
                    createGoalResponse.Add(new GoalCreateResponse
                    {
                        Id = i.Id,
                        CreatedBy = i.CreatedBy,
                        Title = i.Title,
                        StartDate = i.StartDate,
                        EndDate = i.EndDate,
                        Score = i.Score
                    });

                }
            }
            return createGoalResponse;

        }
        public async Task<HttpStatusCode> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("https://localhost:44369/api/goal/delete/"+id);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;

        }
    }
}
