namespace TarefasApi;

public class Tarefa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
