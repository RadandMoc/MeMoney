using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MeMoney.DBases
{
    public class MyDbContext :DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        { }
        public DbSet<Company> Company { get; set; }
        public DbSet<Mem> Mem { get; set; }
        public DbSet<MemAuthor> MemAuthor { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<OfferMem> OfferMem { get; set; }
        public DbSet<OfferMemAuthor> OfferMemAuthor { get; set; }




       


    }
}
