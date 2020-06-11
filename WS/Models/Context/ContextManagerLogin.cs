using Microsoft.EntityFrameworkCore;

namespace WS.Models.Context
{
    public class ContextManagerLogin : DbContext
    {
        public ContextManagerLogin(DbContextOptions<ContextManagerLogin> options)
            : base(options) { }
        public ContextManagerLogin() { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }
      
    }
}
