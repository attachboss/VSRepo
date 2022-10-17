using Microsoft.EntityFrameworkCore;
using WebMinimumApi1.Model;

namespace WebMinimumApi1.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<ToDo> ToDos => Set<ToDo>();
    }
}
