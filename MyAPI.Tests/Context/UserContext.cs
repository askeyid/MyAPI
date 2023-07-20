using MyAPI.Framework.Models.Request;
using MyAPI.Framework.Utility;

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
