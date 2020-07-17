using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    public class AuthorsController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
