using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //Este data annotation indica que el campo es obligatorio
        [Display(Name= "Nombre de la Categoría")] // Me sirve para personalizar el nombre que se muestra en las vistas o mensaje error
        public string Name { get; set; }
    }
}
