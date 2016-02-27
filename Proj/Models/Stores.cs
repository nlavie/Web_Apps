using System;
using System.ComponentModel.DataAnnotations;

namespace Proj.Models
{
    public class Stores
    {
        [Key]
        public int StoreID { get; set; }
        [Display(Name = "Store location")]
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }
        public double latLocation { get; set; }
        public double longLocation { get; set;}
    }
}