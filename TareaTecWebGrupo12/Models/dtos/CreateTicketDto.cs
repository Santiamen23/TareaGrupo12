using System.ComponentModel.DataAnnotations;

namespace TareaTecWebGrupo12.Models.dtos
{
    public record CreateTicketDto
    {
        [Required, StringLength(200)]
        public string[] Notes { get; set; }
    }
}
