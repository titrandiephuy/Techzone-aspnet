
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZone.Entities;

namespace TechZone.Contexts
{
    public class TechzoneDBContext : IdentityDbContext<AppUser>
    {
        public TechzoneDBContext(DbContextOptions<TechzoneDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định
            SeedingCategory(modelBuilder);
            SeedingProduct(modelBuilder);
            SeedingUsers(modelBuilder);
            SeedingRoles(modelBuilder);
            SeedingUserRoles(modelBuilder);
        }

        private void SeedingCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                            new Category()
                            {
                                CategoryId = 1,
                                CategoryName = "Mobile Phones",
                                Description = "iPhone, Samsung",
                                Picture = "fas fa-mobile-alt",
                                Status = true
                            },
                            new Category()
                            {
                                CategoryId = 2,
                                CategoryName = "Laptop",
                                Description = "Laptop",
                                Picture = "fas fa-laptop",
                                Status = true
                            },
                            new Category()
                            {
                                CategoryId = 3,
                                CategoryName = "Tablet",
                                Description = "iPad, Samsung",
                                Picture = "fas fa-tablet",
                                Status = true
                            });
        }

        private void SeedingProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "iPhone 12",
                    Description ="adsaf",
                    Price = 18000000,
                    Quantity = 12,
                    Pictures = "~/images/iphone12.jpg",
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Asus",
                    Description = "",
                    Price = 12000000,
                    Quantity = 10,
                    Pictures = "~/images/laptop.jpg",
                    CategoryId = 2
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "iPad",
                    Description = "",
                    Price = 13500000,
                    Quantity = 7,
                    Pictures = "~/images/pc.jpg",
                    CategoryId = 3
                });
        }
        private void SeedingUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Khoa Nguyen",
                Email = "khoa.nguyen@codegym.vn",
                NormalizedEmail = "khoa.nguyen@codegym.vn",
                NormalizedUserName = "khoa nguyen",
                LockoutEnabled = false,
                PhoneNumber = "0935216417",
                Avatar = "~/images/avatar.jpg"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Asdf1234!");

            builder.Entity<AppUser>().HasData(user);
        }

        private void SeedingRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "SystemAdmin", ConcurrencyStamp = "1", NormalizedName = "System Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" }
                );
        }

        private void SeedingUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}