using MyMvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyMvcMovie.Controllers {
    //Denna klass är Api controllern, som sedan klienten skickar info till och tar emot.
    public class MovieApiController : ApiController {
        
        static readonly IMovieRepository repository = new MovieRepository();
        public IEnumerable<Movie> GetAllProducts() {
            return repository.GetAll();
        }
        //Klienten kallar på denna metod för att få en lista av nuvaranda objekt i databasen.
        public List<Movie> GetProduct(int id) {
            List<Movie> listTemp = repository.GetAll().ToList();
            Movie item = repository.Get(id);
            if(item == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return listTemp;
        }
        //Denna metod kallas när användaren lägger in ett nytt objekt från klienten.
        public HttpResponseMessage PostProduct(Movie item) {
            item = repository.Add(item);
            var response = Request.CreateResponse<Movie>(HttpStatusCode.Created, item);

            string uri = Url.Link("API Default", new { id = item.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(int id, Movie movie) {
            movie.ID = id;
            if(!repository.Update(movie)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
