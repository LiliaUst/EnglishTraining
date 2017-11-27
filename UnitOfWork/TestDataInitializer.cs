using System;
using System.Collections.Generic;
using System.Text;

namespace UstSoft.EnglishTraining.UnitOfWork
{
    public class TestDataInitializer
    {
        private readonly EnglishTrainingDbContext _englishTrainingDbContext;

        public TestDataInitializer(EnglishTrainingDbContext englishTrainingDbContext)
        {
            if (englishTrainingDbContext == null)
                throw new ArgumentNullException(nameof(englishTrainingDbContext));

            _englishTrainingDbContext = englishTrainingDbContext;
        }

        public void Initialize()
        {

        }
    }
}
