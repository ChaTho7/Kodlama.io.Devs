using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GithubProfile> GithubProfiles { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds =
            {
                new(1, "C Sharp"),
                new(2, "Python"),
                new(3, "Java"),
                new(4, "Typescript"),
                new(5, "Ruby"),
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);


            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                a.HasMany(p => p.RefreshTokens);
                a.HasMany(p => p.UserOperationClaims);
            });

            HashingHelper.CreatePasswordHash("123456User", out var userPasswordHash, out var userPasswordSalt);
            HashingHelper.CreatePasswordHash("123456Admin", out var adminPasswordHash, out var adminPasswordSalt);

            User[] userEntitySeeds =
            {
                new()
                {
                    Id = 1,
                    AuthenticatorType = AuthenticatorType.None,
                    Email = "test@user.com",
                    FirstName = "Test",
                    LastName = "User",
                    PasswordHash = userPasswordHash,
                    PasswordSalt = userPasswordSalt,
                    Status = true,
                },
                new()
                {
                    Id = 2,
                    AuthenticatorType = AuthenticatorType.Otp,
                    Email = "test@admin.com",
                    FirstName = "Test",
                    LastName = "Admin",
                    PasswordHash = adminPasswordHash,
                    PasswordSalt = adminPasswordSalt,
                    Status = true,
                }
            };
            modelBuilder.Entity<User>().HasData(userEntitySeeds);


            modelBuilder.Entity<GithubProfile>(a =>
            {
                a.ToTable("GithubProfiles").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.ProfileUrl).HasColumnName("ProfileUrl");

                a.HasOne(p => p.User);
            });


            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });

            OperationClaim[] operationClaimEntitySeeds =
            {
                new(1, "User"),
                new(2, "Admin"),
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);


            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

                a.HasOne(p => p.User);
                a.HasOne(p => p.OperationClaim);
            });


            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");

                a.HasOne(p => p.User);
            });


            modelBuilder.Entity<Framework>(a =>
            {
                a.ToTable("Frameworks").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");

                a.HasOne(p => p.ProgrammingLanguage);
            });

            Framework[] frameworkEntitySeeds =
            {
                new()
                {
                    Id = 1,
                    Name = "ASP.NET",
                    ProgrammingLanguageId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Spring",
                    ProgrammingLanguageId = 3
                },
            };
            modelBuilder.Entity<Framework>().HasData(frameworkEntitySeeds);
        }
    }
}
