using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerformanceManagementApp.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<List<SelectListItem>> DDlDesignation()
        {
            DesigntionService createDesignation = new DesigntionService();
            var responseAllDesignation = await createDesignation.GetAllDesignation();
            List<SelectListItem> designationList = new List<SelectListItem>();
            foreach (var i in responseAllDesignation)
            {
                designationList.Add(new SelectListItem { Text = i.Designation, Value = Convert.ToString(i.Id) }
                 );
            }

            return designationList;


        }
        public async Task<IActionResult> Create()
        {
            ViewBag.designation = await DDlDesignation();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateModel employee)
        {

            EmployeeCreateRequest requestCreateEmployee = new EmployeeCreateRequest
            {
               FirstName= employee.FirstName,
               LastName=employee.LastName,
               DesignationId=employee.DesignationId,
               EmailId=employee.EmailId,
               Password=employee.Password
            };

            EmployeeService createEmployee = new EmployeeService();
            var responseEmployee= await createEmployee.Create(requestCreateEmployee);
            EmployeeResponseModel resopnseEmployeeModel = new EmployeeResponseModel()
            {
                Id=responseEmployee.Id,
                FirstName= responseEmployee.FirstName,
                LastName= responseEmployee.LastName,
                DesignationId= responseEmployee.DesignationId,
                EmailId= responseEmployee.EmailId,
                Password= responseEmployee.Password

            };

            return View("CreatedEmployee",resopnseEmployeeModel);
        }
    }
}
