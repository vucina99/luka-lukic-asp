using BCrypt.Net;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class FilmContext : DbContext
    {
        public FilmContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<CategoryFilm>().HasKey(x => new { x.FilmId, x.CategoryId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            modelBuilder.Entity<Film>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Author>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Category>().HasQueryFilter(x => x.isActive);
            modelBuilder.Entity<Comment>().HasQueryFilter(x => x.isActive);

            if (modelBuilder.Model.FindAnnotation("HasData") == null)
            {
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = 1,
                    UserName = "Test",
                    Email = "test@ict.rs",
                    FirstName = "Test",
                    LastName = "Test",
                    Password= BCrypt.Net.BCrypt.HashPassword("Test123!"),
                    isActive = true
                });
                modelBuilder.Entity<UserUseCase>().HasData(new List<UserUseCase>
                    {
                        new UserUseCase{ UseCaseId=1,UserId=1},
                        new UserUseCase{ UseCaseId=2,UserId=1},
                        new UserUseCase{ UseCaseId=3,UserId=1},
                        new UserUseCase{ UseCaseId=4,UserId=1},
                        new UserUseCase{ UseCaseId=5,UserId=1},
                        new UserUseCase{ UseCaseId=6,UserId=1},
                        new UserUseCase{ UseCaseId=7,UserId=1},
                        new UserUseCase{ UseCaseId=8,UserId=1},
                        new UserUseCase{ UseCaseId=9,UserId=1},
                        new UserUseCase{ UseCaseId=10,UserId=1},
                        new UserUseCase{ UseCaseId=11,UserId=1},
                        new UserUseCase{ UseCaseId=12,UserId=1},
                        new UserUseCase{ UseCaseId=13,UserId=1},
                        new UserUseCase{ UseCaseId=14,UserId=1},
                        new UserUseCase{ UseCaseId=15,UserId=1},
                        new UserUseCase{ UseCaseId=16,UserId=1},
                        new UserUseCase{ UseCaseId=17,UserId=1},
                        new UserUseCase{ UseCaseId=18,UserId=1},
                        new UserUseCase{ UseCaseId=19,UserId=1},
                        new UserUseCase{ UseCaseId=20,UserId=1},
                        new UserUseCase{ UseCaseId=21,UserId=1},
                        new UserUseCase{ UseCaseId=22,UserId=1}
                    });
            }

                base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=film_asp;Integrated Security=True");
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = "";
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<Film> Films { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<CategoryFilm> FilmCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<FilmImage> FilmImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UseCaseLogger> UseCaseLogs { get; set; }


    }
}
