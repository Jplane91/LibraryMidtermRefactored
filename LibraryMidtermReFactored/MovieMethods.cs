using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryMidtermReFactored
{
    public class MovieMethods
    {

        public static List<Movie> MovieTxtToList()
        {
            string filepath = ("../../../MovieTextFile.txt");

            List<Movie> movieInfo  = new List<Movie>();
            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach(var line in lines)
            {
                string[] entries = line.Split('|');
                Movie newMovie = new Movie();
                newMovie.Title = entries[0];
                newMovie.Year = entries[1];
                newMovie.Genre = entries[2];
                newMovie.MediaType = entries[3];
                newMovie.Status = entries[4];
                newMovie.Director = entries[5];
                newMovie.Rating = entries[6];
                newMovie.IMDB = entries[7];
                newMovie.Format = entries[8];

                movieInfo.Add(newMovie);
            }

           

            return movieInfo;
            
        }

        public static void PrintMovieList(List<Movie> list)
        {
            foreach(var movie in list)
            {
                Console.WriteLine();
                Console.WriteLine("Title: " + movie.Title + "\nDirector: " + movie.Director + "\nRating: " + movie.Rating +
                    "\nYear Released: " + movie.Year + "\nIMDB: " + movie.IMDB + "\nFormat: " + movie.Format + "\nStatus: " + movie.Status);
            }
        }

        public static void SearchMovieTitle(List<Movie> list)
        {
            Console.WriteLine("Enter keyword for the title");
            string userMovieTitleSearch = Console.ReadLine().ToLower();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var movie in list)
            {
                if(movie.Title.ToLower().Contains(userMovieTitleSearch))
                {
                    Console.WriteLine();
                    Console.WriteLine("Title: " + movie.Title + "\nDirector: " + movie.Director + "\nRating: " + movie.Rating +
                        "\nYear Released: " + movie.Year + "\nIMDB: " + movie.IMDB + "\nFormat: " + movie.Format + "\nStatus: " + movie.Status);
                }
            }
                
        }

        public static void SearchMovieDirector(List<Movie> list)
        {
            Console.WriteLine("Enter keyword for the director");
            string userDirectorSearch = Console.ReadLine().ToLower();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var movie in list)
            {
                if (movie.Director.ToLower().Contains(userDirectorSearch)) 
                {
                    Console.WriteLine();
                    Console.WriteLine("Title: " + movie.Title + "\nDirector: " + movie.Director + "\nRating: " + movie.Rating +
                        "\nYear Released: " + movie.Year + "\nIMDB: " + movie.IMDB + "\nFormat: " + movie.Format + "\nStatus: " + movie.Status);
                }
            }
        }

        public static void AddToMovieList(List<Movie>list)
        {
            string filepath = ("../../../MovieTextFile.txt");

            Console.WriteLine("Enter Movie Title");
            string userMovieTitle = Console.ReadLine();

            Console.WriteLine("Enter Director");
            string userMovieDirector = Console.ReadLine();

            Console.WriteLine("Enter Release Date");
            string userYear = Console.ReadLine();

            Console.WriteLine("Enter Movie Rating");
            string userMovieRating = Console.ReadLine();

            Console.WriteLine("Enter Genre");
            string userMovieGenre = Console.ReadLine();

            Console.WriteLine("Enter IMDB Score");
            string userMovieIMDB = Console.ReadLine();

            Console.WriteLine("Enter Format");
            string userMovieFormat = Console.ReadLine();


            list.Add(new Movie
            {
                Title = userMovieTitle,
                Year = userYear,
                Genre = userMovieGenre,
                MediaType = "Movie",
                Status = "in",
                Director= userMovieDirector,
                Rating = userMovieRating,
                IMDB = userMovieIMDB,
                Format = userMovieFormat
            });

            List<string> output = new List<string>();
            foreach (var movie in list)
            {
                output.Add($"{ movie.Title}|{movie.Year}|{movie.Genre}|{movie.MediaType}" +
                    $"|{movie.Status}|{movie.Director}|{movie.Rating}|{movie.IMDB}|{movie.Format}");
                    
            }

            File.WriteAllLines(filepath, output);
        }
            

    }


}
