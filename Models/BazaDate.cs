using Microsoft.EntityFrameworkCore;

namespace Proiect_Final_Curs_C_.Models
{
    public class BazaDate : DbContext
    {
        public BazaDate(DbContextOptions<BazaDate> options) : base(options)
        {
        }

        public DbSet<ToDo_Items> TodoItems { get; set; }
    }
}
