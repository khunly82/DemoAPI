using CorrectionLabo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CorrectionLabo.Infrastructure.Database
{
    public class ChessContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Member> Members { get; set; }

        //public ChessContext(DbContextOptions options) : base(options) { }
    }
}
