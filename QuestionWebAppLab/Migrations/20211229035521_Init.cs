using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionWebAppLab.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Orders = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionCategoryId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    Orders = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_QuestionCategory_QuestionCategoryId",
                        column: x => x.QuestionCategoryId,
                        principalTable: "QuestionCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestioniOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    Feedback = table.Column<string>(maxLength: 1000, nullable: false),
                    Orders = table.Column<int>(nullable: false),
                    IsAnswer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestioniOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestioniOption_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionCategoryId",
                table: "Question",
                column: "QuestionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestioniOption_QuestionId",
                table: "QuestioniOption",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestioniOption");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionCategory");
        }
    }
}
