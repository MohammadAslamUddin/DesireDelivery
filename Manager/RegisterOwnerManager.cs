﻿using DesireDelivery.Gateway;
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
            if (registerOwnerGateway.IsEmailExist(owner))
            {
                return "Data should be unique!";
            }
            else
            {
                int rowAffected = registerOwnerGateway.Save(owner);
                if (rowAffected > 0)
                {
                    return "Owner Information saved!";
                }
                else
                {
                    return "Owner Information saving failed";
                }
            }
        }

    }
}