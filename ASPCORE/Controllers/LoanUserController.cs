using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPCORE.AppDBContext;
using ASPCORE.Models;
using ASPCORE.Models.ViewModels;
using ASPCORE.Servcies;
using ASPCORE.Servcies.IService;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCORE.Controllers
{
    public class LoanUserController : Controller
    {
        private readonly VroomDbContext _db;
        private readonly HostingEnvironment _hostingenvironment;
        private readonly ILaonServiceemployee<Loanusers> _loanServiceemployee;
        [BindProperty]
        public LoanuserViewModels Luvm { get; set; }
        public LoanUserController(VroomDbContext db, HostingEnvironment hostingenvironment, ILaonServiceemployee<Loanusers> loanServiceemployee)
        {
            _db = db;
            _hostingenvironment = hostingenvironment;
            _loanServiceemployee = loanServiceemployee;
            Luvm = new LoanuserViewModels()
            {
                lu = new Models.Loanusers()
            };
        }
        public IActionResult LoanIndex()
        {
            var loanusers = _loanServiceemployee.GetAll();
            return View(loanusers);
        }

        [HttpGet]
        public  IActionResult Insert()
        {
            
          return View(Luvm);
        }
        [HttpPost]
        public IActionResult Insert( LoanuserViewModels item)
        {
            var newloan = new Loanusers()
            {
                FirstName = item.lu.FirstName,
                LastName = item.lu.LastName,
                Phoneno = item.lu.Phoneno,
                address = item.lu.address,
                Loanstatus = item.lu.Loanstatus,
                ImagePath = item.lu.ImagePath,
            };
            int id = _loanServiceemployee.Insert(newloan);
            //var BikeId = BikeVM.Bike.Id;
            var loanid = id;

            string wwrootPath = _hostingenvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            var savedBike = _db.Loanusers.Find(loanid);

            if (files.Count != 0)
            {
                var ImagePath = @"images";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + loanid + Extension;
                var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                savedBike.ImagePath = RelativeImagePath;
                _db.SaveChanges();
            }
            return View(Luvm);
        }


    }
}