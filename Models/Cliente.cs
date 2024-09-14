using System.ComponentModel.DataAnnotations;

namespace MercanciasJyC.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public  string Nombre { get; set; }

        [MaxLength(200)]
        public  string Dirección { get; set; }


        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [MaxLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres.")]
        public  string Teléfono { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido.")]
        public  string Email { get; set; }

        // Relación uno a muchos: Un cliente tiene muchos pedidos
        public  ICollection<Pedido> Pedidos { get; set; }
    }
}
