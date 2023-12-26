using Microsoft.EntityFrameworkCore;

namespace ATM_MVC_App_Simple_Exmple_
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
