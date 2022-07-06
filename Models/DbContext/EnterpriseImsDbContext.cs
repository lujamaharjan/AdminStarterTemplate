using EnterpriseIMS.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EnterpriseIMS.Models.DbContext
{
    public class EnterpriseImsDbContext : IdentityDbContext<ApplicationUser>
    {

        public EnterpriseImsDbContext(DbContextOptions<EnterpriseImsDbContext> options) : base(options)
        {

        }

    }
}
