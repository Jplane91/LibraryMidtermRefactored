using System;
using System.Collections.Generic;

namespace LibraryMidtermReFactored
{
    public class Prompts
    {

        public static void Intro()
        {
            Console.WriteLine("Welcome the Online Library Catalog");
        }

        public static void SearchorAdd()
        {

            Console.WriteLine("Would you like to search or add to the database");
            string searchOrAddResonse = Console.ReadLine();
            if (searchOrAddResonse == "search")
            {
                MovieBookorMusic();
            }

            else if (searchOrAddResonse == "add")
            {
                AskWhichMediaToAdd();
            }


        }

        public static void AskWhichMediaToAdd()
        {
            List<Book> bookInfo = BookMethods.BookTxtToList();
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();

            Console.WriteLine("Which media would you like to add to the database?(book, movie, or music)");
            string mediaToAddResponse = Console.ReadLine();
            if(mediaToAddResponse == "book")
            {
                BookMethods.AddToBookList(bookInfo);
            }

            else if (mediaToAddResponse == "movie")
            {
                MovieMethods.AddToMovieList(movieInfo);
            }

            else if (mediaToAddResponse == "music")
            {
                MusicMethods.AddToMusicList(musicInfo);
            }

            else
            {
                Console.WriteLine("Invalid response");
                AskWhichMediaToAdd();
            }
        }

        public static void MovieBookorMusic()
        {
            Console.WriteLine("Are you looking for a book, movie, or album?");
            string userMediaPreference = Console.ReadLine();

            if (userMediaPreference == "book")
            {
                List<Book> bookInfo = BookMethods.BookTxtToList();
                Console.WriteLine("Would you like to seach by title, author, or show all");
                string userSearchPreference = Console.ReadLine();
                if (userSearchPreference == "all")
                {
                    BookMethods.PrintBookList(bookInfo);
                    AskToSearchAgain(); // If they enter no in this method it will ask them to check out
                                        //If they enter yes to check out, it will then lead them to a different method that asks for the title to check out
                                        //if their input matches with a title, it will them give the due date (methodception)

                }

                else if (userSearchPreference == "title")
                {
                    BookMethods.SearchBookTitle(bookInfo);
                    AskToSearchAgain();
                }

                else if (userSearchPreference == "author")
                {
                    BookMethods.SearchBookAuthor(bookInfo);
                    AskToSearchAgain();

                }

            }

            else if (userMediaPreference == "album")
            {
                List<Music> musicInfo = MusicMethods.MusicTxtToList();
                Console.WriteLine("Would you like to seach by album title, artist, or show all");
                string userSearchPreference = Console.ReadLine();
                if (userSearchPreference == "all")
                {
                    MusicMethods.PrintMusicList(musicInfo);
                    AskToSearchAgain();
                }

                else if (userSearchPreference == "title")
                {
                    MusicMethods.SearchMusicTitle(musicInfo);
                    AskToSearchAgain();
                }

                else if (userSearchPreference == "artist")
                {
                    MusicMethods.SearchMusicArtist(musicInfo);
                    AskToSearchAgain();
                }

            }

            else if (userMediaPreference == "movie")
            {
                List<Movie> movieInfo = MovieMethods.MovieTxtToList();
                Console.WriteLine("Would you like to seach by movie title, director, or show all");
                string userSearchPreference = Console.ReadLine();
                if (userSearchPreference == "all")
                {
                    MovieMethods.PrintMovieList(movieInfo);
                    AskToSearchAgain();
                }

                else if (userSearchPreference == "title")
                {
                    MovieMethods.SearchMovieTitle(movieInfo);
                    AskToSearchAgain();
                }

                else if (userSearchPreference == "director")
                {
                    MovieMethods.SearchMovieDirector(movieInfo);
                    AskToSearchAgain();
                }
            }
        }

        public static void AskToSearchAgain()
        {
            Console.WriteLine("Would you like to search again");
            string searchAgainResponse = Console.ReadLine().ToLower();
            if (searchAgainResponse == "yes")
            {
                MovieBookorMusic();
            }

            else if (searchAgainResponse == "no")
            {
                AskToCheckOut();
            }

            else
            {
                Console.WriteLine("Invalid Resonse");
                AskToSearchAgain();
            }


        }

        public static void AskToCheckOut()
        {
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();
            List<Book> bookInfo = BookMethods.BookTxtToList();

            Console.WriteLine("Would you like to check out a title");
            string userCheckOutResponse = Console.ReadLine().ToLower();
            if (userCheckOutResponse == "yes")
            {
                string whichMediaType = WhichMediaToCheckOut();
                if (whichMediaType == "book")
                {
                    AskForBookTitleToCheckOut(bookInfo);
                }

                else if (whichMediaType == "movie")
                {

                    AskForMovieTitleToCheckOut(movieInfo);
                }

                else
                {
                    AskForMusicTitleToCheckOut(musicInfo);
                }

            }



            else if (userCheckOutResponse == "no")
            {
                Console.WriteLine("Have a good day!");
                System.Environment.Exit(1);
            }

            else
            {
                Console.WriteLine("Invalid Response");
                AskToCheckOut();
            }
        }

        public static string WhichMediaToCheckOut()
        {
            Console.WriteLine("Are you checking out a book, movie, or album");
            string userCheckOutType = Console.ReadLine();
            if (userCheckOutType == "book" || userCheckOutType == "movie" || userCheckOutType == "album")
            {
                return userCheckOutType;
            }
            else
            {
                Console.WriteLine("Invalid Response");
                WhichMediaToCheckOut();
            }
            return userCheckOutType;
  
        }

        public static void AskForBookTitleToCheckOut(List<Book> bookList)
        {

            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);

            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine();
            foreach (var book in bookList)
            {
                if (userTitleToCheckOut == book.Title)
                {
                    Console.WriteLine("You have checked out " + book.Title);
                    if (book.Status == "in")
                    {
                        Console.WriteLine($"You have checked this out until {answer}");
                        book.Status.Replace("in", $"checked out until {answer}");
                        break;
                    }

                }

            }
        }

        public static void AskForMovieTitleToCheckOut(List<Movie> movieList)
        {

            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);

            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine();
            foreach (var movie in movieList)
            {
                if (userTitleToCheckOut == movie.Title)
                {
                    Console.WriteLine("You have checked out " + movie.Title);
                    if (movie.Status == "in")
                    {
                        Console.WriteLine($"You have checked this out until {answer}");
                        movie.Status.Replace("in", $"checked out until {answer}");
                        break;
                    }

                }

            }
        }

        public static void AskForMusicTitleToCheckOut(List<Music> musicList)
            {

                DateTime today = DateTime.Now;
                DateTime answer = today.AddDays(14);
                String.Format("{0:M/d/yyyy}", answer);

                Console.WriteLine("Which title would you like to check out");
                string userTitleToCheckOut = Console.ReadLine();
                foreach (var music in musicList)
                {
                    if (userTitleToCheckOut == music.Title)
                    {
                        Console.WriteLine("You have checked out " + music.Title);
                        if (music.Status == "in")
                        {
                            Console.WriteLine($"You have checked this out until {answer}");
                            music.Status.Replace("in", $"checked out until {answer}");
                            break;
                        }

                    }

                }
            }
    }
}
