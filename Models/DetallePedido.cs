using System.ComponentModel.DataAnnotations;

namespace MercanciasJyC.Models
{
    public class DetallePedido
    {
        [Key]
        public int DetalleID { get; set; }

        [Required(ErrorMessage = "El PedidoID es obligatorio.")]
        public int PedidoID { get; set; }

        [Required(ErrorMessage = "El ProductoID es obligatorio.")]
        public int ProductoID { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }

        public required Pedido Pedido { get; set; }
        public required Producto Producto { get; set; }
    }
}
