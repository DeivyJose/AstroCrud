namespace AstroCrud.Api.Dtos
{
    public class ObservacionAstronomicaReadDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string ObjetoCeleste { get; set; } = string.Empty;
        public DateTime FechaObservacion { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? TelescopioUsado { get; set; }
        public bool EsVisible { get; set; }
    }
}