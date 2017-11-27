﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UstSoft.EnglishTraining.UnitOfWork.Entities;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;


namespace UstSoft.EnglishTraining.UnitOfWork
{
    public class EnglishTrainingDbContext : DbContext, IUnitOfWork
    {
        public EnglishTrainingDbContext(DbContextOptions<EnglishTrainingDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=OneMove;Integrated Security=True;MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }

        void IUnitOfWork.SaveChanges()
        {
            SaveChanges();
        }

        async Task<int> IUnitOfWork.SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }

        public void Initialize()
        {
            Database.Migrate();
        }

        public DbSet<Verb> Verbs { get; set; }
    }
}