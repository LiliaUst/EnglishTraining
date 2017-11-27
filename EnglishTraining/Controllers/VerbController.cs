using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTraining.Controllers
{
    [Route("api/[controller]")]
    public class VerbController : Controller
    {
        [Route("getVerbs/{searchString}")]
        [HttpGet]
        public IActionResult GetVerbs(string searchString)
        {
            return Json(true);
        }
    }
}
