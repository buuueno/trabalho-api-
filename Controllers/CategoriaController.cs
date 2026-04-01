using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProdutosApi;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetAllAsync()
    {
        var categorias = await _context.Categorias.AsNoTracking().ToListAsync();
        return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "GetCategoria")]
    public async Task<ActionResult<Categoria>> GetByIdAsync(int id)
    {
        var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        if (categoria is null)
        {
            return NotFound();
        }

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> CreateAsync(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return CreatedAtRoute("GetCategoria", new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Categoria categoria)
    {
        if (id != categoria.Id)
        {
            return BadRequest();
        }

        var existing = await _context.Categorias.FindAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.Nome = categoria.Nome;
        existing.Descricao = categoria.Descricao;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
