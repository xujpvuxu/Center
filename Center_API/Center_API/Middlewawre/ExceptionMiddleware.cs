using Center_API.Enums;
using Center_API.Models;

namespace Center_API.Middlewawre
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                await context.Response
                    .WriteAsJsonAsync(new ApiResponse
                    {
                        ErrorCode = (int)ex.ErrorCode,
                        TimeStamp = DateTimeOffset.Now,
                        ErrorMessage = ex.ToString()
                    });
            }
            catch (Exception ex)
            {
                await context.Response
                    .WriteAsJsonAsync(new ApiResponse
                    {
                        ErrorCode = (int)ErrorCodeEnum.UnknownError,
                        TimeStamp = DateTimeOffset.Now,
                        ErrorMessage = ex.ToString()
                    });
            }
        }
    }
}