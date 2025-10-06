using System;
using System.ComponentModel.DataAnnotations;

namespace TareaTecWebGrupo12.Models
{
    public class Guest
    {
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string FullName { get; set; };
        public bool Confirmed { get; set; } = false;
    }
}