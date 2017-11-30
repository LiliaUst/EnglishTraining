using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UstSoft.EnglishTraining.Web.ViewModel;
using UstSoft.DomainServices.Interfaces;

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
            }).ToList());
        }
    }
}
