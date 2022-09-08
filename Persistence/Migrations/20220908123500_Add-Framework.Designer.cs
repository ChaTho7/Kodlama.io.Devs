﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220908123500_Add-Framework")]
    partial class AddFramework
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Security.Entities.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthenticatorType = 0,
                            Email = "test@user.com",
                            FirstName = "Test",
                            LastName = "User",
                            PasswordHash = new byte[] { 149, 229, 181, 236, 222, 194, 142, 244, 133, 27, 181, 94, 32, 244, 81, 197, 160, 193, 206, 202, 96, 147, 198, 20, 174, 91, 19, 97, 82, 254, 54, 160, 111, 156, 36, 58, 43, 153, 109, 55, 87, 250, 242, 120, 204, 147, 60, 108, 51, 86, 9, 113, 171, 132, 169, 106, 94, 221, 182, 75, 192, 156, 190, 222 },
                            PasswordSalt = new byte[] { 220, 125, 228, 186, 223, 171, 56, 239, 146, 53, 191, 123, 177, 117, 71, 30, 44, 122, 107, 213, 173, 224, 48, 228, 136, 179, 32, 177, 42, 89, 189, 59, 11, 138, 68, 45, 228, 241, 51, 239, 131, 231, 186, 242, 58, 202, 73, 231, 51, 36, 96, 85, 153, 29, 221, 231, 219, 161, 189, 2, 173, 181, 5, 153, 81, 200, 193, 37, 53, 114, 20, 185, 246, 146, 210, 25, 32, 38, 68, 164, 127, 47, 6, 241, 197, 170, 78, 221, 89, 141, 45, 191, 206, 160, 207, 53, 253, 192, 113, 162, 33, 135, 186, 4, 57, 192, 75, 9, 69, 200, 204, 16, 190, 159, 89, 53, 252, 32, 199, 30, 186, 99, 90, 94, 150, 235, 131, 108 },
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            AuthenticatorType = 2,
                            Email = "test@admin.com",
                            FirstName = "Test",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 4, 10, 27, 72, 152, 160, 131, 181, 57, 193, 133, 9, 148, 0, 137, 154, 205, 111, 172, 169, 119, 78, 115, 168, 220, 154, 253, 140, 210, 196, 232, 38, 191, 20, 108, 91, 164, 180, 13, 217, 248, 151, 142, 214, 175, 81, 177, 124, 238, 207, 37, 157, 227, 71, 38, 129, 14, 80, 54, 88, 23, 33, 193, 159 },
                            PasswordSalt = new byte[] { 54, 81, 44, 198, 173, 119, 73, 148, 168, 186, 121, 175, 46, 254, 248, 113, 167, 182, 30, 37, 10, 106, 109, 205, 53, 230, 85, 134, 82, 238, 39, 39, 118, 96, 7, 212, 179, 21, 102, 237, 167, 231, 145, 23, 47, 239, 35, 232, 30, 20, 33, 182, 30, 120, 12, 184, 228, 188, 76, 85, 77, 43, 11, 102, 219, 191, 246, 174, 24, 3, 9, 174, 3, 99, 206, 55, 27, 23, 105, 68, 149, 113, 184, 21, 184, 1, 234, 137, 165, 198, 29, 64, 76, 49, 102, 11, 75, 219, 31, 14, 42, 215, 69, 43, 225, 128, 106, 242, 80, 162, 112, 57, 122, 86, 85, 66, 245, 48, 251, 80, 209, 107, 243, 184, 26, 61, 53, 106 },
                            Status = true
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Domain.Entities.Framework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int>("ProgrammingLanguageId")
                        .HasColumnType("int")
                        .HasColumnName("ProgrammingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("Frameworks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ASP.NET",
                            ProgrammingLanguageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spring",
                            ProgrammingLanguageId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C Sharp"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Python"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ruby"
                        });
                });

            modelBuilder.Entity("Core.Security.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Security.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Security.Entities.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Security.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Framework", b =>
                {
                    b.HasOne("Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany()
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
