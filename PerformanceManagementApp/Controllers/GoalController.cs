using Microsoft.AspNetCore.Mvc;
using PerformanceManagementApp.Models;
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
            return View();
        }
    }
}
