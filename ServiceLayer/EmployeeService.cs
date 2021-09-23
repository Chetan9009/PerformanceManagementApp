using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EmployeeService
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<List<EmployeeCreateResponse>> GetAllEmployee()
        {
            var response = await client.GetAsync("https://localhost:44369/api/employee/getemployee");
            response.EnsureSuccessStatusCode();
            List<EmployeeCreateResponse> createEmployeeAllResponse = new List<EmployeeCreateResponse>();
            if (response.IsSuccessStatusCode)
            {
                var getAllEmployeeApiResponse = response.Content.ReadAsStringAsync().Result;
                var allEmployee = JsonConvert.DeserializeObject<List<EmployeeCreateResponse>>(getAllEmployeeApiResponse);

                foreach (var i in allEmployee)
                {
                    createEmployeeAllResponse.Add(new EmployeeCreateResponse
                    {
                        Id = i.Id,
                        FirstName=i.FirstName,
                        LastName=i.LastName
                       
                    });

                }
            }
            return createEmployeeAllResponse;

        }


    }
}
