
﻿using System;
using System.Collections.Generic;

namespace LibraryMidtermReFactored
{
    public class Prompts
    {

        public static void Intro()
        {
            Console.WriteLine("Welcome to the Online Library Catalog");
        }

        public static void AskToSearchReturnOrAdd()
        {

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Check an item out.");
            Console.WriteLine("2. Return an item.");
            Console.WriteLine("3. Donate to the Library.");
            Console.WriteLine("4. Quit.");
            string searchOrAddResonse = Console.ReadLine().ToLower();
            if (searchOrAddResonse == "1")
            {
                MovieBookorMusic();
            }
         
            else if (searchOrAddResonse == "2")
            {

            }
            else if (searchOrAddResonse == "3")
            {
                AskWhichMediaToAdd();
            }
            else if(searchOrAddResonse == "4")
                {
               Console.WriteLine("Have a nice day!");
               return;
            }

            else
            {
                Console.WriteLine("Invalid response");
                AskToSearchReturnOrAdd();
            }


        }

        public static void AskWhichMediaToAdd()
        {
            List<Book> bookInfo = BookMethods.BookTxtToList();
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();

            Console.WriteLine("Which media would you like to add to the database?(book, movie, or music)");
            string mediaToAddResponse = Console.ReadLine().ToLower();
            if (mediaToAddResponse == "book")
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
            Console.WriteLine("What would you like to checkout?\n1.Book\n2.Movie\n3.Music\n4.Quit");
            string userMediaPreference = Console.ReadLine().ToLower();

            if (userMediaPreference == "1")
            {
                List<Book> bookInfo = BookMethods.BookTxtToList();
                Console.WriteLine("We have a lot of books.");
                Console.WriteLine("1. Search by title.\n2. Search by author\n3.Full List\n4.Quit");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "1")
                {
                    BookMethods.SearchBookTitle(bookInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "2")
                {
                    BookMethods.SearchBookAuthor(bookInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "3")
                {
                    BookMethods.PrintBookList(bookInfo);
                    AskToSearchOrCheckOut();
                }
                else if(userSearchPreference == "4")
                {
                    Console.WriteLine("Have a nice day!");
                    return;
                }
                else
                {
                    Console.WriteLine("That was not a valid response.");
                    MovieBookorMusic();
                }

            }
            else if (userMediaPreference == "2")
            {
                List<Movie> movieInfo = MovieMethods.MovieTxtToList();
                Console.WriteLine("We have a lot of movies.\n1.Search by title.\n2.Search by director.\n3.Full List\n4.Quit.");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "1")
                {
                    MovieMethods.SearchMovieTitle(movieInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "2")
                {
                    MovieMethods.SearchMovieDirector(movieInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "3")
                {
                    MovieMethods.PrintMovieList(movieInfo);
                    AskToSearchOrCheckOut();
                }
                else if (userSearchPreference == "4")
                {
                    Console.WriteLine("Have a nice day!");
                    return;
                }
                else
                {
                    Console.WriteLine("That was not a valid response.");
                    MovieBookorMusic();
                }
            }
            else if (userMediaPreference == "3")
            {
                List<Music> musicInfo = MusicMethods.MusicTxtToList();
                Console.WriteLine("We have a lot of music albums!\n1.Search by Title.\n2.Search by Artist.\n3.Full List.\n4.Quit.");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "1")
                {
                    MusicMethods.SearchMusicTitle(musicInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "2")
                {
                    MusicMethods.SearchMusicArtist(musicInfo);
                    AskToSearchOrCheckOut();
                }

                else if (userSearchPreference == "3")
                {
                    MusicMethods.PrintMusicList(musicInfo);
                    AskToSearchOrCheckOut();
                }
                else if(userSearchPreference == "4")
                {
                    Console.WriteLine("Have a nice day!");
                    return;
                }
                else
                {
                    Console.WriteLine("That was not a valid response.");
                    MovieBookorMusic();
                }
                      

            }
            else
            {
                Console.WriteLine("That was not a valid response.");
                MovieBookorMusic();
            }

            
        }

        public static void AskToSearchOrCheckOut()
        {
            Console.WriteLine("Would you like to search again, go to checkout, or exit?\n(1. Search, 2. Checkout. 3. Exit)");
            string searchAgainResponse = Console.ReadLine().ToLower();
            if (searchAgainResponse == "1")
            {
                MovieBookorMusic();
            }

            else if (searchAgainResponse == "2")
            {
                GoToCheckOut();
            }

            else if (searchAgainResponse == "3")
            {
                Console.WriteLine("Have a good day!");
                System.Environment.Exit(1);
            }

            else
            {
                Console.WriteLine("Invalid Response");
                AskToSearchOrCheckOut();
            }


        }

        public static void GoToCheckOut()
        {
            bool validate;
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();
            List<Book> bookInfo = BookMethods.BookTxtToList();
            {
                string whichMediaType = WhichMediaToCheckOut();
                if (whichMediaType == "book")
                {
                    validate = AskForBookTitleToCheckOut(bookInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }

                    else
                    {
                        ReturnToMainMenuOrExit();
                    }
                }

                else if (whichMediaType == "movie")
                {
                    validate = AskForMovieTitleToCheckOut(movieInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }

                    else
                    {
                        ReturnToMainMenuOrExit();
                    }
                }

                else
                {
                    validate = AskForMusicTitleToCheckOut(musicInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }

                    else
                    {
                        ReturnToMainMenuOrExit();
                    }
                }

            }
        }

        public static string WhichMediaToCheckOut() //Gets called in the GoToCheckOut Method
        {
            Console.WriteLine("Are you checking out a book, movie, or album?(enter book, movie, or album)");
            string userCheckOutType = Console.ReadLine().ToLower();
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

        public static bool AskForBookTitleToCheckOut(List<Book> bookList) //returns fall if there is no match
        {

            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);

            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine().ToLower();
            foreach (var book in bookList)
            {
                if (userTitleToCheckOut.ToLower() == book.Title.ToLower())
                {
                    Console.WriteLine("You have checked out " + book.Title);
                    if (book.Status == "in")
                    {
                        Console.WriteLine($"You have checked this out until {answer}");
                        book.Status.Replace("in", $"checked out until {answer}");
                        return true;
                    }
                    return true;
                }

            }
            return false;
        }

        public static bool AskForMovieTitleToCheckOut(List<Movie> movieList) //returns false if there is no match
        {

            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);

            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine();
            foreach (var movie in movieList)
            {
                if (userTitleToCheckOut.ToLower() == movie.Title.ToLower())
                {
                    Console.WriteLine("You have checked out " + movie.Title);
                    if (movie.Status == "in")
                    {
                        Console.WriteLine($"You have checked this out until {answer}");
                        movie.Status.Replace("in", $"checked out until {answer}");
                        return true;
                    }
                    return true;
                }

            }

            return false;
        }

        public static bool AskForMusicTitleToCheckOut(List<Music> musicList) //returns false if there is no match
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(14);
            String.Format("{0:M/d/yyyy}", answer);

            Console.WriteLine("Which title would you like to check out");
            string userTitleToCheckOut = Console.ReadLine().ToLower();
            foreach (var music in musicList)
            {
                if (userTitleToCheckOut.ToLower() == music.Title.ToLower())
                {
                    Console.WriteLine("You have checked out " + music.Title);
                    if (music.Status == "in")
                    {
                        Console.WriteLine($"You have checked this out until {answer}");
                        music.Status.Replace("in", $"checked out until {answer}");
                        return true;
                    }
                    return true;
                }
            }
            return false;
        }

        public static void NotInStockPrompt()
        {
            Console.WriteLine("We do not have that in stock");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Would you like to enter title again, go back to search, or exit?\n(Type 1 for Enter Again, 2 for Search, 3 to Exit");
                int userNotInStockResponse = int.Parse(Console.ReadLine());
                if (userNotInStockResponse == 1)
                {
                    GoToCheckOut();
                }

                else if (userNotInStockResponse == 2)
                {
                    MovieBookorMusic();
                }

                else if (userNotInStockResponse == 3)
                {
                    Console.WriteLine("Have a good day!");
                }

                else
                {
                    Console.WriteLine("Not a valid response");
                    loop = true;
                }
            }
        }
        public static void ReturnToMainMenuOrExit()
        {
            Console.WriteLine("Would you like to return to the main menu or to exit?");
            string userMainMenuOrExitResponse = Console.ReadLine().ToLower();
            if (userMainMenuOrExitResponse == "main menu" || userMainMenuOrExitResponse == "main" || userMainMenuOrExitResponse == "menu")
            {
                Console.Clear();
                AskToSearchReturnOrAdd();
            }

            else if (userMainMenuOrExitResponse == "exit")
            {
                Console.WriteLine("Have a good day!");
                System.Environment.Exit(1);
            }

            else
            {
                Console.WriteLine("Invalid input");
                ReturnToMainMenuOrExit();
            }
        }
    }
}
