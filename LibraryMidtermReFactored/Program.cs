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
            Prompts.MovieBookorMusic(); //I only have book option working all the way through right now

            //Uncomment to Try Out
            //BookMethods.AddToBookList(bookInfo);
            //MovieMethods.AddToMovieList(movieInfo);
            //MusicMethods.AddToMusicList(musicInfo);

        }
    }
}
