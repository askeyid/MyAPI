using RestSharp;
using RestSharp.Authenticators;

namespace MyAPI.Framework.Auth
{
    public class APIAuthenticator : AuthenticatorBase
    {
        readonly string key;
        readonly string value;

        public APIAuthenticator() : base("")
        {
            //hardcoded. It needs to implement getting the tokens from a config file
            key = "app-id";
            value = "6488439579957f51bcdd633d";
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            //var token = string.IsNullOrEmpty(Token) ? $"{key} {value}" : Token;
            return new HeaderParameter(key, value);
        }
    }
}
