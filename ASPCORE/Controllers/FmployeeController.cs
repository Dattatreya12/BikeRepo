using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASPCORE.Controllers
{
    public class FmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}