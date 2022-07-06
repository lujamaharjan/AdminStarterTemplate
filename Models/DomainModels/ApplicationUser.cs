using Microsoft.AspNetCore.Identity;

namespace EnterpriseIMS.Models.DomainModels
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  MiddleName { get; set; }
    }
}
