using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DesireDelivery.Models.OwnersA
{
    public class Foods
    {
        public int Id { get; set; }
        [Display(Name = "Food Name")]
        public string FoodName { get; set; }
        [Display(Name = "Restaurant Name")]
        public int RestaurantName { get; set; }
        public string Price { get; set; }
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}