using Microsoft.EntityFrameworkCore;
using PetAdoption.Api.Data.Entities;

namespace PetAdoption.Api.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorites> UserFavorites { get; set; }
        public DbSet<UserAdoption> UserAdoptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorites>()
                        .HasKey(uf => new { uf.UserId, uf.PetId });

            modelBuilder.Entity<Pet>()
                        .HasData(InitialPetsData());
        }

        private static List<Pet> InitialPetsData()
        {
            var pets = new List<Pet>
            {
                new Pet
                {
                    Id = 1,
                    Name = "Buddy",
                    Breed = "Dog - Golden Retriever",
                    Price = 300,
                    Description = "Buddy is a friendly and playful Golden Retriever, known for being great with kids and owner"
                },
                new Pet
                {
                    Id = 2, Name = "Whiskers", Breed = "Cat - Siamese", Price = 150, Description = "Whiskers is an elegant Siamese"
                },
                new Pet
                {
                    Id = 3, Name = "Rocky", Breed = "Dog - German Shepherd", Price = 400, Description = "Rocky is loyal and friendly"
                }
            };
            return pets;
        }
    }
}
