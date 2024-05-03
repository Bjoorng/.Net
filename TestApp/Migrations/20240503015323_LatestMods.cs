using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class LatestMods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestions_Answers_AnswerId",
                table: "AnswerQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestions_Questions_QuestionId",
                table: "AnswerQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTests_Questions_QuestionId",
                table: "QuestionTests");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTests_Tests_TestId",
                table: "QuestionTests");

            migrationBuilder.DropTable(
                name: "AnswerQuestion1");

            migrationBuilder.DropTable(
                name: "QuestionTest1");

            migrationBuilder.DropIndex(
                name: "IX_QuestionTests_QuestionId",
                table: "QuestionTests");

            migrationBuilder.DropIndex(
                name: "IX_AnswerQuestions_AnswerId",
                table: "AnswerQuestions");

            migrationBuilder.RenameTable(
                name: "QuestionTests",
                newName: "QuestionTest");

            migrationBuilder.RenameTable(
                name: "AnswerQuestions",
                newName: "AnswerQuestion");

            migrationBuilder.RenameColumn(
                name: "TestId",
                table: "QuestionTest",
                newName: "TestsId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "QuestionTest",
                newName: "QuestionsId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTests_TestId",
                table: "QuestionTest",
                newName: "IX_QuestionTest_TestsId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "AnswerQuestion",
                newName: "QuestionsId");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "AnswerQuestion",
                newName: "AnswersId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerQuestions_QuestionId",
                table: "AnswerQuestion",
                newName: "IX_AnswerQuestion_QuestionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionTest",
                table: "QuestionTest",
                columns: new[] { "QuestionsId", "TestsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerQuestion",
                table: "AnswerQuestion",
                columns: new[] { "AnswersId", "QuestionsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestion_Answers_AnswersId",
                table: "AnswerQuestion",
                column: "AnswersId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestion_Questions_QuestionsId",
                table: "AnswerQuestion",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTest_Questions_QuestionsId",
                table: "QuestionTest",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTest_Tests_TestsId",
                table: "QuestionTest",
                column: "TestsId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestion_Answers_AnswersId",
                table: "AnswerQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestion_Questions_QuestionsId",
                table: "AnswerQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTest_Questions_QuestionsId",
                table: "QuestionTest");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTest_Tests_TestsId",
                table: "QuestionTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionTest",
                table: "QuestionTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerQuestion",
                table: "AnswerQuestion");

            migrationBuilder.RenameTable(
                name: "QuestionTest",
                newName: "QuestionTests");

            migrationBuilder.RenameTable(
                name: "AnswerQuestion",
                newName: "AnswerQuestions");

            migrationBuilder.RenameColumn(
                name: "TestsId",
                table: "QuestionTests",
                newName: "TestId");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "QuestionTests",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTest_TestsId",
                table: "QuestionTests",
                newName: "IX_QuestionTests_TestId");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "AnswerQuestions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "AnswersId",
                table: "AnswerQuestions",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerQuestion_QuestionsId",
                table: "AnswerQuestions",
                newName: "IX_AnswerQuestions_QuestionId");

            migrationBuilder.CreateTable(
                name: "AnswerQuestion1",
                columns: table => new
                {
                    AnswersId = table.Column<int>(type: "int", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestion1", x => new { x.AnswersId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_AnswerQuestion1_Answers_AnswersId",
                        column: x => x.AnswersId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion1_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_QuestionTests_QuestionId",
                table: "QuestionTests",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestions_AnswerId",
                table: "AnswerQuestions",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion1_QuestionsId",
                table: "AnswerQuestion1",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTest1_TestsId",
                table: "QuestionTest1",
                column: "TestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestions_Answers_AnswerId",
                table: "AnswerQuestions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestions_Questions_QuestionId",
                table: "AnswerQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
