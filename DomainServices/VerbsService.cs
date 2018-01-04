using System.Linq;
using UstSoft.DataTransferObjects.Verbs;
using UstSoft.DomainServices.Interfaces;
using UstSoft.EnglishTraining.UnitOfWork.Entities;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.DomainServices
{
    public class VerbsService : UnitOfWorkService, IVerbsService
    {
        private readonly IRepository<Verb> _verbRepository;
        private readonly IRepository<PersonVerbToVerb> _personVerbToVerbRepository;

        public VerbsService(IUnitOfWork unitOfWork, 
            IRepository<Verb> verbRepository,
            IRepository<PersonVerbToVerb> personVerbToVerbRepository)
            : base (unitOfWork)
        {
            _verbRepository = verbRepository;
            _personVerbToVerbRepository = personVerbToVerbRepository;
        }

        public VerbDto[] GetVerbs()
        {
            var verbs = _verbRepository.GetAll().Select(CreateVerbDto).ToArray();

            
            return verbs;
        }

        public VerbSaveResult SaveVerb(VerbDto dto)
        {
            var result = new VerbSaveResult();
            if (!result.Success)
                return result;

            var verb = _verbRepository.GetSingle(x => x.Id == dto.Id);
            if (verb == null)
            {
                verb = new Verb();
                _verbRepository.Add(verb);
            }
            verb.InfinitiveEn = dto.InfinitiveEn;
            verb.InfinitiveRu = dto.InfinitiveRu;
            verb.IsIrregular = dto.IsIrregular;

            var personVerbToVerbs = _personVerbToVerbRepository.GetAll().Where(x => x.VerbId == verb.Id);

            
            foreach (var personVerbToVerb in personVerbToVerbs)
            {
                if (dto.PersonVerbToVerbs.Select(x => x.Id).All(x => x != personVerbToVerb.Id))
                    _personVerbToVerbRepository.Delete(personVerbToVerb);
            }

            foreach (var personVerbToVerbDto in dto.PersonVerbToVerbs)
            {
                var personVerbToVerb = personVerbToVerbs.FirstOrDefault(x => x.Id == personVerbToVerbDto.Id);
                if (personVerbToVerb == null)
                {
                    personVerbToVerb = new PersonVerbToVerb();
                    if (personVerbToVerbDto.Id.HasValue)
                        personVerbToVerb.Id = personVerbToVerbDto.Id.Value;
                    verb.PersonVerbToVerbs.Add(personVerbToVerb);
                }
                personVerbToVerb.VerbId = verb.Id;
                personVerbToVerb.PersonVerbId = personVerbToVerbDto.PersonVerbId;
                personVerbToVerb.NumberVerbId = personVerbToVerbDto.NumberVerbId;
                personVerbToVerb.TenseVerbId = personVerbToVerbDto.TenseVerbId;
                personVerbToVerb.VerbEn = personVerbToVerbDto.VerbEn;
                personVerbToVerb.VerbRu = personVerbToVerbDto.VerbRu;
            }

            UnitOfWork.SaveChanges();

            result.Id = verb.Id;

            return result;
        }

        private VerbDto CreateVerbDto(Verb entity)
        {
            if (entity == null)
                return null;

            var personVerbToVerbs = _personVerbToVerbRepository.GetAll().Where(x => x.VerbId == entity.Id);

            return new VerbDto
            {
                Id = entity.Id,
                InfinitiveEn = entity.InfinitiveEn,
                InfinitiveRu = entity.InfinitiveRu,
                IsIrregular = entity.IsIrregular,
                PersonVerbToVerbs = personVerbToVerbs.Select(x => new PersonVerbToVerbDto
                {
                    Id = x.Id,
                    NumberVerbId = x.NumberVerbId,
                    PersonVerbId = x.PersonVerbId,
                    TenseVerbId = x.TenseVerbId,
                    VerbEn = x.VerbEn,
                    VerbId = x.VerbId,
                    VerbRu = x.VerbRu
                }).ToArray(),
            };
        }
    }
}
