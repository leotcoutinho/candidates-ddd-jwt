namespace SisNet.Api.Models
{
    public class ValidationErrorModel 
    {
        public string PropertyName { get; set; }
        public List<string> Errors { get; set; }

    }
}
