using HotelApi.Data;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly HotelContext _db;
    public ReservasController(HotelContext db) => _db = db;

    // GET: api/reservas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> GetAll()
        => await _db.Reservas
                    .Include(r => r.Cliente)
                    .AsNoTracking()
                    .ToListAsync();

    // GET: api/reservas/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Reserva>> GetById(int id)
    {
        var reserva = await _db.Reservas
                               .Include(r => r.Cliente)
                               .AsNoTracking()
                               .FirstOrDefaultAsync(r => r.Id == id);

        if (reserva is null)
            return NotFound();

        return reserva;
    }

    // POST: api/reservas
    [HttpPost]
    public async Task<ActionResult<Reserva>> Create(Reserva input)
    {
        // Validar datas
        if (input.CheckOut <= input.CheckIn)
            return BadRequest("Check-out deve ser depois do check-in.");

        // Validar cliente existente
        var existeCliente = await _db.Clientes.AnyAsync(c => c.Id == input.ClienteId);
        if (!existeCliente)
            return BadRequest("ClienteId inválido.");

        _db.Reservas.Add(input);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
    }

    // PUT: api/reservas/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Reserva input)
    {
        if (id != input.Id)
            return BadRequest("Id no corpo diferente do da URL.");

        if (input.CheckOut <= input.CheckIn)
            return BadRequest("Check-out deve ser depois do check-in.");

        var existe = await _db.Reservas.AnyAsync(r => r.Id == id);
        if (!existe)
            return NotFound();

        var existeCliente = await _db.Clientes.AnyAsync(c => c.Id == input.ClienteId);
        if (!existeCliente)
            return BadRequest("ClienteId inválido.");

        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/reservas/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reserva = await _db.Reservas.FindAsync(id);
        if (reserva is null)
            return NotFound();

        _db.Reservas.Remove(reserva);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
