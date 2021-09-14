using System.Web;

namespace DesireDelivery.Models.OwnersA
{
    public class Foods
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int RestaurantName { get; set; }
        public string Price { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}