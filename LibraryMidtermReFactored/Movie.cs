using System;
namespace LibraryMidtermReFactored
{
    public class Movie : Media
    {
        public string Director { get; set; }
        public string Rating { get; set; }


        public Movie() : base()
        {

        }

        public Movie(string title, string year, string genre, string mediaType, string director, string rating, string status)
            : base(title, year, genre, mediaType, status)
        {

        }


    }
}

