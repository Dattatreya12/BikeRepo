using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Models.ViewModels
{
    public class LoanuserViewModels
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string Phoneno { get; set; }
        public string Loanstatus { get; set; }
        public string ImagePath { get; set; }

        public int LoanusersId { get; set; }
        public int Emi { get; set; }
        public int TotalLoanAmount { get; set; }
        public int MonthlyEmi { get; set; }
        public int TotalIntrest { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Loanusers lu { get; set; }
        public LoanDetails loanDetail { get; set; }
        public IEnumerable<Userloanstatus> loanstatus { get; set; }

        private List<Userloanstatus> clist = new List<Userloanstatus>();
        private List<Userloanstatus> CreateList()
        {
            clist.Add(new Userloanstatus("Inprogress", "Inprogress"));
            clist.Add(new Userloanstatus("Completed", "Completed"));
            return clist;
        }

        public LoanuserViewModels()
        {
           
            loanstatus = CreateList();
        }
    }

    public class Userloanstatus
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Userloanstatus(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
