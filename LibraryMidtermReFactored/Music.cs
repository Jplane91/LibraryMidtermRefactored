using System;
namespace LibraryMidtermReFactored
{
    public class Music : Media
    {
        //Properties specific to Music
        public string Artist { get; set; }
        public string Rating { get; set; }


        public Music() : base()
        {

        }

        public Music(string title, string year, string genre, string mediaType, string artist, string rating, string status, string format)
            : base(title, year, genre, mediaType, status, format)
        {

        }


    }
}

