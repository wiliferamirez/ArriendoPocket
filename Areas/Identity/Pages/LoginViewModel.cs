using System.ComponentModel.DataAnnotations;

namespace ArriendoPocket.Areas.Identity.Pages
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo Obligatorio")]
        [EmailAddress(ErrorMessage = "Correo Invalido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }
}
