using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DesireDelivery.Gateway.Owner;
using DesireDelivery.Models.OwnersA;

namespace DesireDelivery.Manager.Owner
{
    public class FoodsViewManager
    {
        private FoodsViewGateway foodsViewGateway;

        public FoodsViewManager()
        {
            foodsViewGateway = new FoodsViewGateway();
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
                if (RowAffected>0)
                {
                    return "Saved!";
                }
                else
                {
                    return "Saving Failed!";
                }
            }
        }
    }
}