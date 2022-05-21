using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UnifiedLearningSystem.Infrastructure.Persistence
{
    public class ApplicationUserContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ApplicationUserContext(DbContextOptions options) : base(options) { }
    }
}
