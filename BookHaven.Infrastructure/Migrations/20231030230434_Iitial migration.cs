using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHaven.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Iitialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookHavenTags_Books_BookId",
                table: "BookHavenTags");

            migrationBuilder.DropIndex(
                name: "IX_BookHavenTags_BookId",
                table: "BookHavenTags");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookHavenTags");

            migrationBuilder.DropColumn(
                name: "BookPostId",
                table: "BookHavenTags");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Books",
                newName: "ImageUrlHandle");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "BookHavenTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BookBookHavenTag",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookHavenTag", x => new { x.BooksId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BookBookHavenTag_BookHavenTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "BookHavenTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookHavenTag_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookHavenTag_TagsId",
                table: "BookBookHavenTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookHavenTag");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "BookHavenTags");

            migrationBuilder.RenameColumn(
                name: "ImageUrlHandle",
                table: "Books",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "BookHavenTags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookPostId",
                table: "BookHavenTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BookHavenTags_BookId",
                table: "BookHavenTags",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookHavenTags_Books_BookId",
                table: "BookHavenTags",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
