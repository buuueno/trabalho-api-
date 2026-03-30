using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TarefasApi;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly AppDbContext _context;

    public TarefaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> GetAllAsync()
    {
        var tarefas = await _context.Tarefas.AsNoTracking().ToListAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id:int}", Name = "GetTarefaByID")]
    public async Task<ActionResult<Tarefa>> GetByIdAsync(int id)
    {
        var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        if (tarefa is null)
        {
            return NotFound();
        }

        return Ok(tarefa);
    }
}

