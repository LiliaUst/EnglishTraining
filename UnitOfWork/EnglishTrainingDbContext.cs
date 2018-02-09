using Microsoft.EntityFrameworkCore;
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
        public DbSet<TenseVerb> TenseVerbs { get; set; }
        public DbSet<NumberVerb> NumberVerbs { get; set; }
        public DbSet<PersonVerb> PersonVerbs { get; set; }
        public DbSet<PersonVerbToVerb> PersonVerbsToVerbs { get; set; }
    }
}
