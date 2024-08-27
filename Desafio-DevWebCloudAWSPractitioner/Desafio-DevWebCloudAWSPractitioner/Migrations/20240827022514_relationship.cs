using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_DevWebCloudAWSPractitioner.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolInfos_SchoolInfosId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolInfosId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolInfosId",
                table: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "SchoolInfos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolInfos_StudentId",
                table: "SchoolInfos",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolInfos_Students_StudentId",
                table: "SchoolInfos",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolInfos_Students_StudentId",
                table: "SchoolInfos");

            migrationBuilder.DropIndex(
                name: "IX_SchoolInfos_StudentId",
                table: "SchoolInfos");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SchoolInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolInfosId",
                table: "Students",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolInfosId",
                table: "Students",
                column: "SchoolInfosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolInfos_SchoolInfosId",
                table: "Students",
                column: "SchoolInfosId",
                principalTable: "SchoolInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
