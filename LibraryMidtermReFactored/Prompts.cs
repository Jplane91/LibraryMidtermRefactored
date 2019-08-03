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

        public static void MovieBookorMusic ()
        {
            Console.WriteLine("Are you looking for a book, movie, or album?");
            string userMediaPreference = Console.ReadLine();

            #region Book Search

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
            #endregion

            #region Music Search

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
            #endregion

            #region Movie Search

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
            if(searchAgainResponse == "yes")
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
            List<Book> bookInfo = BookMethods.BookTxtToList();
            Console.WriteLine("Would you like to check out a title");
            string userCheckOutResponse = Console.ReadLine().ToLower();
            if(userCheckOutResponse == "yes")
            {
                AskForTitleToCheckOut(bookInfo);
            }

            else if(userCheckOutResponse == "no")
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

        public static void AskForTitleToCheckOut(List<Book> list)
        {
   
            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine();
            foreach(var book in list)
            {
                if (userTitleToCheckOut == book.Title)
                {
                    Console.WriteLine("You have checked out " + book.Title);
                    DateTime today = DateTime.Now;
                    DateTime answer = today.AddDays(14);
                    String.Format("{0:M/d/yyyy}", answer);
                    if (book.Status == "in")
                    {
                        Console.WriteLine($"You have checked this out until {answer}");
                        book.Status.Replace("in", $"checked out until {answer}");
                    }
                }
            }
           

            //else if (userCheckOutResponse == "no")
            //{
            //    //return false;
            //}

            //else
            //{
            //    Console.WriteLine("Invalid Response");
            //    AskToCheckOut();
            //}
        }
        #endregion

    }
}
