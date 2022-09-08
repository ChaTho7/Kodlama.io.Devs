using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddFramework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frameworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frameworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frameworks_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Frameworks",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "ASP.NET", 1 },
                    { 2, "Spring", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 229, 181, 236, 222, 194, 142, 244, 133, 27, 181, 94, 32, 244, 81, 197, 160, 193, 206, 202, 96, 147, 198, 20, 174, 91, 19, 97, 82, 254, 54, 160, 111, 156, 36, 58, 43, 153, 109, 55, 87, 250, 242, 120, 204, 147, 60, 108, 51, 86, 9, 113, 171, 132, 169, 106, 94, 221, 182, 75, 192, 156, 190, 222 }, new byte[] { 220, 125, 228, 186, 223, 171, 56, 239, 146, 53, 191, 123, 177, 117, 71, 30, 44, 122, 107, 213, 173, 224, 48, 228, 136, 179, 32, 177, 42, 89, 189, 59, 11, 138, 68, 45, 228, 241, 51, 239, 131, 231, 186, 242, 58, 202, 73, 231, 51, 36, 96, 85, 153, 29, 221, 231, 219, 161, 189, 2, 173, 181, 5, 153, 81, 200, 193, 37, 53, 114, 20, 185, 246, 146, 210, 25, 32, 38, 68, 164, 127, 47, 6, 241, 197, 170, 78, 221, 89, 141, 45, 191, 206, 160, 207, 53, 253, 192, 113, 162, 33, 135, 186, 4, 57, 192, 75, 9, 69, 200, 204, 16, 190, 159, 89, 53, 252, 32, 199, 30, 186, 99, 90, 94, 150, 235, 131, 108 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 4, 10, 27, 72, 152, 160, 131, 181, 57, 193, 133, 9, 148, 0, 137, 154, 205, 111, 172, 169, 119, 78, 115, 168, 220, 154, 253, 140, 210, 196, 232, 38, 191, 20, 108, 91, 164, 180, 13, 217, 248, 151, 142, 214, 175, 81, 177, 124, 238, 207, 37, 157, 227, 71, 38, 129, 14, 80, 54, 88, 23, 33, 193, 159 }, new byte[] { 54, 81, 44, 198, 173, 119, 73, 148, 168, 186, 121, 175, 46, 254, 248, 113, 167, 182, 30, 37, 10, 106, 109, 205, 53, 230, 85, 134, 82, 238, 39, 39, 118, 96, 7, 212, 179, 21, 102, 237, 167, 231, 145, 23, 47, 239, 35, 232, 30, 20, 33, 182, 30, 120, 12, 184, 228, 188, 76, 85, 77, 43, 11, 102, 219, 191, 246, 174, 24, 3, 9, 174, 3, 99, 206, 55, 27, 23, 105, 68, 149, 113, 184, 21, 184, 1, 234, 137, 165, 198, 29, 64, 76, 49, 102, 11, 75, 219, 31, 14, 42, 215, 69, 43, 225, 128, 106, 242, 80, 162, 112, 57, 122, 86, 85, 66, 245, 48, 251, 80, 209, 107, 243, 184, 26, 61, 53, 106 } });

            migrationBuilder.CreateIndex(
                name: "IX_Frameworks_ProgrammingLanguageId",
                table: "Frameworks",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frameworks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 121, 3, 89, 238, 23, 191, 129, 253, 244, 161, 146, 220, 30, 252, 197, 217, 221, 206, 134, 226, 44, 106, 27, 102, 169, 64, 200, 92, 145, 70, 30, 46, 131, 104, 140, 76, 172, 43, 3, 174, 0, 117, 100, 174, 16, 108, 213, 93, 65, 240, 28, 71, 174, 155, 199, 76, 108, 115, 226, 181, 194, 122, 240, 24 }, new byte[] { 72, 87, 22, 194, 72, 145, 125, 213, 126, 91, 112, 200, 212, 74, 102, 254, 164, 235, 16, 47, 45, 8, 205, 206, 138, 43, 44, 230, 130, 48, 213, 74, 42, 0, 120, 204, 7, 84, 215, 226, 97, 220, 189, 236, 231, 36, 248, 186, 173, 54, 137, 127, 75, 233, 87, 215, 40, 172, 222, 97, 127, 14, 72, 216, 109, 76, 144, 35, 47, 150, 59, 202, 190, 9, 176, 106, 42, 133, 66, 51, 158, 5, 3, 243, 108, 55, 144, 52, 168, 77, 79, 26, 183, 84, 99, 239, 180, 145, 129, 223, 248, 8, 200, 69, 46, 253, 9, 238, 232, 2, 121, 136, 178, 56, 144, 187, 151, 113, 170, 68, 106, 241, 93, 54, 148, 215, 119, 184 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 236, 13, 21, 128, 140, 107, 156, 206, 242, 126, 73, 56, 89, 175, 179, 240, 143, 46, 181, 128, 147, 35, 111, 114, 232, 168, 134, 236, 175, 39, 165, 115, 70, 209, 125, 72, 14, 237, 129, 105, 176, 239, 154, 228, 56, 168, 136, 77, 238, 161, 90, 244, 248, 254, 202, 210, 40, 238, 65, 62, 114, 164, 72, 12 }, new byte[] { 75, 69, 139, 93, 242, 94, 159, 39, 15, 228, 243, 120, 33, 208, 7, 46, 253, 12, 250, 1, 136, 110, 168, 176, 109, 243, 125, 118, 183, 136, 91, 148, 48, 141, 234, 202, 145, 139, 185, 1, 210, 18, 77, 72, 75, 78, 107, 126, 218, 116, 122, 166, 230, 226, 223, 198, 194, 44, 225, 231, 148, 119, 167, 181, 244, 134, 225, 182, 116, 217, 167, 135, 122, 64, 205, 80, 134, 19, 187, 245, 106, 31, 51, 193, 21, 243, 217, 49, 3, 179, 155, 254, 101, 198, 103, 56, 29, 46, 71, 199, 64, 51, 129, 134, 146, 35, 19, 226, 108, 4, 10, 55, 148, 166, 54, 252, 38, 215, 173, 216, 122, 10, 105, 32, 105, 113, 32, 206 } });
        }
    }
}
