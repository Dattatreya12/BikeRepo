using ASPCORE.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Models
{
    public  class Loanusers
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string Phoneno { get; set; }
        public string Loanstatus { get; set; }
        public string ImagePath { get; set; }

        public LoanDetails loanDetails { get; set; }
        
    }
}
