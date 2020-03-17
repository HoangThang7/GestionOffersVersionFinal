using GestionOffer.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionOffers.Models
{
    public class Context : DbContext
    {
       

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public static Context Create()
        {
             var connection = new DbContextOptionsBuilder<Context>();
             connection.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GestionOffers;Trusted_Connection=True;ConnectRetryCount=0");
             return new Context(connection.Options);
        }

       

        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<PieceOffer> Documents { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Direction> Direction { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Commission> Commission { get; set; }
        public DbSet<Plis> Plis { get; set; }
        public DbSet<Bidder> Bidder { get; set; }
        public DbSet<Depouillement> Depouillement { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Diffusion> Diffusion { get; set; }
        public DbSet<Contract> Contract { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Member>()
                .HasKey(p => new { p.commissionId, p.userId });


            modelBuilder.Entity<Diffusion>()
                .HasKey(p => new { p.offerId, p.bidderId });


            modelBuilder.Entity<Commission>()
                .HasMany(m => m.memberCommis)
                .WithOne(c => c.commission)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
                .HasMany(m => m.member)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.documents)
                .WithOne(b => b.offer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.plis)
                .WithOne(c => c.offer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offer>()
               .HasMany(d => d.diffusOffer)
               .WithOne(o => o.offer)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bidder>()
               .HasMany(d => d.diffusion)
               .WithOne(o => o.bidder)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bidder>()
               .HasMany(p => p.plis)
               .WithOne(b => b.bidder)
               .OnDelete(DeleteBehavior.Cascade);
        }

    }
}