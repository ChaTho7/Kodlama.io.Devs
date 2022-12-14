// <auto-generated />
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
    [Migration("20220908122418_Add-OperationClaim")]
    partial class AddOperationClaim
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
                            PasswordHash = new byte[] { 121, 3, 89, 238, 23, 191, 129, 253, 244, 161, 146, 220, 30, 252, 197, 217, 221, 206, 134, 226, 44, 106, 27, 102, 169, 64, 200, 92, 145, 70, 30, 46, 131, 104, 140, 76, 172, 43, 3, 174, 0, 117, 100, 174, 16, 108, 213, 93, 65, 240, 28, 71, 174, 155, 199, 76, 108, 115, 226, 181, 194, 122, 240, 24 },
                            PasswordSalt = new byte[] { 72, 87, 22, 194, 72, 145, 125, 213, 126, 91, 112, 200, 212, 74, 102, 254, 164, 235, 16, 47, 45, 8, 205, 206, 138, 43, 44, 230, 130, 48, 213, 74, 42, 0, 120, 204, 7, 84, 215, 226, 97, 220, 189, 236, 231, 36, 248, 186, 173, 54, 137, 127, 75, 233, 87, 215, 40, 172, 222, 97, 127, 14, 72, 216, 109, 76, 144, 35, 47, 150, 59, 202, 190, 9, 176, 106, 42, 133, 66, 51, 158, 5, 3, 243, 108, 55, 144, 52, 168, 77, 79, 26, 183, 84, 99, 239, 180, 145, 129, 223, 248, 8, 200, 69, 46, 253, 9, 238, 232, 2, 121, 136, 178, 56, 144, 187, 151, 113, 170, 68, 106, 241, 93, 54, 148, 215, 119, 184 },
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            AuthenticatorType = 2,
                            Email = "test@admin.com",
                            FirstName = "Test",
                            LastName = "Admin",
                            PasswordHash = new byte[] { 236, 13, 21, 128, 140, 107, 156, 206, 242, 126, 73, 56, 89, 175, 179, 240, 143, 46, 181, 128, 147, 35, 111, 114, 232, 168, 134, 236, 175, 39, 165, 115, 70, 209, 125, 72, 14, 237, 129, 105, 176, 239, 154, 228, 56, 168, 136, 77, 238, 161, 90, 244, 248, 254, 202, 210, 40, 238, 65, 62, 114, 164, 72, 12 },
                            PasswordSalt = new byte[] { 75, 69, 139, 93, 242, 94, 159, 39, 15, 228, 243, 120, 33, 208, 7, 46, 253, 12, 250, 1, 136, 110, 168, 176, 109, 243, 125, 118, 183, 136, 91, 148, 48, 141, 234, 202, 145, 139, 185, 1, 210, 18, 77, 72, 75, 78, 107, 126, 218, 116, 122, 166, 230, 226, 223, 198, 194, 44, 225, 231, 148, 119, 167, 181, 244, 134, 225, 182, 116, 217, 167, 135, 122, 64, 205, 80, 134, 19, 187, 245, 106, 31, 51, 193, 21, 243, 217, 49, 3, 179, 155, 254, 101, 198, 103, 56, 29, 46, 71, 199, 64, 51, 129, 134, 146, 35, 19, 226, 108, 4, 10, 55, 148, 166, 54, 252, 38, 215, 173, 216, 122, 10, 105, 32, 105, 113, 32, 206 },
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

            modelBuilder.Entity("Core.Security.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
