﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shopping.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50)]
        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        public string Name { get; set; }

        [JsonIgnore]
        public State State { get; set; }
        public ICollection<User> users { get; set; }
    }
}
