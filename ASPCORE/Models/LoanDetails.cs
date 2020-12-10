using ASPCORE.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Models
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public int LoanusersId { get; set; }
        public int Emi { get; set; }
        public int TotalLoanAmount { get; set; }
        public int MonthlyEmi { get; set; }
        public int TotalIntrest { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<Loanusers> loanusers { get; set; }
    }
}
