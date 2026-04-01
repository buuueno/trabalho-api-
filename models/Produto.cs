using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório.")]
    [StringLength(120, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 120 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "Estoque é obrigatório.")]
    [Range(0, int.MaxValue, ErrorMessage = "Estoque não pode ser negativo.")]
    public int Estoque { get; set; }
}
