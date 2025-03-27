using Examen2.Data;
using Examen2.Models;
using Microsoft.EntityFrameworkCore;


namespace Examen2.Services;

public class TareaService
{
    private readonly DataContext _context;

    public TareaService(DataContext context)
    {
        _context = context;
    }

    //obtener todas las usuarios
    public async Task<List<Tareas>> ObtenerTareas()
    {
        return await _context.Tareas.ToListAsync();
    }

    //obtener una tarea por id
    public async Task<Tareas?> ObtenerTareaPorId(Guid id)
    {
        return await _context.Tareas.FirstOrDefaultAsync(u => u.Id == id);
    }

    //crear una tarea 
    public async Task<Tareas> CrearTarea(Tareas tarea)
    {
        tarea.Id = Guid.NewGuid();

        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();

        return tarea;
    }

    //actualizar una Tarea
    public async Task<bool> ActualizarTarea(Guid id, Tareas tareaActualizado)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return false;

        tarea.Title = tareaActualizado.Title;
        tarea.Description = tareaActualizado.Description;


        await _context.SaveChangesAsync();
        return true;
    }

    //eliminar una tarea
    public async Task<bool> EliminarTarea(Guid id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return false;

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();
        return true;
    }
}
