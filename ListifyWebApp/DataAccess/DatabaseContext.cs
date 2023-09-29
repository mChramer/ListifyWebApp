              using ListifyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ListifyWebApp.DataAccess
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) 
            :base(options) 
        { 
        }

        public DbSet<Listify> Listify { get; set; }
        public DbSet<ItemTask> Task { get; set; }

    }
}
