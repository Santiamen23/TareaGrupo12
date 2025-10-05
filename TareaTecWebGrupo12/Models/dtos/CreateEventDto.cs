using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateEventDto
    {
        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}