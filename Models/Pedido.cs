using System.ComponentModel.DataAnnotations;

namespace MercanciasJyC.Models
{

    public class Pedido
    {
        public int PedidoID { get; set; }

        [Required(ErrorMessage = "El ClienteID es obligatorio.")]
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "El estado del pedido es obligatorio.")]
        [MaxLength(50)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que 0.")]
        public decimal Total { get; set; }

        // Relación uno a muchos: Un pedido puede tener varios detalles
        public ICollection<DetallePedido> DetallePedidos { get; set; }

        // Relación uno a uno con Entrega
        public Entrega Entrega { get; set; }

        public Cliente Cliente { get; set; }
    }
}
