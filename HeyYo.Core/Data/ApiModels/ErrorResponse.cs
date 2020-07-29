using System.Collections.Generic;

namespace HeyYo.Core.Data.ApiModels
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
