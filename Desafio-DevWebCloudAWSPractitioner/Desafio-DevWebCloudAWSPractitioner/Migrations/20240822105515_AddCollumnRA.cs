﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_DevWebCloudAWSPractitioner.Migrations
{
    /// <inheritdoc />
    public partial class AddCollumnRA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Students",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Students");
        }
    }
}
