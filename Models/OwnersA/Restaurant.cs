using System;
using System.ComponentModel.DataAnnotations;

namespace DesireDelivery.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Restaurant Name Needed")]
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }
        [Required(ErrorMessage = "Restaurant Address Needed")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Restaurant Mobile Number Needed")]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Select Restaurant Owners Name")]
        public DateTime AddingDate { get; set; }
        [Display(Name = "Owner Name")]
        public int OwnerId { get; set; }
    }
}