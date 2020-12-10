using ASPCORE.AppDBContext;
using ASPCORE.Models;
using ASPCORE.Models.ViewModels;
using ASPCORE.Servcies.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Servcies
{
    public class LoanServiceEmployee : ILaonServiceemployee<LoanuserViewModels>
    {
        private readonly VroomDbContext _db;

        public LoanServiceEmployee(VroomDbContext db)
        {
            _db = db;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<LoanuserViewModels> GetAll()
        {
            //var allloanusers = _db.Loanusers.ToList();
            //return allloanusers;
            Loanusers lu = new Loanusers();
           var loans = new List<LoanuserViewModels>();
            var allbooks = (from iint in _db.Loanusers
                                 join n in _db.loanDetails on iint.Id equals n.LoanusersId
                                 select new
                                 {
                                    iint.Id,
                                     iint.ImagePath,
                                     iint.FirstName,
                                     iint.LastName,
                                     iint.Phoneno,
                                     iint.Loanstatus,
                                     iint.address
                                 }

                                 ).ToList();

            if (allbooks?.Any() == true)
            {
                foreach (var loan1 in allbooks)
                {
                    loans.Add(new LoanuserViewModels()
                    {
                     Id = loan1.Id,
                     ImagePath=loan1.ImagePath,
                     FirstName=loan1.FirstName,
                     LastName=loan1.LastName,
                     Phoneno=loan1.Phoneno,
                     Loanstatus=loan1.Loanstatus,
                     address=loan1.address
                    });
                }
            }

            return loans;
        }

        public LoanuserViewModels GetById(int id)
        {
            LoanuserViewModels empDetails = (from emp in _db.Loanusers
                               join us in _db.loanDetails on emp.Id equals us.LoanusersId
                               where emp.Id == id
                               select new LoanuserViewModels
                               {
                                   ImagePath = emp.ImagePath,
                                   FirstName = emp.FirstName,
                                   LastName = emp.LastName,
                                   Phoneno = emp.Phoneno,
                                   Emi=us.Emi,
                                   TotalLoanAmount = us.TotalLoanAmount,
                                   MonthlyEmi = us.MonthlyEmi,
                               }).FirstOrDefault();

            return empDetails;
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

        public int Insert(LoanuserViewModels item)
        {
            throw new NotImplementedException();
        }

        public int Update(Loanusers item, int id)
        {
            throw new NotImplementedException();
        }

        public int Update(LoanuserViewModels item, int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
