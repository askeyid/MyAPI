using API.Automation.Models.Request;
using API.Automation.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Context
{
    public class UserContext
    {
        public readonly CreateUserReq createUserReq;

        public UserContext() 
        {
            createUserReq = new CreateUserReq()
            {
                firstName = TestDataGenerator.RandomString(4, 15),
                lastName = TestDataGenerator.RandomString(4, 15),
                email = TestDataGenerator.RandomEmail()
            };
        }
    }
}
