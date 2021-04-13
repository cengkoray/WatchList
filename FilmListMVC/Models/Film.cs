using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmListMVC.Models
{
    public class Film
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Star { get; set; }
        public string Imdbid { get; set; }
    }
}
