using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCORE.AppDBContext;
using ASPCORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPCORE.Controllers
{
    [Authorize(Roles = "Admin,Exicutive")]
    public class MakeController : Controller
    {
        private readonly VroomDbContext _db;

        public MakeController(VroomDbContext db)
        {
            _db = db;
        }
        [Route("Make/Index")]
        public IActionResult Index()
        {
            return View(_db.makes.ToList());
        }

        //Http Get Method
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Craete Make orders
        //Http Post Method
        [HttpPost]
        public IActionResult Create(Make make)
        {
         if(ModelState.IsValid)
            {
                _db.Add(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var make = _db.makes.Find(id);
            if(make==null)
            {
                return NotFound();
            }
            _db.makes.Remove(make);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Edit//
        public IActionResult Edit(int id)
        {
            var make = _db.makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        //Eddit Post
        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Update(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }

        //make/bikes
        [Route("Make")]
        [Route("Make/Bikes")]
        public IActionResult Bikes()
        {
            Make make = new Make { Id = 1, Name = "Datta" };
             return View(make);
            // ContentResult CR = new ContentResult { Content = "Hello world" };
            //return CR;
            //return Content("Hi this is datta");
            //return Redirect("/home");
           // return RedirectToAction("About", "Home");
        }
        [Route("Make/Bikes/{year:int:length(4)}/{month:int:range(1,13)}")]
        public IActionResult ByYearMonth(int year,int month)
        {
            return Content(year + ";" + month);
        }


    }
}