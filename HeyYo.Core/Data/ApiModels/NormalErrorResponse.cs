using System.Collections.Generic;

namespace HeyYo.Core.Data.ApiModels
{
    public class NormalErrorResponse
    {
        public ICollection<NormalErrorModel> Errors = new List<NormalErrorModel>();
    }
}
