using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Models.ViewModels
{
    public class LoanuserViewModels
    {
        public Loanusers lu { get; set; }
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
