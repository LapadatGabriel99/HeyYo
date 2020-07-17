using Microsoft.AspNetCore.Identity;

namespace HeyYo.Web.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RegularUser RegularUser { get; set; }
    }
}
