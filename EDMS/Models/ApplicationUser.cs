using Microsoft.AspNetCore.Identity;

namespace EDMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
