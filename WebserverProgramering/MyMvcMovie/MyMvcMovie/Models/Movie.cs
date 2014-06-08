using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyMvcMovie.Models {
    //Huvud klassen till filmerna
    public class Movie {

        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [StringLength(5)]
        public string Rating { get; set; }
    }
    //Databas klase
    public class MovieDBContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
    }
}