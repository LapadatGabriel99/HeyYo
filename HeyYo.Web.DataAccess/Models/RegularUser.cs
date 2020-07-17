using System.ComponentModel.DataAnnotations;

namespace HeyYo.Web.DataAccess.Models
{
    public class RegularUser
    {
        [Key]
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
