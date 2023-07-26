using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace EmployeeFormMVC.Models
{

    public class Employee
    {

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only Integers are allowed")]
        public int emCode { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string emName { get; set; }



        [DataType(DataType.Date)]  //Attribute 
        [Required(ErrorMessage = "Date is required")]
        public DateTime? emDob { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "City is required")]
        public string emCity { get; set; }
        public string emGender { get; set; }
        public string emActive { get; set; }


        public string emImage { get; set; }
        public int Id { get; set; }
    }
    public enum City
    {
        Delhi,
        Agra,
        Ahemdabad,
        Pune,
        Indore,
        Jabalpur
    }
}