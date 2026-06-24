using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class User
    {
        [Key]
        [Display(Name = "Identificador")]
        [Required(ErrorMessage = "El campo Identificador es requerido.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.", MinimumLength = 2)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.", MinimumLength = 2)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Número de teléfono inválido.")]
        [StringLength(15, ErrorMessage = "El número de teléfono no puede exceder los 15 caracteres.")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo Edad es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "La edad debe ser un entero no negativo.")]
        [Display(Name = "Edad")]
        public int Age { get; set; }
    }
}
