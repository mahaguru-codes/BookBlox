using BookBlox.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBlox.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Category> Categories { get; set; }
    }
}
