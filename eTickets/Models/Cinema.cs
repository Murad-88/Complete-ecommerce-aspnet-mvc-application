using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Mahallah Picture/Logo")]
        [Required(ErrorMessage = "Mahallah Logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Mahallah Name")]
        [Required(ErrorMessage = "Mahallah Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description: Block & Room")]
        [Required(ErrorMessage = "Mahallah Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }

    }
}
