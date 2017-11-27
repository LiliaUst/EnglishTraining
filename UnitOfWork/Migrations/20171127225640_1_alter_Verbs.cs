using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UstSoft.EnglishTraining.UnitOfWork.Migrations
{
    public partial class _1_alter_Verbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PastIndefinite",
                table: "Verbs");

            migrationBuilder.DropColumn(
                name: "PastParticiple",
                table: "Verbs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PastIndefinite",
                table: "Verbs",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PastParticiple",
                table: "Verbs",
                maxLength: 100,
                nullable: true);
        }
    }
}
