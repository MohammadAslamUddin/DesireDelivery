using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DesireDelivery.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Owner's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Owner's Email")]
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$", ErrorMessage = "Valid Email Id Needed!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Owner's Mobile Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Enter Owner's Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Owner's Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter Account Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Password Again")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



        [DisplayName("Image Path")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}