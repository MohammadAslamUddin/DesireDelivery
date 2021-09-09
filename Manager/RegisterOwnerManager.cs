using DesireDelivery.Gateway;
using DesireDelivery.Models;

namespace DesireDelivery.Manager
{
    public class RegisterOwnerManager
    {
        private RegisterOwnerGateway registerOwnerGateway;

        public RegisterOwnerManager()
        {
            registerOwnerGateway = new RegisterOwnerGateway();
        }

        public string Save(Owner owner)
        {
            return "";
        }
    }
}