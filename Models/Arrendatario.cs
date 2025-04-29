using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ArriendoPocket.Models
{
    public class Arrendatario : IdentityUser
    {
        [Key]
        public int ArrendatarioID { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MaxLength (10, ErrorMessage = "Cedula Invalida")]
        [DisplayName("Cedula")]
        public string CedulaArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Nombre")]
        public string NombreArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Apellido")]
        public string ApellidoArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [EmailAddress(ErrorMessage ="Correo invalido")]
        [DisplayName("Correo Electronico")]
        public string CorreoArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Phone(ErrorMessage ="Numero Telefonico Invalido")]
        [DisplayName("Numero Telefonico")]
        public string TelefonoArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Fecha de Nacimiento")]
        public DateOnly FechaNacimientoArrendatario { get; set; }

        [DisplayName("Fecha de Registro")]
        public DateTime FechaRegistroArrendatario { get; set; } = DateTime.Now;

    }
}
