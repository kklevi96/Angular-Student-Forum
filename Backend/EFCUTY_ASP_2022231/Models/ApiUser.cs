using Microsoft.AspNetCore.Identity;

namespace EFCUTY_ASP_2022231.Models
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
