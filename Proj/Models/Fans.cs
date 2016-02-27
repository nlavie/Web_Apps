using System;
using System.ComponentModel.DataAnnotations;

namespace Proj.Models
{
    public class Fans
    {
        public int ID { get; set; }
        [Display(Name = "First Name"), Required]// grapichal override
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Birth Date"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Years In Club")]
        public int Seniority { get; set; }
        public Boolean Admin { get; set; }
        public RegisterViewModel LoginDetails { get; set; }
    }
    public enum Gender
    {
        Male, Female
    }
}