using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProcuctStoreClient {
    class Program {
        static List<Product> listOfMovies = new List<Product>();
        private static bool isDoneInPoducts = false;
        static void Main() {
            //Enkel/simpel navigering för användaren.
            for (; ; ) {
                Console.WriteLine("Welcome Movie store CLIENT!! please select\n" +
                    "A: Read all items from the store\n" +
                    "B: Create new item for the store\n" +
                    "C: Exit the program");

                var input = Console.ReadKey();
                Console.Clear();
                switch (input.Key) {
                    case ConsoleKey.A:

                        RunAsyncReadAll().Wait();
                        isDoneInPoducts = false;
                        displayProducts();
                        break;
                    case ConsoleKey.B:

                        RunAsyncCreateItem().Wait();
                        break;
                    case ConsoleKey.C:
                        return;

                }
            }

        }
        //Skriver ut ett singel objekt, som man sedan kan navigera till.
        static void writeProduct(Product product, int index) {
            Console.WriteLine((index + 1) + ": " + product.Title);
        }

        //Denna metod kommer skriva ut specefik information om en vis produkt
        static void writeItemDescription(int page, int productPerPage, int index) {
            Product product = listOfMovies[(page * productPerPage) + index - 1];
            Console.WriteLine("Title: " + product.Title);
            Console.WriteLine("Genre: " + product.Genre);
            Console.WriteLine("Price: " + product.Price + " $");
            Console.WriteLine("Release: " + product.ReleaseDate.ToString("d"));



            Console.ReadKey();
            Console.Clear();
        }
        //Denna metod kommer att skriva ut alla föremål i en lätt navigerad lista, som man sedan kan navigera till
        static void displayProducts(int startPage = 0) {
            while (!isDoneInPoducts) {
                int page = startPage;
                int resultDisplayPerPage = 5;

                //Sätter maxsidor
                float tempMaxPage = ((float)listOfMovies.Count() / (float)resultDisplayPerPage);
                if ((tempMaxPage % 1) != 0)
                    tempMaxPage += 1;
                int maxPage = (int)tempMaxPage;
                //Skriver ut alla filmer.
                if (listOfMovies.Count() > resultDisplayPerPage * (page + 1)) {
                    Console.WriteLine("Going for more than max!");
                    for (int i = page * resultDisplayPerPage; i < (page + 1) * resultDisplayPerPage; i++) {

                        writeProduct(listOfMovies[i], i - (page * resultDisplayPerPage));
                    }
                } else {
                    Console.WriteLine("Going for less than max!");
                    for (int i = page * resultDisplayPerPage; i < listOfMovies.Count(); i++) {
                        writeProduct(listOfMovies[i], i - (page * resultDisplayPerPage));
                    }
                }
                Console.WriteLine("\n\n\n" +
                    "Page: " + (page + 1) + " / " + (int)(maxPage));

                //Hårdkodad navigering, hittade inget annat sätt.
                var input = Console.ReadKey();
                Console.Clear();
                switch (input.Key) {

                    case ConsoleKey.D1:
                        if (page * resultDisplayPerPage + 1 <= listOfMovies.Count() && 1 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 1);
                        break;
                    case ConsoleKey.D2:
                        if (page * resultDisplayPerPage + 2 <= listOfMovies.Count() && 2 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 2);
                        break;
                    case ConsoleKey.D3:
                        if (page * resultDisplayPerPage + 3 <= listOfMovies.Count() && 3 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 3);
                        break;
                    case ConsoleKey.D4:
                        if (page * resultDisplayPerPage + 4 <= listOfMovies.Count() && 4 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 4);
                        break;
                    case ConsoleKey.D5:
                        if (page * resultDisplayPerPage + 5 <= listOfMovies.Count() && 5 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 5);
                        break;
                    case ConsoleKey.D6:
                        if (page * resultDisplayPerPage + 6 <= listOfMovies.Count() && 6 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 6);
                        break;
                    case ConsoleKey.D7:
                        if (page * resultDisplayPerPage + 7 <= listOfMovies.Count() && 7 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 7);
                        break;
                    case ConsoleKey.D8:
                        if (page * resultDisplayPerPage + 8 <= listOfMovies.Count() && 8 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 8);
                        break;
                    case ConsoleKey.D9:
                        if (page * resultDisplayPerPage + 9 <= listOfMovies.Count() && 9 <= resultDisplayPerPage)
                            writeItemDescription(page, resultDisplayPerPage, 9);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (page > 0)
                            displayProducts(page - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        if (page < maxPage - 1)
                            displayProducts(page + 1);
                        break;
                    case ConsoleKey.Escape:
                        isDoneInPoducts = true;
                        break;
                }

            }

        }
        //Denna metod kallas när användaren vill läsa av vilka filmer som existerar på hemsidan.
        static async Task RunAsyncReadAll() {
            using (var client = new HttpClient()) {

                client.BaseAddress = new Uri("http://localhost:50590/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Respons är meddelandet man får från MVC sidan.
                HttpResponseMessage response = await client.GetAsync("api/MovieApi/1");
                if (response.IsSuccessStatusCode) {

                    List<Product> tempListOfProducts = await response.Content.ReadAsAsync<List<Product>>();
                    listOfMovies = tempListOfProducts;
                }
            }
        }
        //Denna metod kallas när användaren ska lägga in ett objekt till hemsidan.
        static async Task RunAsyncCreateItem() {
            using (var client = new HttpClient()) {
                //Skapar temp variabler som sedan kommer auto/Skrivas in av användaren.
                string tempTitle = "";

                DateTime tempReleaseDate = new DateTime();
                string tempGenre = "";
                string tempPrice = "";
                string tempRating = "";

                string tempYear = "";
                string tempMonth = "";
                string tempDay = "";
                int releaseYear = 0;
                int releaseMonth = 0;
                int releaseDay = 0;
                decimal tempPriceDeci = 0;

                bool errorHasOccured = false;
                //"Navigation" kommer hantera användarens gränssnitt när det kommer till att skapa sitt film objekt, den kommer även
                //hantera fel hantering.
                #region navigation


                Console.WriteLine("What's the title of the movie?");
                tempTitle = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("What's the Genre of the movie?");
                tempGenre = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("What's the current rating of the movie?");
                tempRating = Console.ReadLine();
                Console.Clear();

                if (tempRating.Length > 5)
                    errorHasOccured = true;

                Console.WriteLine("What's the price of the movie?");
                tempPrice = Console.ReadLine();
                Console.Clear();

                if (!decimal.TryParse(tempPrice, out tempPriceDeci)) {
                    errorHasOccured = true;
                }

                Console.WriteLine("Time to set the release date, what's the year?");
                tempYear = Console.ReadLine();
                if (!int.TryParse(tempYear, out releaseYear))
                    errorHasOccured = true;
                Console.WriteLine(" what's the month?");
                tempMonth = Console.ReadLine();
                if (int.TryParse(tempMonth, out releaseMonth)) {
                    if (releaseMonth < 1 || releaseMonth > 12)
                        errorHasOccured = true;
                } else
                    errorHasOccured = true;
                Console.WriteLine(" what's the day?");
                tempDay = Console.ReadLine();
                if (int.TryParse(tempDay, out releaseDay)) {
                    if (releaseDay < 1 || releaseDay > 31)
                        errorHasOccured = true;
                } else
                    errorHasOccured = true;
                Console.Clear();


                #endregion
                if (errorHasOccured == false) {
                    //Kontakter rätt adress/port
                    client.BaseAddress = new Uri("http://localhost:50590/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    tempReleaseDate = new DateTime(releaseYear, releaseMonth, releaseDay);
                    //Skapar ett nytt objekt av klassen produkt, som sedan skickas in till hemsidan.
                    var gizmo = new Product() { Genre = tempGenre, Price = tempPriceDeci, Rating = tempRating, Title = tempTitle, ReleaseDate = tempReleaseDate };

                    //Retunerar ett http respons från hemsidan.
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/MovieApi", gizmo);
                    if (response.IsSuccessStatusCode) {
                        Uri gizmoUrl = response.Headers.Location;

                        response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                        // HTTP DELETE
                        response = await client.DeleteAsync(gizmoUrl);
                    }

                    Console.WriteLine("Succesfully created ur item!");
                } else
                    Console.WriteLine("Data that u have entered is incorected for the fildes, please try again!");

                Console.ReadKey();

            }
        }
    }
    //Klassen som ska hålla koll på filmerna. Klassen är likadan som på hemsidan bara det att det inte finns
    //ID. Skulle inte finnasnågon användning för ID.
    class Product {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public string Rating { get; set; }
    }
}
