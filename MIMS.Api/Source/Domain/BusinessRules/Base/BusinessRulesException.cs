using System.Globalization;
using System.Net;

namespace MIMS.Api.Source.Domain.BusinessRules.Base
{
    public class BusinessRulesException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }

        public BusinessRulesException(HttpStatusCode statusCode) : base() { StatusCode = statusCode; }

        public BusinessRulesException(HttpStatusCode statusCode, string message) : base(message) { StatusCode = statusCode; }

        public BusinessRulesException(HttpStatusCode statusCode, bool isSuccess, string message) : base(message)
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
        }

        public BusinessRulesException(HttpStatusCode statusCode, bool isSuccess, string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
        }
    }
}
