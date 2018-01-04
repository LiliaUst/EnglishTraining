using System;
using System.Collections.Generic;
using System.Text;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.DomainServices
{
    public abstract class UnitOfWorkService
    {
        protected IUnitOfWork UnitOfWork;

        protected UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }
    }
}
