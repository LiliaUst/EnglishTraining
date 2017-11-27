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
        public string Infinitive { get; set; }
        public bool IsIrregular { get; set; } = false;
        [StringLength(100)]
        public string PastIndefinite { get; set; }
        [StringLength(100)]
        public string PastParticiple { get; set; }
    }
}
