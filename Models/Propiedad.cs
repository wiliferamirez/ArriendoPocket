using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;

namespace ArriendoPocket.Models
{
    public class Propiedad
    {
        [Key]
        public int PropiedadID { get; set; }
        public string ArrendatarioID { get; set; }

        [ForeignKey("ArrendatarioID")]
        public Arrendatario Propietario { get; set; }

        [DisplayName("Nombre Inquilino")]
        public string NombreInquilino { get; set; }

        [DisplayName("Alias")]
        public string AliasPropiedad { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Direccion")]
        public string DireccionPropiedad { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Numero de Habitaciones")]
        public int NumeroHabitaciones { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Canon Arrendatario")]
        public decimal CanonArrendatario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public bool Disponible { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Meses de Garatia")]
        public int MesesGarantia { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Numero de Pisos")]
        public int NumeroPisos { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Area de Construccion")]
        public decimal AreaConstruccion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Ciudad")]
        public string CiudadUbicacion { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayName("Ano de Construccion")]
        public DateOnly FechaConstruccion { get; set; }

        [DisplayName("Fecha de inscripcion de Propiedad")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
