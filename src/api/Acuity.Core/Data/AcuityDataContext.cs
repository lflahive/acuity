using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Acuity.Core.Data
{
    public class AcuityDataContext(DbContextOptions<AcuityDataContext> options) : IdentityDbContext<IdentityUser>(options)
    {
    }
}
