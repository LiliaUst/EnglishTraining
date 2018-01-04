using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.EnglishTraining.UnitOfWork.Entities
{
    public class Verb : IIdentifiable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string InfinitiveEn { get; set; }
        [Required]
        [StringLength(100)]
        public string InfinitiveRu { get; set; }
        public bool IsIrregular { get; set; } = false;

        public virtual ICollection<PersonVerbToVerb> PersonVerbToVerbs { get; set; } = new HashSet<PersonVerbToVerb>();
    }
}
