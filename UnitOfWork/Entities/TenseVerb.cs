using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UstSoft.EnglishTraining.UnitOfWork.Interfaces;

namespace UstSoft.EnglishTraining.UnitOfWork.Entities
{
    public class TenseVerb : IIdentifiable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
