using System;
using System.Collections.Generic;

namespace LibraryMidtermReFactored
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Book> bookInfo = BookMethods.BookTxtToList();
            List<Movie> movieInfo = MovieMethods.MovieTxtToList();
            List<Music> musicInfo = MusicMethods.MusicTxtToList();

            Prompts.Intro();
            Prompts.MovieBookorMusic();

            //Uncomment to Try Out
            //BookMethods.AddToBookList(bookInfo);
            //MovieMethods.AddToMovieList(movieInfo);
            //MusicMethods.AddToMusicList(musicInfo);

        }
    }
}
