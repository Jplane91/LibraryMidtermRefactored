using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace LibraryMidtermReFactored
{
     public abstract class Media
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string MediaType { get; set; }
        public string Status { get; set; }

        public Media()
        {

        }
        public Media(string title, string genre, string year, string mediaType, string status)
        {
            Title = title;
            Genre = genre;
            Year = year;
            MediaType = mediaType;
            Status = status;
        }
    }
}