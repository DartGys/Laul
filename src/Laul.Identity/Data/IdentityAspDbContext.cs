using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Laul.Identity.Data
{
    public class IdentityAspDbContext : IdentityDbContext
    {
        public IdentityAspDbContext(DbContextOptions<IdentityAspDbContext> options) : base(options)
        {
        }
    }
}
