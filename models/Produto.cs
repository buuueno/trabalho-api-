using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Produto
{
    public int Id { get; set; }

    [Required]
    [StringLength(120, MinimumLength = 3)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Preco { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Estoque { get; set; }
}
