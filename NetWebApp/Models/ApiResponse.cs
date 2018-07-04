namespace NetWebApp.Models
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public Errors Errors { get; set; }

        public bool Success
        {
            get
            {
                return Errors == null || Errors.Count == 0;
            }
        }
    }

}