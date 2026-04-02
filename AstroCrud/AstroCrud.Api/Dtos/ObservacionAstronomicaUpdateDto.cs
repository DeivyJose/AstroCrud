using System.ComponentModel.DataAnnotations;

namespace AstroCrud.Api.Dtos
{
    public class ObservacionAstronomicaUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ObjetoCeleste { get; set; } = string.Empty;

        [Required]
        public DateTime FechaObservacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ubicacion { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? Descripcion { get; set; }

        [MaxLength(100)]
        public string? TelescopioUsado { get; set; }

        public bool EsVisible { get; set; }
    }
}