using System;
using DesireDelivery.Gateway;
using DesireDelivery.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DesireDelivery.Manager
{
    public class RestaurantManager
    {
        private RestaurantGateway restaurantGateway;
        private RegisterOwnerGateway registerOwnerGateway;

        public RestaurantManager()
        {
            restaurantGateway = new RestaurantGateway();
            registerOwnerGateway = new RegisterOwnerGateway();
        }

        public List<SelectListItem> GetAllOwner()
        {
            return registerOwnerGateway.GetAllOwner();
        }

        public string Save(Restaurant restaurant)
        {
            if (restaurantGateway.NameExist(restaurant))
            {
                return "Restaurant name and Mobile Number Should be unique";
            }
            else
            {
                DateTime date = DateTime.Today;
                restaurant.AddingDate = date;
                int rowAffected = restaurantGateway.Save(restaurant);
                if (rowAffected > 0)
                {
                    return "Restaurant Information Saved!";
                }
                else
                {
                    return "Restaurant Information Saving Failed!";
                }
            }
        }
    }
}