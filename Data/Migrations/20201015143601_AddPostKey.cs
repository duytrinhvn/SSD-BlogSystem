using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSystem.Data.Migrations
{
    public partial class AddPostKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: false),
                    Posted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
