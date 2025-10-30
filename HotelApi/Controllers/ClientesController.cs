using HotelApi.Data;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly HotelContext _db;
    public ClientesController(HotelContext db) => _db = db;

    // GET: api/clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        => await _db.Clientes.AsNoTracking().ToListAsync();

    // GET: api/clientes/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> GetById(int id)
    {
        var cliente = await _db.Clientes.FindAsync(id);
        if (cliente is null)
            return NotFound();
        return cliente;
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente input)
    {
        _db.Clientes.Add(input);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
    }

    // PUT: api/clientes/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Cliente input)
    {
        if (id != input.Id)
            return BadRequest("Id no corpo diferente do da URL.");

        var existe = await _db.Clientes.AnyAsync(c => c.Id == id);
        if (!existe)
            return NotFound();

        _db.Entry(input).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/clientes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _db.Clientes.FindAsync(id);
        if (cliente is null)
            return NotFound();

        _db.Clientes.Remove(cliente);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
