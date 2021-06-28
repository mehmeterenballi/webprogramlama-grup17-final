using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace VeritabaniProjesi.Migrations
{
    public partial class BasicTablesScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Title = table.Column<string>(maxLength: 40, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    SourceListString = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "BlackList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    Sender = table.Column<string>(maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PostTitle = table.Column<string>(maxLength: 40, nullable: true),
                    Sender = table.Column<string>(maxLength: 20, nullable: true),
                    PeopleWhoLikedString = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    PostTitle = table.Column<string>(maxLength: 40, nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.PostTitle);
                    table.ForeignKey(
                        name: "FK_Titles_Posts_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titles_QuestionId",
                table: "Titles",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "BlackList");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
