using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Nome { get; set; } = default!;

    [EmailAddress, MaxLength(200)]
    public string? Email { get; set; }

    [MaxLength(30)]
    public string? Telefone { get; set; }
}
