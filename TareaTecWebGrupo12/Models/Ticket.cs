using System.ComponentModel.DataAnnotations;

namespace TareaTecWebGrupo12.Models
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(200)]
        public string[] Notes { get; set; }
        
    }

    public record CreateTicketDto
    {
        [Required,StringLength(200)]
        public string[] Notes { get; set; }
    }
}
