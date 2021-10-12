using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class DesigntionService
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<List<DesignationCreateResponse>> GetAllDesignation()
        {
            var response = await client.GetAsync("https://localhost:44369/api/designation/GetDesignation");
            response.EnsureSuccessStatusCode();
            List<DesignationCreateResponse> createDesignationAllResponse = new List<DesignationCreateResponse>();
            if (response.IsSuccessStatusCode)
            {
                var getAllDesignationApiResponse = response.Content.ReadAsStringAsync().Result;
                var allDesignation= JsonConvert.DeserializeObject<List<DesignationCreateResponse>>(getAllDesignationApiResponse);

                foreach (var i in allDesignation)
                {
                    createDesignationAllResponse.Add(new  DesignationCreateResponse
                    {
                        Id=i.Id,
                        Designation=i.Designation
                       
                     });

                }
            }
            return createDesignationAllResponse;

        }
    }
}
