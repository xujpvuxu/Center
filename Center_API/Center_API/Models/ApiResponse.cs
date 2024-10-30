namespace Center_API.Models
{
    public class ApiResponse
    {
        public int ErrorCode { get; set; } = 0;

        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.Now;

        public string ErrorMessage { get; set; } = "";
    }
}