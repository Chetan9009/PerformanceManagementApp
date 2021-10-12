using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AssignGoalService
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<HttpStatusCode> Create(int AssignTo,AssignGoalRequest createAssignGoalRequest)
        {
            
           var response = await client.PostAsJsonAsync("https://localhost:44369/api/GoalMapperAPI/AssignGoals/" + AssignTo, createAssignGoalRequest);
            response.EnsureSuccessStatusCode();

          
            if (response.IsSuccessStatusCode)
            {
                var getApiResponse = response.Content.ReadAsStringAsync().Result;
              
            }
            return response.StatusCode;

        }



    }
}
