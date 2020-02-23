using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelEn.Entities
{
    [Table("tblUsers")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Email { get; set; }
        [Required, StringLength(200)]
        public string Login { get; set; }
        [Required, StringLength(200)]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public virtual UserExtraInfo UserExtraInfo { get; set; }
    }
}
