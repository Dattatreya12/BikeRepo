using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Models.ViewModels
{
    public class BikeViewModel
    {
        public Bike Bike { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<Currency> currencies { get; set; }

        private List<Currency> clist = new List<Currency>();
        private List<Currency> CreateList()
        {
            clist.Add(new Currency("USD", "USD"));
            clist.Add(new Currency("INR", "INR"));
            clist.Add(new Currency("URO", "URO"));
            return clist;
        }

        public BikeViewModel()
        {
            currencies = CreateList();
        }
    }

    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Currency(string id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
