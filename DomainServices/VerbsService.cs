using System;
using System.Collections.Generic;
using System.Linq;
using UstSoft.DataTransferObjects.Verbs;
using UstSoft.DomainServices.Interfaces;
using UstSoft.EnglishTraining.UnitOfWork.Entities;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.DomainServices
{
    public class VerbsService : IVerbsService
    {
        private readonly IRepository<Verb> _verbRepository;

        public VerbsService(IRepository<Verb> verbRepository)
        {
            _verbRepository = verbRepository;
        }

        public VerbDto[] GetVerbs()
        {
            return _verbRepository.GetAll().Select(CreateVerbDto).ToArray();
        }

        private VerbDto CreateVerbDto(Verb entity)
        {
            return entity == null ? null : new VerbDto
            {
                Id = entity.Id,
                InfinitiveEn = entity.InfinitiveEn,
                InfinitiveRu = entity.InfinitiveRu,
                IsIrregular = entity.IsIrregular,
            };
        }
    }
}
