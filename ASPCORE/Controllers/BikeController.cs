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
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;

namespace ASPCORE.Controllers
{
    [Authorize(Roles = "Admin,Exicutive")]
    public class BikeController : Controller
    {
        private readonly VroomDbContext _db;
        private readonly HostingEnvironment _hostingenvironment;
        [BindProperty]
        public BikeViewModel BikeVM { get; set; }
        public BikeController(VroomDbContext db, HostingEnvironment hostingenvironment)
        {
            _db = db;
            _hostingenvironment = hostingenvironment;
            BikeVM = new BikeViewModel()
            {
                Makes = _db.makes.ToList(),
                Models= _db.models.ToList(),
                Bike=new Models.Bike()
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            var bikes = _db.Bikes.Include(m => m.make).Include(m => m.model);
            //foreach (var item in bikes)
            //{
            //   int  count = item.Id;
            //    currentcount = count;
            //}
            //  lastcount= currentcount;
            //if (!string.IsNullOrWhiteSpace(TempData["address"].ToString()))
            
              ViewBag.success = HttpContext.Session.GetString("Message");
            //and use you viewbag data in the view

            return View(bikes.ToList());
        }

        //Read VehicleModel page
        [HttpGet]
        public IActionResult Create()
        {
            return View(BikeVM);
        }

        //save to database vehicle model and makes
        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                BikeVM.Makes = _db.makes.ToList();
                BikeVM.Models = _db.models.ToList();
                return View(BikeVM);
            }
            _db.Bikes.Add(BikeVM.Bike);
            _db.SaveChanges();

            var BikeId = BikeVM.Bike.Id;

            string wwrootPath = _hostingenvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            var savedBike = _db.Bikes.Find(BikeId);

            if(files.Count!=0)
                {
                var ImagePath = @"images\bike";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + BikeId + Extension;
                var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                savedBike.ImagePath = RelativeImagePath;
                _db.SaveChanges();
            }

            HttpContext.Session.SetString("Message", "success");
            return RedirectToAction(nameof(Index));
        }

        // Save Edit Model
        //public IActionResult Edit(int id)
        //{
        //    ModelVM.Model = _db.models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
        //    if (ModelVM.Model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ModelVM);
        //}

        //[HttpPost, ActionName("Edit")]
        //public IActionResult EditPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(ModelVM);
        //    }
        //    _db.Update(ModelVM.Model);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    Model model = _db.models.Find(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.models.Remove(model);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}