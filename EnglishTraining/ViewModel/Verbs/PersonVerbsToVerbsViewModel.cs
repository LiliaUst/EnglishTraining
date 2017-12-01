using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstSoft.EnglishTraining.Web.ViewModel.Verbs
{
    public class PersonVerbsToVerbsViewModel
    {
        public int Id { get; set; }
        public int VerbId { get; set; }
        public int PersonVerbId { get; set; }
        public int NumberVerbId { get; set; }
        public int TenseVerbId { get; set; }
        public string VerbEn { get; set; }
        public string VerbRu { get; set; }
    }
}
