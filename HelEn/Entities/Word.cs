using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelEn.Entities
{
    [Table("tblWords")]
    public class Word
    {
        [Key]
        public int IdWord { get; set; }
        [Required, StringLength(120)]
        public string Name { get; set; }
    }
}
