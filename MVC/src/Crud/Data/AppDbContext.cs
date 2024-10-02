using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        
        public DbSet<Pessoa> pessoas { get; set; }
    }
}
