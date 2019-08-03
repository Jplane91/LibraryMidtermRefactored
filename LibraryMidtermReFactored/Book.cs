﻿using System;
namespace LibraryMidtermReFactored
{
    public class Book : Media
    {
        public string Author { get; set; }
        public string Pages { get; set; }


        public Book() : base()
        {

        }

        public Book(string title, string year, string genre, string mediaType, string author, string pages, string status)
            : base(title, year, genre, mediaType, status)
        {

        }


    }
}

