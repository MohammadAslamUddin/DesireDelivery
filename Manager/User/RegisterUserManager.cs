using DesireDelivery.Gateway.User;
using DesireDelivery.Models;

namespace DesireDelivery.Manager.User
{
    public class RegisterUserManager
    {
        private RegisterUserGateway registerUserGateway;

        public RegisterUserManager()
        {
            registerUserGateway = new RegisterUserGateway();
        }

        public string Save(RegisterUser user)
        {
            if (registerUserGateway.IsEmailExist(user))
            {
                return "Email and Contact Should be unique!";
            }
            else
            {
                int rowAffected = registerUserGateway.Save(user);
                if (rowAffected > 0)
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