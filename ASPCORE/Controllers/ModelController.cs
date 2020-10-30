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
using PagedList;
using PagedList.Mvc;
using System.Web;
using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Index(string searchString, string sortorder, int pagenumber=1, int pagesize=3)
        {
            ViewBag.CurrentSortOrder = sortorder;
            ViewBag.CurrentSearch = searchString;
            ViewBag.modalParam = string.IsNullOrEmpty(sortorder) ? "modalsearch" : "";

            int pagination = (pagesize * pagenumber) - pagesize;
            //var model = _db.models.Include(m => m.Make);
            var model = from b in _db.models.Include(m => m.Make)
                               select b;
            var modelcount = model.Count();

            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(b => b.Name.Contains(searchString));
                 modelcount = model.Count();
            }
            // Sorting code//
            switch(sortorder)
            {
                case "modalsearch":
                    model = model.OrderByDescending(b => b.Name);
                    break;
                default:
                    model = model.OrderBy(b => b.Name);
                    break;
            }

                model = model
              .Skip(pagination).Take(pagesize);
            var result = new PagedResult<Model>
            {
                Data = model.AsNoTracking().ToList(),
                TotalItems = modelcount,
                PageNumber = pagenumber,
                PageSize = pagesize
            };
            ViewBag.success = HttpContext.Session.GetString("Message");
            return View(result);
            //return View(model.ToList());
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
            HttpContext.Session.SetString("Message", "success");
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