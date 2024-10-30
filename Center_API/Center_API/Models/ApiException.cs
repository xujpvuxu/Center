using Center_API.Enums;

namespace Center_API.Models
{
    public class ApiException : Exception

    {
        public ErrorCodeEnum ErrorCode { get; private set; }

        public ApiException(ErrorCodeEnum ErrorCode)
        {
            this.ErrorCode = ErrorCode;
        }
    }
}