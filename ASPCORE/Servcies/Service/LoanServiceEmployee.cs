using ASPCORE.AppDBContext;
using ASPCORE.Models;
using ASPCORE.Servcies.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Servcies
{
    public class LoanServiceEmployee : ILaonServiceemployee<Loanusers>
    {
        private readonly VroomDbContext _db;

        public LoanServiceEmployee(VroomDbContext db)
        {
            _db = db;
        }
        public int Delete(int id)
        {
            return 0;
        }

        public List<Loanusers> GetAll()
        {
            var allloanusers = _db.Loanusers.ToList();
            return allloanusers;
        }

        public Loanusers GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Loanusers item)
        {
            // throw new NotImplementedException();
           // Loanusers dbsave = new Loanusers();
            //var newloan = new Loanusers()
            //{
            //    FirstName = item.FirstName,
            //    LastName = item.LastName,
            //    Phoneno = item.Phoneno,
            //    address = item.address,
            //    Loanstatus = item.Loanstatus,
            //    ImagePath = item.ImagePath,
            //};
            _db.Loanusers.Add(item);
            _db.SaveChanges();
            return item.Id;
        }

        public int Update(Loanusers item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
