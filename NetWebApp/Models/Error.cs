using FluentValidation.Results;

namespace NetWebApp.Models
{
    public class Error
    {
        public Error() { }

        public Error(ValidationFailure error)
        {
            this.Message = error.ErrorMessage;
            this.ResponseCode = error.ErrorCode;
        }

        public string Message { get; set; }
        public string ResponseCode { get; set; }
    }
}