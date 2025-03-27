using System.ComponentModel.DataAnnotations;

namespace Examen2.Models
{
    public class Tareas
    {

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
     }
}
