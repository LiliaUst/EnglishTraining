using System;
using System.Collections.Generic;
using System.Text;

namespace UstSoft.DataTransferObjects.Verbs
{
    public class VerbDto
    {
        public int Id { get; set; }
        public string InfinitiveEn { get; set; }
        public string InfinitiveRu { get; set; }
        public bool IsIrregular { get; set; } = false;
    }
}
