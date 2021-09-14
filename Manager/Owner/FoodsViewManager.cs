﻿using DesireDelivery.Gateway.Owner;
using DesireDelivery.Models.OwnersA;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DesireDelivery.Manager.Owner
{
    public class FoodsViewManager
    {
        private FoodsViewGateway foodsViewGateway;
        private RestaurantGateway restaurantGateway;

        public FoodsViewManager()
        {
            foodsViewGateway = new FoodsViewGateway();
            restaurantGateway = new RestaurantGateway();
        }

        public string Save(Foods foods)
        {
            if (foodsViewGateway.IsFoodExist(foods))
            {
                return "This food is already listed!";
            }
            else
            {
                int RowAffected = foodsViewGateway.Save(foods);
                if (RowAffected > 0)
                {
                    return "Saved!";
                }
                else
                {
                    return "Saving Failed!";
                }
            }
        }

        public List<SelectListItem> GetAllRestaurants()
        {
            return restaurantGateway.GetAllRestaurants();
        }
    }
}