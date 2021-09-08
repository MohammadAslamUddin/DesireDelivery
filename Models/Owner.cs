using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesireDelivery.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Owner's Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Owner's Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Owner's Mobile Number")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Enter Owner's Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Owner's Date of Birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter Account Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter Password Again")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Not Matched, Please Enter the Password Correctly")]
        public string ConfirmPassword { get; set; }
    }
}