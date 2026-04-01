using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ProdutosApi;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAllAsync()
    {
        var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> GetByIdAsync(int id)
    {
        var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (produto is null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> CreateAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return StatusCode(201, produto);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        var existing = await _context.Produtos.FindAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        existing.Nome = produto.Nome;
        existing.Preco = produto.Preco;
        existing.Estoque = produto.Estoque;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}

