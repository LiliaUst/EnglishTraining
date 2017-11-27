﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using UstSoft.EnglishTraining.UnitOfWork;

namespace UstSoft.EnglishTraining.UnitOfWork.Migrations
{
    [DbContext(typeof(EnglishTrainingDbContext))]
    [Migration("20171127222736_1_insert_TenseVerbs_NumberVerbs_PersonVerbs")]
    partial class _1_insert_TenseVerbs_NumberVerbs_PersonVerbs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UstSoft.EnglishTraining.UnitOfWork.Entities.NumberVerb", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("NumberVerbs");
                });

            modelBuilder.Entity("UstSoft.EnglishTraining.UnitOfWork.Entities.PersonVerb", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("PersonVerbs");
                });

            modelBuilder.Entity("UstSoft.EnglishTraining.UnitOfWork.Entities.PersonVerbToVerb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InfinitiveEn")
                        .HasMaxLength(100);

                    b.Property<string>("InfinitiveRu")
                        .HasMaxLength(100);

                    b.Property<int>("NumberVerbId");

                    b.Property<int>("PersonVerbId");

                    b.Property<int>("TenseVerbId");

                    b.Property<int>("VerbId");

                    b.HasKey("Id");

                    b.HasIndex("NumberVerbId");

                    b.HasIndex("PersonVerbId");

                    b.HasIndex("TenseVerbId");

                    b.HasIndex("VerbId");

                    b.ToTable("PersonVerbsToVerbs");
                });

            modelBuilder.Entity("UstSoft.EnglishTraining.UnitOfWork.Entities.TenseVerb", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("TenseVerbs");
                });

            modelBuilder.Entity("UstSoft.EnglishTraining.UnitOfWork.Entities.Verb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("InfinitiveEn")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("InfinitiveRu")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsIrregular");

                    b.Property<string>("PastIndefinite")
                        .HasMaxLength(100);

                    b.Property<string>("PastParticiple")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Verbs");
                });

            modelBuilder.Entity("UstSoft.EnglishTraining.UnitOfWork.Entities.PersonVerbToVerb", b =>
                {
                    b.HasOne("UstSoft.EnglishTraining.UnitOfWork.Entities.NumberVerb", "NumberVerb")
                        .WithMany()
                        .HasForeignKey("NumberVerbId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UstSoft.EnglishTraining.UnitOfWork.Entities.PersonVerb", "PersonVerb")
                        .WithMany()
                        .HasForeignKey("PersonVerbId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UstSoft.EnglishTraining.UnitOfWork.Entities.TenseVerb", "TenseVerb")
                        .WithMany()
                        .HasForeignKey("TenseVerbId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UstSoft.EnglishTraining.UnitOfWork.Entities.Verb", "Verb")
                        .WithMany()
                        .HasForeignKey("VerbId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
