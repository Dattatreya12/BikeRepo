using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Extensions
{
    public static class IEnumerableExtensions
    {
        public static object selectedvalue { get; private set; }

        public static IEnumerable<SelectListItem> MakesListinDropdown<T>(this IEnumerable<T> items)

        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "...........SELECT...........",
                Value = "0"
            };
            List.Add(sli);
            foreach (var item in items)
            {
                sli = new SelectListItem
                {
                    Text = item.GetPropertyValue("Name"),
                    Value = item.GetPropertyValue("Id"),
                    //Selected = item.GetPropertyValue("Id").Equals(selectedvalue.ToString())
                    ////Text = item.GetType().GetProperty("Name").GetValue(item,null).ToString(),
                    ////Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString()
                };
                List.Add(sli);
            }
            return List;
        }
    }
}
