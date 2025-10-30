using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models;

public class Reserva
{
    public int Id { get; set; }

    [Required]
    public int ClienteId { get; set; }

    // 👇 esta linha liga a Reserva ao Cliente (propriedade de navegação)
    public Cliente? Cliente { get; set; }

    [Required, MaxLength(20)]
    public string QuartoNumero { get; set; } = default!;

    [Required]
    public DateTime CheckIn { get; set; }

    [Required]
    public DateTime CheckOut { get; set; }

    [MaxLength(500)]
    public string? Observacoes { get; set; }
}

