using System;
namespace LibraryMidtermReFactored
{
    public class Movie : Media
    {
        //properties specific to Movie
        public string Director { get; set; }
        public string Rating { get; set; }
        public string IMDB { get; set; }


        public Movie() : base()
        {

        }

        public Movie(string title, string year, string genre, string mediaType, string director, string rating, string status, int imdb, string format)
            : base(title, year, genre, mediaType, status, format)
        {

        }


    }
}

