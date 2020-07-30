using System.Collections.Generic;

namespace HeyYo.Core.Data.ApiModels
{
    public class ValidationErrorResponse
    {
        public ICollection<ValidationErrorModel> Errors { get; set; } = new List<ValidationErrorModel>();
    }
}
