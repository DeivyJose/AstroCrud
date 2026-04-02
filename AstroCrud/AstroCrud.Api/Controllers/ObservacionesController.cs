using AstroCrud.Api.Dtos;
using AstroCrud.Api.Interfaces;
using AstroCrud.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AstroCrud.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservacionesController : ControllerBase
    {
        private readonly IObservacionRepository _repository;

        public ObservacionesController(IObservacionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObservacionAstronomicaReadDto>>> GetAll()
        {
            var observaciones = await _repository.GetAllAsync();

            var resultado = observaciones.Select(o => new ObservacionAstronomicaReadDto
            {
                Id = o.Id,
                Titulo = o.Titulo,
                ObjetoCeleste = o.ObjetoCeleste,
                FechaObservacion = o.FechaObservacion,
                Ubicacion = o.Ubicacion,
                Descripcion = o.Descripcion,
                TelescopioUsado = o.TelescopioUsado,
                EsVisible = o.EsVisible
            });

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObservacionAstronomicaReadDto>> GetById(int id)
        {
            var o = await _repository.GetByIdAsync(id);

            if (o is null)
                return NotFound(new { mensaje = "Observación no encontrada." });

            var dto = new ObservacionAstronomicaReadDto
            {
                Id = o.Id,
                Titulo = o.Titulo,
                ObjetoCeleste = o.ObjetoCeleste,
                FechaObservacion = o.FechaObservacion,
                Ubicacion = o.Ubicacion,
                Descripcion = o.Descripcion,
                TelescopioUsado = o.TelescopioUsado,
                EsVisible = o.EsVisible
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ObservacionAstronomicaReadDto>> Create(ObservacionAstronomicaCreateDto dto)
        {
            var observacion = new ObservacionAstronomica
            {
                Titulo = dto.Titulo,
                ObjetoCeleste = dto.ObjetoCeleste,
                FechaObservacion = dto.FechaObservacion,
                Ubicacion = dto.Ubicacion,
                Descripcion = dto.Descripcion,
                TelescopioUsado = dto.TelescopioUsado,
                EsVisible = dto.EsVisible
            };

            await _repository.CreateAsync(observacion);

            var readDto = new ObservacionAstronomicaReadDto
            {
                Id = observacion.Id,
                Titulo = observacion.Titulo,
                ObjetoCeleste = observacion.ObjetoCeleste,
                FechaObservacion = observacion.FechaObservacion,
                Ubicacion = observacion.Ubicacion,
                Descripcion = observacion.Descripcion,
                TelescopioUsado = observacion.TelescopioUsado,
                EsVisible = observacion.EsVisible
            };

            return CreatedAtAction(nameof(GetById), new { id = observacion.Id }, readDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ObservacionAstronomicaUpdateDto dto)
        {
            var observacion = new ObservacionAstronomica
            {
                Id = id,
                Titulo = dto.Titulo,
                ObjetoCeleste = dto.ObjetoCeleste,
                FechaObservacion = dto.FechaObservacion,
                Ubicacion = dto.Ubicacion,
                Descripcion = dto.Descripcion,
                TelescopioUsado = dto.TelescopioUsado,
                EsVisible = dto.EsVisible
            };

            var actualizado = await _repository.UpdateAsync(observacion);

            if (!actualizado)
                return NotFound(new { mensaje = "Observación no encontrada." });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _repository.DeleteAsync(id);

            if (!eliminado)
                return NotFound(new { mensaje = "Observación no encontrada." });

            return NoContent();
        }
    }
}