using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcMovie.Models {
    public class MovieRepository : IMovieRepository {
        private List<Movie> products = new List<Movie>();
        private MovieDBContext db = new MovieDBContext();
        private int _nextId = 1;

        public MovieRepository() {
            getAllItemsFromDatabase();
            

        }
        //När man vill få en lista av alla föremål så kallar man på denna metod
        public IEnumerable<Movie> GetAll() {
            return products;
        }
        //När man vill få en enstaka produkt via id så kallas denna.
        public Movie Get(int id) {
            return products.Find(p => p.ID == id);
        }
        //Metoden som lägger in objektet i listan samt databasen.
        public Movie Add(Movie item) {
            if (item == null) {
                throw new ArgumentNullException("item");
            }

            item.ID = _nextId++;
            db.Movies.Add(item);
            db.SaveChanges();
            products.Add(item);
            return item;
        }



        public bool Update(Movie item) {
            if (item == null) {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.ID == item.ID);
            if (index == -1) {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }

        //Denna metod lägger in alla object från databasen in i listan när detta object kallas för första gången.
        private void getAllItemsFromDatabase() {
            products = db.Movies.ToList();
        }

    }
}