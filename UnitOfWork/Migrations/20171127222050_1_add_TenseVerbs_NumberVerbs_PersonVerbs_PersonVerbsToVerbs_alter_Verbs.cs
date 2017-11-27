using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UstSoft.EnglishTraining.UnitOfWork.Migrations
{
    public partial class _1_add_TenseVerbs_NumberVerbs_PersonVerbs_PersonVerbsToVerbs_alter_Verbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Infinitive",
                table: "Verbs",
                newName: "InfinitiveRu");

            migrationBuilder.AddColumn<string>(
                name: "InfinitiveEn",
                table: "Verbs",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NumberVerbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberVerbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonVerbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVerbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenseVerbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenseVerbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonVerbsToVerbs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InfinitiveEn = table.Column<string>(maxLength: 100, nullable: true),
                    InfinitiveRu = table.Column<string>(maxLength: 100, nullable: true),
                    NumberVerbId = table.Column<int>(nullable: false),
                    PersonVerbId = table.Column<int>(nullable: false),
                    TenseVerbId = table.Column<int>(nullable: false),
                    VerbId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVerbsToVerbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonVerbsToVerbs_NumberVerbs_NumberVerbId",
                        column: x => x.NumberVerbId,
                        principalTable: "NumberVerbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonVerbsToVerbs_PersonVerbs_PersonVerbId",
                        column: x => x.PersonVerbId,
                        principalTable: "PersonVerbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonVerbsToVerbs_TenseVerbs_TenseVerbId",
                        column: x => x.TenseVerbId,
                        principalTable: "TenseVerbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonVerbsToVerbs_Verbs_VerbId",
                        column: x => x.VerbId,
                        principalTable: "Verbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonVerbsToVerbs_NumberVerbId",
                table: "PersonVerbsToVerbs",
                column: "NumberVerbId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVerbsToVerbs_PersonVerbId",
                table: "PersonVerbsToVerbs",
                column: "PersonVerbId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVerbsToVerbs_TenseVerbId",
                table: "PersonVerbsToVerbs",
                column: "TenseVerbId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVerbsToVerbs_VerbId",
                table: "PersonVerbsToVerbs",
                column: "VerbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonVerbsToVerbs");

            migrationBuilder.DropTable(
                name: "NumberVerbs");

            migrationBuilder.DropTable(
                name: "PersonVerbs");

            migrationBuilder.DropTable(
                name: "TenseVerbs");

            migrationBuilder.DropColumn(
                name: "InfinitiveEn",
                table: "Verbs");

            migrationBuilder.RenameColumn(
                name: "InfinitiveRu",
                table: "Verbs",
                newName: "Infinitive");
        }
    }
}
