using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string Nome { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Descricao { get; set; }
}
