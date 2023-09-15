namespace API.Helpers.Errors;
    public class ApiValidation : ApiResponse{
        public ApiValidation() : base(400)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> Errors { get; set; }
        
    }
