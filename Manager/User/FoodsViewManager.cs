using DesireDelivery.Gateway.Owner;
using DesireDelivery.Models.OwnersA;
using System.Collections.Generic;

namespace DesireDelivery.Manager.User
{
    public class FoodsViewManager
    {
        private FoodsGateway foodsGateway;

        public FoodsViewManager()
        {
            foodsGateway = new FoodsGateway();
        }
        public List<Foods> GetFoodBySearching(string stri)
        {
            return foodsGateway.GetFoodBySearching(stri);
        }
    }
}