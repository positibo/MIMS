using MIMS.Api.Source.Domain.BusinessRules.Base;

namespace MIMS.Api.Source.Domain.BusinessRules
{
    public class UnauthorizedException : BusinessRulesException
    {
        private const string message = "Unathorized access.";
        private const bool isSuccess = false;

        public UnauthorizedException() : base(System.Net.HttpStatusCode.BadRequest, isSuccess, message) { }
    }
}
