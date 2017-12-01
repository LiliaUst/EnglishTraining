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
                IsFull = false,
                VerbForms = CreateVerbForms(dto),
            }).ToList());
        }

        private Dictionary<int, Dictionary<int, Dictionary<int, PersonVerbsToVerbsViewModel>>> CreateVerbForms(VerbDto dto)
        {
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
                            VerbEn = dto.InfinitiveEn,
                            VerbRu = dto.InfinitiveRu,
                        },
                        [(int)NumberVerbs.Plural] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.First,
                            NumberVerbId = (int)NumberVerbs.Plural,
                            VerbId = dto.Id,
                            VerbEn = dto.InfinitiveEn,
                            VerbRu = dto.InfinitiveRu,
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
                            VerbEn = dto.InfinitiveEn,
                            VerbRu = dto.InfinitiveRu,
                        },
                        [(int)NumberVerbs.Plural] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.Second,
                            NumberVerbId = (int)NumberVerbs.Plural,
                            VerbId = dto.Id,
                            VerbEn = dto.InfinitiveEn,
                            VerbRu = dto.InfinitiveRu,
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
                            VerbEn = dto.InfinitiveEn + "s",
                            VerbRu = dto.InfinitiveRu,
                        },
                        [(int)NumberVerbs.Plural] = new PersonVerbsToVerbsViewModel
                        {
                            TenseVerbId = (int)TenseVerbs.PresentSimple,
                            PersonVerbId = (int)PersonVerbs.Third,
                            NumberVerbId = (int)NumberVerbs.Plural,
                            VerbId = dto.Id,
                            VerbEn = dto.InfinitiveEn,
                            VerbRu = dto.InfinitiveRu,
                        },
                    },
                }
            };
        }
    }
}
