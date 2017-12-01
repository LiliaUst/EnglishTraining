using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UstSoft.EnglishTraining.UnitOfWork.Migrations
{
    public partial class _7_alter_PersonVerbToVerb_alter_Verb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InfinitiveRu",
                table: "PersonVerbsToVerbs",
                newName: "VerbRu");

            migrationBuilder.RenameColumn(
                name: "InfinitiveEn",
                table: "PersonVerbsToVerbs",
                newName: "VerbEn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerbRu",
                table: "PersonVerbsToVerbs",
                newName: "InfinitiveRu");

            migrationBuilder.RenameColumn(
                name: "VerbEn",
                table: "PersonVerbsToVerbs",
                newName: "InfinitiveEn");
        }
    }
}
