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

        public ICollection<State> States { get; set; }

        [Display(Name = "Departamento/Estados")]
        public int StatesNumber => States == null ? 0 : States.Count;

    }
}
