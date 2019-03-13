using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentCrud.Migrations
{
    public partial class student_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    NeptunCode = table.Column<string>(maxLength: 20, nullable: false),
                    Class = table.Column<int>(nullable: false),
                    Faculty = table.Column<string>(maxLength: 20, nullable: false),
                    UID = table.Column<string>(nullable: false),
                    PhotoData = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
