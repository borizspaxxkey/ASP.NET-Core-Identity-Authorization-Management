using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers
{       
    public class HomeController : Controller
    {
        //Teacher or Admin
        //[Authorize(Roles ="Admin,Teacher")]
        public IActionResult Admin() => View();

        //Student and Teacher Role Authorization
        //[Authorize(Roles = "Student")]
        //[Authorize(Roles = "Teacher")]
        public IActionResult Student() => View();

        //[Authorize(Policy ="TeachersOnly")]
        public IActionResult Teacher() => View();


        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
