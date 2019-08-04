﻿using System;
using System.Collections.Generic;

namespace LibraryMidtermReFactored
{
    public class Prompts
    {

        public static void Intro()
        {
            Console.WriteLine("Welcome the Online Library Catalog");
        }

        public static void AskToSearchorAdd()
        {

            Console.WriteLine("Would you like to search or add to the database");
            string searchOrAddResonse = Console.ReadLine().ToLower();
            if (searchOrAddResonse == "search")
            {
                MovieBookorMusic();
            }

            else if (searchOrAddResonse == "add")
            {
                AskWhichMediaToAdd();
            }

            else
            {
                Console.WriteLine("Invalid response");
                AskToSearchorAdd();
            }


        }

        public static void AskWhichMediaToAdd()
        {
            List<Book> bookInfo = BookMethods.BookTxtToList();
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();

            Console.WriteLine("Which media would you like to add to the database?(book, movie, or music)");
            string mediaToAddResponse = Console.ReadLine().ToLower();
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
            string userMediaPreference = Console.ReadLine().ToLower();

            if (userMediaPreference == "book")
            {
                List<Book> bookInfo = BookMethods.BookTxtToList();
                Console.WriteLine("Would you like to seach by title, author, or show all");
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "all" || userMediaPreference == "show all")
                {
                    BookMethods.PrintBookList(bookInfo);
                    AskToSearchAgain(); // If they enter no in this method it will ask them to check out
                                        //If they enter yes to check out, it will then lead them to a different method that asks which media they want to check out
                                        //Then based off that response, it takes them to a method that has them enter the title they want to check out
                                        //if their input matches with a title, it will them give the due date, (methodception) I need to add validation if it doesn't match

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
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "all" || userSearchPreference == "show all")
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
                string userSearchPreference = Console.ReadLine().ToLower();
                if (userSearchPreference == "all" || userSearchPreference == "show all")
                {
                    MovieMethods.PrintMovieList(movieInfo);
                    AskToSearchAgain();
                }

                else if (userSearchPreference == "title" || userMediaPreference == "movie title")
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
            Console.WriteLine("Would you like to search again?(yes or no)");
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
            bool validate;
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();
            List<Book> bookInfo = BookMethods.BookTxtToList();

            Console.WriteLine("Would you like to check out a title?(yes or no)");
            string userCheckOutResponse = Console.ReadLine().ToLower();
            if (userCheckOutResponse == "yes")
            {
                string whichMediaType = WhichMediaToCheckOut();
                if (whichMediaType == "book")
                {
                   validate = AskForBookTitleToCheckOut(bookInfo);
                    if (validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }
                }

                else if (whichMediaType == "movie")
                {
                    validate = AskForMovieTitleToCheckOut(movieInfo);
                    if(validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }
                }

                else
                {
                    validate = AskForMusicTitleToCheckOut(musicInfo);
                    if(validate == false)
                    {
                        NotInStockPrompt(); //prompts to check out again, search again, or to exit
                    }
                }

            }

            else if (userCheckOutResponse == "no")
            {
                //Not sure if we should have them exit here or prompt something else
                Console.WriteLine("Have a good day!");
                System.Environment.Exit(1);
            }

            else
            {
                Console.WriteLine("Invalid Response");
                AskToCheckOut();
            }
        }

        public static string WhichMediaToCheckOut() //Gets called in the AskToCheckOut Method
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

                    else
                    {
                        return false;
                    }
 
                    }
                }
            return false;
            }

        public static void NotInStockPrompt() 
        {
            Console.WriteLine("We do not have that in stock");
            Console.WriteLine("Would you like to enter title again, go back to search, or exit?\n(Type 1 for Enter Again, 2 for Search, 3 to Exit");
            int userNotInStockResponse = int.Parse(Console.ReadLine());
            if(userNotInStockResponse == 1)
            {
                AskToCheckOut();
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
                NotInStockPrompt();
            }
        }
    }
}
