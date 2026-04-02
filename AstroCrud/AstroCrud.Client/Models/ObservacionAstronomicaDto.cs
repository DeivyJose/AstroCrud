using System.ComponentModel.DataAnnotations;

namespace AstroCrud.Client.Models
{
    public class ObservacionAstronomicaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El objeto celeste es obligatorio.")]
        [StringLength(100)]
        public string ObjetoCeleste { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime FechaObservacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La ubicación es obligatoria.")]
        [StringLength(100)]
        public string Ubicacion { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        [StringLength(100)]
        public string? TelescopioUsado { get; set; }

        public bool EsVisible { get; set; }
    }
}