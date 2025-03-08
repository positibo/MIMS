using MIMS.Api.Source.Domain.BusinessRules.Base;

namespace MIMS.Api.Source.Domain.BusinessRules
{
    public class UsernamePasswordIncorrectException : BusinessRulesException
    {
        private const string message = "Username or password is incorrect.";
        private const bool isSuccess = false;

        public UsernamePasswordIncorrectException() : base(System.Net.HttpStatusCode.BadRequest, isSuccess, message) { }
    }
}
