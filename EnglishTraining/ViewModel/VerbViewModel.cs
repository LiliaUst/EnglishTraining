using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstSoft.EnglishTraining.Web.ViewModel
{
    public class VerbViewModel
    {
        public int Id { get; set; }
        public string InfinitiveEn { get; set; }
        public string InfinitiveRu { get; set; }
        public bool IsIrregular { get; set; }
    }
}
