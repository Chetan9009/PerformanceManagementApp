using MidLayer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class GoalService
    {
        static HttpClient client = new HttpClient();
        public async Task<Uri> Create(GoalRequest goal)
        {
            GoalCreateRequest createGoalRequest = new GoalCreateRequest();

            createGoalRequest.CreatedBy = goal.CreatedBy;
            createGoalRequest.Title = goal.Title;
            createGoalRequest.StartDate = goal.StartDate;
            createGoalRequest.EndDate = goal.EndDate;
            createGoalRequest.Score = goal.Score;

            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44369/api/goal/create", createGoalRequest);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;

        }
    }
}
