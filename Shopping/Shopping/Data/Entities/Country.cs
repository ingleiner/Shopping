using System.ComponentModel.DataAnnotations;

namespace Shopping.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        
        [Display(Name = "País")]
        [MaxLength(50)]
        [Required(ErrorMessage ="El Campo {0} es obligatorio")]
        public string Name { get; set; }  
    }
}
