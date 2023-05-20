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


    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferMem>()
                .HasKey(mo => new { mo.MemId, mo.OfferId });

            modelBuilder.Entity<OfferMem>()
                .HasOne(mo => mo.Mem)
                .WithMany(m => m.MemOffers)
                .HasForeignKey(mo => mo.MemId);

            modelBuilder.Entity<OfferMem>()
                .HasOne(mo => mo.Offer)
                .WithMany(o => o.MemOffers)
                .HasForeignKey(mo => mo.OfferId);


            modelBuilder.Entity<OfferMemAuthor>()
                .Property(b => b.IdMemAuthor)
                .HasColumnOrder(0);

            modelBuilder.Entity<OfferMemAuthor>()
                .Property(b => b.OfferId)
                .HasColumnOrder(1);


            modelBuilder.Entity<OfferMemAuthor>()
                .HasKey(mo => new { mo.IdMemAuthor, mo.OfferId });

            modelBuilder.Entity<OfferMemAuthor>()
                .HasOne(mo => mo.MemAuthor)
                .WithMany(m => m.OffersMemAuthor)
                .HasForeignKey(mo => mo.IdMemAuthor);

            modelBuilder.Entity<OfferMemAuthor>()
                .HasOne(mo => mo.Offer)
                .WithMany(o => o.OffersMemAuthor)
                .HasForeignKey(mo => mo.OfferId);
        }

       



    }
}
