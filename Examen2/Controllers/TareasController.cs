using Microsoft.AspNetCore.Mvc;
using Examen2.Models;
using Examen2.Services;

namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]


public class TareasController : ControllerBase
{
    private readonly TareaService _tareaService;

    public TareasController(TareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tareas>>> ObtenerTareas()
    {
        var tareas = await _tareaService.ObtenerTareas();
        return Ok(tareas);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Tareas>> ObtenerTareaPorId(Guid Id)
    {
        var tarea = await _tareaService.ObtenerTareaPorId(Id);
        if (tarea == null) return NotFound("Tarea no encontrada");

        return Ok(tarea);
    }

    [HttpPost]
    public async Task<ActionResult> CrearTarea([FromBody] Tareas tarea)
    {
        if (tarea == null)
        {
            return BadRequest("Datos de la tarea vienen vacios");
        }
        var nuevaTarea = await _tareaService.CrearTarea(tarea);
        return Ok(nuevaTarea);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> ActualizarTarea(Guid Id, [FromBody] Tareas tareaActualizada)
    {
        if (tareaActualizada == null)
        {
            return BadRequest("Datos de la tarea vienen vacios");
        }

        var response = await _tareaService.ActualizarTarea(Id, tareaActualizada);

        if (response == false)
        {
            return NotFound("Tara no encontrada en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> EliminarTarea(Guid Id)
    {
        var response = await _tareaService.EliminarTarea(Id);
        if (response == false)
        {
            return NotFound("Tareao no encontrada en base de datos");
        }
        return NoContent();
    }

}
