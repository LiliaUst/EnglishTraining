using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.EnglishTraining.UnitOfWork.Entities
{
    public class PersonVerbToVerb : IIdentifiable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int VerbId { get; set; }
        [ForeignKey("VerbId")]
        public virtual Verb Verb { get; set; }
        public int PersonVerbId { get; set; }
        [ForeignKey("PersonVerbId")]
        public virtual PersonVerb PersonVerb { get; set; }
        public int NumberVerbId { get; set; }
        [ForeignKey("NumberVerbId")]
        public virtual NumberVerb NumberVerb { get; set; }
        public int TenseVerbId { get; set; }
        [ForeignKey("TenseVerbId")]
        public virtual TenseVerb TenseVerb { get; set; }
        [StringLength(100)]
        public string VerbEn { get; set; }
        [StringLength(100)]
        public string VerbRu { get; set; }
    }
}
