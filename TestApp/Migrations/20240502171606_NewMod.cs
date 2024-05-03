using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class NewMod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestion_Answers_AnswersId",
                table: "AnswerQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestion_Questions_QuestionsId",
                table: "AnswerQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerQuestion",
                table: "AnswerQuestion");

            migrationBuilder.RenameTable(
                name: "AnswerQuestion",
                newName: "AnswerQuestions");

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
                name: "QUestionTests",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_QUestionTests_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QUestionTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestions_AnswerId",
                table: "AnswerQuestions",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion1_QuestionsId",
                table: "AnswerQuestion1",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_QUestionTests_QuestionId",
                table: "QUestionTests",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QUestionTests_TestId",
                table: "QUestionTests",
                column: "TestId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestions_Answers_AnswerId",
                table: "AnswerQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestions_Questions_QuestionId",
                table: "AnswerQuestions");

            migrationBuilder.DropTable(
                name: "AnswerQuestion1");

            migrationBuilder.DropTable(
                name: "QUestionTests");

            migrationBuilder.DropIndex(
                name: "IX_AnswerQuestions_AnswerId",
                table: "AnswerQuestions");

            migrationBuilder.RenameTable(
                name: "AnswerQuestions",
                newName: "AnswerQuestion");

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
        }
    }
}
