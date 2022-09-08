using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 1, 0, "test@user.com", "Test", "User", new byte[] { 178, 25, 113, 157, 18, 243, 199, 144, 56, 143, 115, 52, 178, 86, 63, 55, 106, 130, 219, 231, 235, 50, 122, 29, 230, 97, 57, 112, 228, 32, 20, 212, 137, 53, 139, 54, 58, 192, 77, 95, 144, 156, 28, 72, 82, 230, 112, 60, 30, 29, 58, 43, 155, 152, 152, 40, 121, 40, 142, 107, 155, 177, 187, 207 }, new byte[] { 68, 12, 34, 96, 142, 25, 118, 163, 151, 28, 59, 168, 162, 97, 38, 153, 229, 116, 179, 192, 226, 217, 145, 134, 65, 82, 0, 215, 157, 221, 95, 43, 186, 125, 186, 104, 34, 150, 213, 125, 130, 226, 55, 250, 150, 95, 199, 101, 204, 130, 230, 235, 228, 67, 202, 79, 25, 3, 247, 110, 156, 150, 155, 157, 77, 188, 18, 113, 234, 26, 153, 75, 66, 99, 237, 248, 128, 172, 239, 158, 130, 209, 166, 29, 221, 184, 32, 250, 26, 214, 99, 247, 126, 186, 191, 217, 118, 93, 191, 23, 114, 77, 107, 123, 173, 30, 190, 22, 151, 135, 219, 48, 117, 158, 19, 5, 115, 205, 129, 154, 58, 92, 144, 200, 63, 38, 124, 125 }, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 2, 2, "test@admin.com", "Test", "Admin", new byte[] { 80, 129, 206, 56, 156, 130, 202, 61, 104, 214, 219, 174, 48, 206, 198, 145, 105, 186, 138, 196, 81, 176, 213, 215, 250, 40, 178, 2, 216, 195, 181, 251, 45, 132, 227, 243, 131, 127, 17, 177, 3, 149, 35, 137, 184, 254, 145, 37, 95, 110, 6, 201, 181, 111, 51, 240, 29, 55, 144, 102, 237, 200, 180, 77 }, new byte[] { 84, 42, 212, 65, 201, 113, 207, 189, 91, 79, 74, 185, 220, 74, 120, 25, 127, 246, 87, 248, 122, 162, 251, 70, 85, 104, 43, 84, 67, 197, 93, 99, 129, 221, 200, 238, 242, 31, 67, 74, 44, 183, 57, 232, 103, 124, 76, 55, 164, 86, 13, 144, 27, 76, 148, 172, 62, 117, 208, 40, 242, 9, 188, 204, 42, 175, 78, 109, 126, 99, 34, 146, 87, 209, 2, 168, 28, 46, 192, 179, 250, 203, 101, 158, 206, 70, 161, 119, 231, 80, 242, 36, 182, 253, 54, 92, 50, 124, 235, 58, 228, 48, 157, 210, 40, 160, 185, 216, 249, 96, 194, 80, 239, 32, 151, 171, 167, 97, 191, 232, 103, 66, 28, 225, 140, 140, 50, 236 }, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
