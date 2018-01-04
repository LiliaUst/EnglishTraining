using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UstSoft.DomainServices.Interfaces;
using UstSoft.EnglishTraining.Web.ViewModel.Verbs;
using UstSoft.DataTransferObjects.Verbs;
using UstSoft.Enums;

namespace UstSoft.EnglishTraining.Controllers
{
    [Route("api/[controller]")]
    public class VerbsController : Controller
    {
        private readonly IVerbsService _verbsService;

        public VerbsController(IVerbsService verbsService)
        {
            _verbsService = verbsService;
        }

        [Route("saveVerb")]
        [HttpPost]
        public IActionResult SaveVerb([FromBody]VerbViewModel model)
        {
            var verbForms = new List<PersonVerbToVerbDto>();
            foreach (var (tense, verbForm) in model.VerbForms)
            {
                foreach (var (person, verbForm2) in verbForm)
                {
                    foreach (var (number, verbForm3) in verbForm2)
                    {
                        verbForms.Add(new PersonVerbToVerbDto
                        {
                            TenseVerbId = verbForm3.TenseVerbId,
                            PersonVerbId = verbForm3.PersonVerbId,
                            NumberVerbId = verbForm3.NumberVerbId,
                            Id = verbForm3.Id,
                            VerbId = verbForm3.VerbId,
                            VerbEn = verbForm3.VerbEn,
                            VerbRu = verbForm3.VerbRu,
                        });
                    }
                }
            }            
            var result = _verbsService.SaveVerb(new VerbDto
            {
                Id = model.Id,
                InfinitiveRu = model.InfinitiveRu,
                InfinitiveEn = model.InfinitiveEn,
                IsIrregular = model.IsIrregular,
                PersonVerbToVerbs = verbForms.ToArray(),
            });

            if (!result.Success)
            {
                return Json(result);
            }

            return Json(result);
        }

        [Route("getVerbs")]
        [HttpGet]
        public IActionResult GetVerbs()
        {
            return Json(_verbsService.GetVerbs().Select(dto => new VerbViewModel
            {
                Id = dto.Id,
                InfinitiveEn = dto.InfinitiveEn,
                InfinitiveRu = dto.InfinitiveRu,
                IsIrregular = dto.IsIrregular,
                IsFull = dto.PersonVerbToVerbs.Length != 0,
                VerbForms = CreateVerbForms(dto),
            }).ToList());
        }

        private (string verbEn, string verbRu) GetPersonVerb(PersonVerbToVerbDto[] personVerbDtos, TenseVerbs tenseVerbs, PersonVerbs personVerbs, NumberVerbs numberVerbs)
        {
            foreach(var personVerbDto in personVerbDtos)
            {
                if (personVerbDto.TenseVerbId == (int)tenseVerbs && personVerbDto.PersonVerbId == (int)personVerbs && personVerbDto.NumberVerbId == (int)numberVerbs)
                    return (verbEn: personVerbDto.VerbEn, verbRu: personVerbDto.VerbRu);
            }
            return (verbEn: "", verbRu: "");
        }
        private Dictionary<int, Dictionary<int, Dictionary<int, PersonVerbsToVerbsViewModel>>> CreateVerbForms(VerbDto dto)
        {
            var isFull = dto.PersonVerbToVerbs.Length != 0;

            var verbPresentSimpleSingular1 = GetPersonVerb(dto.PersonVerbToVerbs, TenseVerbs.PresentSimple, PersonVerbs.First, NumberVerbs.Singular);
            var verbPresentSimplePlural1 = GetPersonVerb(dto.PersonVerbToVerbs, TenseVerbs.PresentSimple, PersonVerbs.First, NumberVerbs.Plural);
            var verbPresentSimpleSingular2 = GetPersonVerb(dto.PersonVerbToVerbs, TenseVerbs.PresentSimple, PersonVerbs.Second, NumberVerbs.Singular);
            var verbPresentSimplePlural2= GetPersonVerb(dto.PersonVerbToVerbs, TenseVerbs.PresentSimple, PersonVerbs.Second, NumberVerbs.Plural);
            var verbPresentSimpleSingular3 = GetPersonVerb(dto.PersonVerbToVerbs, TenseVerbs.PresentSimple, PersonVerbs.Third, NumberVerbs.Singular);
            var verbPresentSimplePlural3= GetPersonVerb(dto.PersonVerbToVerbs, TenseVerbs.PresentSimple, PersonVerbs.Third, NumberVerbs.Plural);

            return new Dictionary<int, Dictionary<int, Dictionary<int, PersonVerbsToVerbsViewModel>>>
            {
                [(int)TenseVerbs.PresentSimple] = new Dictionary<int, Dictionary<int, PersonVerbsToVerbsViewModel>>
                {
                    [(int)PersonVerbs.First] = new Dictionary<int, PersonVerbsToVerbsViewModel>
                    {
                        [(int)NumberVerbs.Singular] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.First,
                            NumberVerbId = (int)NumberVerbs.Singular,
                            VerbId = dto.Id,
                            VerbEn = isFull ? verbPresentSimpleSingular1.verbEn : dto.InfinitiveEn,
                            VerbRu = isFull ? verbPresentSimpleSingular1.verbRu : dto.InfinitiveRu,
                        },
                        [(int)NumberVerbs.Plural] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.First,
                            NumberVerbId = (int)NumberVerbs.Plural,
                            VerbId = dto.Id,
                            VerbEn = isFull ? verbPresentSimplePlural1.verbEn : dto.InfinitiveEn,
                            VerbRu = isFull ? verbPresentSimplePlural1.verbRu : dto.InfinitiveRu,
                        },
                    },
                    [(int)PersonVerbs.Second] = new Dictionary<int, PersonVerbsToVerbsViewModel>
                    {
                        [(int)NumberVerbs.Singular] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.Second,
                            NumberVerbId = (int)NumberVerbs.Singular,
                            VerbId = dto.Id,
                            VerbEn = isFull ? verbPresentSimpleSingular2.verbEn : dto.InfinitiveEn,
                            VerbRu = isFull ? verbPresentSimpleSingular2.verbRu : dto.InfinitiveRu,
                        },
                        [(int)NumberVerbs.Plural] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.Second,
                            NumberVerbId = (int)NumberVerbs.Plural,
                            VerbId = dto.Id,
                            VerbEn = isFull ? verbPresentSimplePlural2.verbEn : dto.InfinitiveEn,
                            VerbRu = isFull ? verbPresentSimplePlural2.verbRu : dto.InfinitiveRu,
                        },
                    },
                    [(int)PersonVerbs.Third] = new Dictionary<int, PersonVerbsToVerbsViewModel>
                    {
                        [(int)NumberVerbs.Singular] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.Third,
                            NumberVerbId = (int)NumberVerbs.Singular,
                            VerbId = dto.Id,
                            VerbEn = isFull ? verbPresentSimpleSingular3.verbEn : dto.InfinitiveEn + "s",
                            VerbRu = isFull ? verbPresentSimpleSingular3.verbRu : dto.InfinitiveRu,
                        },
                        [(int)NumberVerbs.Plural] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.Third,
                            NumberVerbId = (int)NumberVerbs.Plural,
                            VerbId = dto.Id,
                            VerbEn = isFull ? verbPresentSimplePlural3.verbEn : dto.InfinitiveEn,
                            VerbRu = isFull ? verbPresentSimplePlural3.verbRu : dto.InfinitiveRu,
                        },
                    },
                }
            };
        }
    }
}
