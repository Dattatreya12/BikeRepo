using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORE.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public Make make { get; set; }
      //  [RegularExpression("^[1-9]*$",ErrorMessage ="Select Make")]
      
        public int MakeID { get; set; }
        public int makID { get; set; }
       // [RegularExpression("^[1-9]*$", ErrorMessage = "Select Model")]
        public int ModelID { get; set; }
        public Model model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required(ErrorMessage = "Provide Mileage")]

        [Range(1,int.MaxValue,ErrorMessage ="provide value correct")]
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Provide Features")]
        public string Features { get; set; }
        
        [Required (ErrorMessage ="Provide SellerName")]
        public string SellerName { get; set; }
        [Required(ErrorMessage = "Provide Seller Email")]
        public string SellerEmail { get; set; }
        [Required(ErrorMessage = "Provide Seller Phoneno")]
        public string SellerPhone { get; set; }
        [Required(ErrorMessage = "Provide Price")]
        public int Price { get; set; }
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Select Currency")]
        public string Currency { get; set; }
        public string ImagePath { get; set; }

    }
}
