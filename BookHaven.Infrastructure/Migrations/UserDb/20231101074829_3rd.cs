using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHaven.Infrastructure.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class _3rd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9ba5c89-d298-4544-ab78-c3acc4b2eab4 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a661b2a6-9b46-4d30-8efc-e44ab96dfca5", "AQAAAAEAACcQAAAAEDmP5OrgzOMIxlVywC6lnJJwusl05ZlxFCbytHhh7FhgHuKRxj5HMPe/ebkPdvdaYA==", "99fd5422-b214-4920-b60f-34529673bf35" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9ba5c89-d298-4544-ab78-c3acc4b2eab4 ",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5ec7d04-2e02-47bc-99fb-a393a2bdc8cd", "AQAAAAEAACcQAAAAEEV2O+gN2uQ+W+6ix5UuMz84BkJRsFAwno6AK1H0d+PBddbOEYo1g8DULELOFfuTAQ==", "0a6840f0-dc64-4a69-8d95-e17d405bdd92" });
        }
    }
}
