using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class DbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QUestionTests_Questions_QuestionId",
                table: "QUestionTests");

            migrationBuilder.DropForeignKey(
                name: "FK_QUestionTests_Tests_TestId",
                table: "QUestionTests");

            migrationBuilder.DropTable(
                name: "QuestionTest");

            migrationBuilder.RenameTable(
                name: "QUestionTests",
                newName: "QuestionTests");

            migrationBuilder.RenameIndex(
                name: "IX_QUestionTests_TestId",
                table: "QuestionTests",
                newName: "IX_QuestionTests_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_QUestionTests_QuestionId",
                table: "QuestionTests",
                newName: "IX_QuestionTests_QuestionId");

            migrationBuilder.CreateTable(
                name: "QuestionTest1",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    TestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTest1", x => new { x.QuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_QuestionTest1_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTest1_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTest1_TestsId",
                table: "QuestionTest1",
                column: "TestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTests_Questions_QuestionId",
                table: "QuestionTests",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTests_Tests_TestId",
                table: "QuestionTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTests_Questions_QuestionId",
                table: "QuestionTests");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTests_Tests_TestId",
                table: "QuestionTests");

            migrationBuilder.DropTable(
                name: "QuestionTest1");

            migrationBuilder.RenameTable(
                name: "QuestionTests",
                newName: "QUestionTests");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTests_TestId",
                table: "QUestionTests",
                newName: "IX_QUestionTests_TestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTests_QuestionId",
                table: "QUestionTests",
                newName: "IX_QUestionTests_QuestionId");

            migrationBuilder.CreateTable(
                name: "QuestionTest",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    TestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTest", x => new { x.QuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_QuestionTest_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTest_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTest_TestsId",
                table: "QuestionTest",
                column: "TestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QUestionTests_Questions_QuestionId",
                table: "QUestionTests",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QUestionTests_Tests_TestId",
                table: "QUestionTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
