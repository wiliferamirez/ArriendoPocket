using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ArriendoPocket.Areas.Identity.Pages
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MaxLength(10, ErrorMessage = "Cedula Invalida")]
        [DisplayName("Cedula")]
        public string CedulaArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Nombre")]
        public string NombreArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Apellido")]
        public string ApellidoArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        [DisplayName("Correo Electronico")]
        public string CorreoArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Phone(ErrorMessage = "Numero Telefonico Invalido")]
        [DisplayName("Numero Telefonico")]
        public string TelefonoArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Fecha de Nacimiento")]
        public DateOnly FechaNacimientoArrendatario { get; set; }

        [Required(ErrorMessage = "Contrasena es Obligatoria")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} characters long " )]
        [DataType(DataType.Password)]
        [Compare("ConfirmarContrasena", ErrorMessage = "Las contrasnas no coinciden")]
        public string Contrasena { get; set; }

        [Required (ErrorMessage = "Confirma la contrasena")]
        [DataType(DataType.Password)]
        public string ConfirmarContrasena { get; set; }
    }
}
