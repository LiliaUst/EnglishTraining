using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UstSoft.EnglishTraining.UnitOfWork.Migrations
{
    public partial class _1_insert_Verbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Verbs]
               ([IsIrregular]
               ,[InfinitiveEn]
               ,[InfinitiveRu])
         VALUES
               (1, N'write', N'писать'), (0, N'work', N'работать'), (1, N'wear', N'носить'), (0, N'watch', N'наблюдать'),
               (0, N'want', N'хотеть'), (0, N'walk', N'гулять'), (1, N'understand', N'понимать'), (0, N'turn', N'поворачивать'),
               (0, N'try', N'пробовать'), (0, N'travel', N'путешествовать'), (1, N'think', N'думать'), (1, N'tell', N'рассказывать'),
               (0, N'teach', N'обучать'), (0, N'talk', N'разговаривать'), (1, N'take', N'брать'), (0, N'study', N'изучать'),
               (0, N'stop', N'прекращать'), (0, N'start', N'начинать'), (1, N'stand', N'стоять'), (0, N'spell', N'произносить по буквам'),
               (1, N'sleep', N'спать'), (1, N'sit', N'сидеть'), (1, N'sing', N'петь'), (0, N'show', N'показывать'),
               (0, N'set', N'устанавливать'), (0, N'send', N'отправлять'), (1, N'see', N'видеть'), (1, N'say', N'говорить'),
               (1, N'run', N'бежать'), (0, N'remember', N'помнить'), (0, N'reckon', N'полагать'), (0, N'read', N'читать'),
               (0, N'reach', N'достигать'), (1, N'put', N'класть'), (0, N'produce', N'производить'), (0, N'play', N'играть'),
               (1, N'pay', N'платить'), (0, N'own', N'владеть'), (0, N'open', N'открывать'), (0, N'offer', N'предлагать'),
               (0, N'need', N'нуждаться'), (0, N'move', N'двигаться'), (1, N'mean', N'иметь в виду'), (0, N'mark', N'отмечать'),
               (1, N'make', N'создавать'), (0, N'look', N'смотреть'), (0, N'live', N'жить'), (0, N'listen', N'слушать'),
               (0, N'like', N'нравиться'), (1, N'lie', N'лежать'), (1, N'let', N'позволять'), (1, N'leave', N'оставлять'),
               (0, N'learn', N'учиться'), (1, N'lead', N'вести'), (1, N'know', N'знать'), (1, N'keep', N'хранить'),
               (0, N'inform', N'сообщать'), (0, N'increase', N'увеличиваться'), (0, N'help', N'помогать'), (1, N'hear', N'слышать'),
               (0, N'happen', N'случаться'), (0, N'guess', N'догадываться'), (1, N'grow', N'расти'), (1, N'go', N'идти'),
               (1, N'give', N'давать'), (1, N'get', N'получать'), (0, N'force', N'принуждать'), (0, N'follow', N'следовать'),
               (1, N'fly', N'летать'), (1, N'find', N'находить'), (0, N'fill', N'наполнять'), (1, N'fall', N'падать'),
               (1, N'eat', N'есть'), (1, N'draw', N'рисовать'), (1, N'do', N'делать'), (0, N'discuss', N'обсуждать'),
               (0, N'differ', N'отличаться'), (0, N'develop', N'развивать'), (0, N'decide', N'решать'), (1, N'cut', N'резать'),
               (0, N'cross', N'пересекать'), (0, N'cover', N'покрывать'), (1, N'come', N'приходить'), (0, N'close', N'закрывать'),
               (0, N'change', N'менять'), (0, N'carry', N'носить'), (0, N'call', N'звонить'), (1, N'build', N'строить'),
               (1, N'bring', N'приносить'), (0, N'believe', N'верить'), (1, N'begin', N'начинать'), (1, N'become', N'становиться'),
               (0, N'ask', N'спрашивать'), (0, N'answer', N'отвечать'), (0, N'agree', N'соглашаться'),
               (0, N'add', N'добавлять'), (0, N'act', N'действовать')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"delete from [dbo].[Verbs]");
        }
    }
}
