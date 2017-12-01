using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstSoft.EnglishTraining.Web.ViewModel.Verbs
{
    public class VerbViewModel
    {
        public VerbViewModel()
        {
            VerbForms = new Dictionary<int, Dictionary<int, Dictionary<int, PersonVerbsToVerbsViewModel>>>();
        }
        public int Id { get; set; }
        public string InfinitiveEn { get; set; }
        public string InfinitiveRu { get; set; }
        public bool IsIrregular { get; set; }
        public bool IsFull { get; set; }

        public Dictionary<int, Dictionary<int, Dictionary<int, PersonVerbsToVerbsViewModel>>> VerbForms { get; set; }
    }
}
