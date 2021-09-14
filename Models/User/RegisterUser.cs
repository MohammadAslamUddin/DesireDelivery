using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DesireDelivery.Models
{
    public class RegisterUser
    {
        [Key]
        [NotMapped]
        public int UserId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "User Email Required")]
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$", ErrorMessage = "Valid Email Id Needed!")]
        public string UserEmail { get; set; }
        [Display(Name = "Contact")]
        [Required(ErrorMessage = "User Contact Required")]
        public string UserContact { get; set; }
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please Enter Your Date of Birth")]
        public DateTime UserDateOfBirth { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "User Address Required")]
        public string USerAddress { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter and one number")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Image Path")]
        [Required(ErrorMessage = "Please Select an image file")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}