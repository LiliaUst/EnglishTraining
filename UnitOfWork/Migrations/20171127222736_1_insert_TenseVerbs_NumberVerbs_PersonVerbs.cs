using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UstSoft.EnglishTraining.UnitOfWork.Migrations
{
    public partial class _1_insert_TenseVerbs_NumberVerbs_PersonVerbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[NumberVerbs] ([Id], [Name])
                VALUES (1, N'singular'), (2, N'plural')
	
                INSERT INTO [dbo].[TenseVerbs] ([Id], [Name])
                VALUES (1, N'Present Simple')

                INSERT INTO [dbo].[PersonVerbs] ([Id], [Name])
                VALUES (1, N'first'), (2, N'second'), (3, N'third')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from [dbo].[NumberVerbs] where Id in (1, 2)
                delete from [dbo].[TenseVerbs] where Id in (1)
                delete from [dbo].[PersonVerbs] where Id in (1, 2, 3)");
        }
    }
}
