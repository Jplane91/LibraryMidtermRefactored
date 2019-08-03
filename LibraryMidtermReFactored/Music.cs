using System;
namespace LibraryMidtermReFactored
{
    public class Music : Media
    {
        public string Artist { get; set; }
        public string Rating { get; set; }


        public Music() : base()
        {

        }

        public Music(string title, string year, string genre, string mediaType, string artist, string rating, string status)
            : base(title, year, genre, mediaType, status)
        {

        }


    }
}

