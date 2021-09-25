using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class EmployeGoalService
    {

        static readonly HttpClient client = new HttpClient();

        public async Task<List<EmployeeGoalCreateResponse>> GetAllEmployeeGoal()
        {
            var response = await client.GetAsync("https://localhost:44369/api/goal/getEmpGoal");
            response.EnsureSuccessStatusCode();
            List<EmployeeGoalCreateResponse> createEmployeeGaolAllResponse = new List<EmployeeGoalCreateResponse>();
            if (response.IsSuccessStatusCode)
            {
                var getAllEmployeeGoalApiResponse = response.Content.ReadAsStringAsync().Result;
                var allEmployeeGoals = JsonConvert.DeserializeObject<List<EmployeeGoalCreateResponse>>(getAllEmployeeGoalApiResponse);

                foreach (var i in allEmployeeGoals)
                {
                    createEmployeeGaolAllResponse.Add(new EmployeeGoalCreateResponse
                    {
                        Id = i.Id,
                        CreatedBy = i.CreatedBy,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Title = i.Title,
                        StartDate = i.StartDate,
                        EndDate = i.EndDate,
                        Score = i.Score
                    });

                  }
 
            }
            return createEmployeeGaolAllResponse;

        }
    }
}
