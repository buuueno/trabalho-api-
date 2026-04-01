using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProdutosApi;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClienteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAllAsync()
    {
        var clientes = await _context.Clientes.AsNoTracking().ToListAsync();
        return Ok(clientes);
    }

    [HttpGet("{id:int}", Name = "GetCliente")]
    public async Task<ActionResult<Cliente>> GetByIdAsync(int id)
    {
        var cliente = await _context.Clientes.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        if (cliente is null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> CreateAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetCliente", new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }

        var existing = await _context.Clientes.FindAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.Nome = cliente.Nome;
        existing.Email = cliente.Email;
        existing.Idade = cliente.Idade;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
