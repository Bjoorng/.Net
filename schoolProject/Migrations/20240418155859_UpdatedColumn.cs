using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace schoolProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Corsi_SubjectId",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Corsi",
                table: "Corsi");

            migrationBuilder.RenameTable(
                name: "Studenti",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Corsi",
                newName: "Subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Studenti_SubjectId",
                table: "Students",
                newName: "IX_Students_SubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subjects_SubjectId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Corsi");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Studenti");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Corsi",
                newName: "SubjectName");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SubjectId",
                table: "Studenti",
                newName: "IX_Studenti_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Corsi",
                table: "Corsi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studenti",
                table: "Studenti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Corsi_SubjectId",
                table: "Studenti",
                column: "SubjectId",
                principalTable: "Corsi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
