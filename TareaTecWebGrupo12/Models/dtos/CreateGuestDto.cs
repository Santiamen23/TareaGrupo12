using System.ComponentModel.DataAnnotations;

namespace TareaTecWebGrupo12.Models.dtos
{
    public record CreateGuestDto
    {
        [Required, StringLength(200)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public bool Confirmed { get; set; }
    }
}