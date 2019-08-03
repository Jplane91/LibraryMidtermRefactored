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
                }

                else if (userSearchPreference == "title")
                {
                    BookMethods.SearchBookTitle(bookInfo);
                }

                else if (userSearchPreference == "author")
                {
                    BookMethods.SearchBookAuthor(bookInfo);
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
                }

                else if (userSearchPreference == "title")
                {
                    MusicMethods.SearchMusicTitle(musicInfo);
                }

                else if (userSearchPreference == "artist")
                {
                    MusicMethods.SearchMusicArtist(musicInfo);
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
                }

                else if (userSearchPreference == "title")
                {
                    MovieMethods.SearchMovieTitle(movieInfo);
                }

                else if (userSearchPreference == "director")
                {
                    MovieMethods.SearchMovieDirector(movieInfo);
                }
            }
        }
        #endregion

    }
}
