using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCORE.AppDBContext;
using ASPCORE.Models;
using ASPCORE.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCORE.Controllers
{
    [Authorize(Roles="Admin,Exicutive")]
    public class ModelController : Controller
    {
        private readonly VroomDbContext _db;

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }
        public ModelController(VroomDbContext db)
        {
            _db = db;
            ModelVM = new ModelViewModel()
            {
                Makes = _db.makes.ToList(),
                Model = new Models.Model()
           };
        }
        public IActionResult Index()
        {
            var model = _db.models.Include(m => m.Make);
            return View(model.ToList());
        }

        //Read VehicleModel page
        [HttpGet]
        public IActionResult CreateModel()
        {
            return View(ModelVM);
        }

        //save to database vehicle model and makes
        [HttpPost,ActionName("CreateModel")]
        public IActionResult CreatePost()
        {
            if(!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.models.Add(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Save Edit Model
        public IActionResult Edit(int id)
        {
            ModelVM.Model = _db.models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            if(ModelVM.Model==null)
            {
                return NotFound();
            }
            return View(ModelVM);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if(!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.Update(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.models.Find(id);
            if(model==null)
            {
                return NotFound();
            }
            _db.models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}