using System.ComponentModel.DataAnnotations;

namespace MercanciasJyC.Models
{
    public class Entrega
    {
        public int EntregaID { get; set; }

        [Required(ErrorMessage = "El PedidoID es obligatorio.")]
        public int PedidoID { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "El estado de la entrega es obligatorio.")]
        [MaxLength(50)]
        public string? EstadoEntrega { get; set; }

        public required Pedido Pedido { get; set; }
    }
}
