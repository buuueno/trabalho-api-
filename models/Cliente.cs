using System.ComponentModel.DataAnnotations;

namespace ProdutosApi;

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Range(18, int.MaxValue)]
    public int Idade { get; set; }
}
