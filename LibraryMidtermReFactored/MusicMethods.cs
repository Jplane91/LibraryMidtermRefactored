using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryMidtermReFactored
{
    public class MusicMethods
    {

        public static List<Music> MusicTxtToList()
        {
            string filepath = ("../../../MusicTextFile.txt");

            List<Music> musicInfo  = new List<Music>();
            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach(var line in lines)
            {
                string[] entries = line.Split('|');
                Music newMusic = new Music();
                newMusic.Title = entries[0];
                newMusic.Year = entries[1];
                newMusic.Genre = entries[2];
                newMusic.MediaType = entries[3];
                newMusic.Status = entries[4];
                newMusic.Artist = entries[5];
                newMusic.Rating = entries[6];

                musicInfo.Add(newMusic);
            }

           

            return musicInfo;
            
        }

        public static void PrintMusicList(List<Music> list)
        {
            foreach(var music in list)
            {
                Console.WriteLine();
                Console.WriteLine("Title: " + music.Title + "\nArtist: " + music.Artist + "\nRating: " + music.Rating + "\nYear Released: " + music.Year);
            }
        }

        public static void SearchMusicTitle(List<Music> list)
        {
            Console.WriteLine("Enter keywod for the title");
            string userMusicTitleSearch = Console.ReadLine().ToLower();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var music in list)
            {
                if(music.Title.ToLower().Contains(userMusicTitleSearch))
                {
                    Console.WriteLine();
                    Console.WriteLine("Title: " + music.Title + "\nArtist: " + music.Artist + "\nRating: " + music.Rating + "\nYear Released: " + music.Year);
                }
            }
                
        }

        public static void SearchMusicArtist(List<Music> list)
        {
            Console.WriteLine("Enter keyword for the artist");
            string userArtistSearch = Console.ReadLine().ToLower();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var music in list)
            {
                if (music.Artist.ToLower().Contains(userArtistSearch))
                {
                    Console.WriteLine();
                    Console.WriteLine("Title: " + music.Title + "\nArtist: " + music.Artist + "\nRating: " + music.Rating + "\nYear Released: " + music.Year);
                }
            }
        }

        public static void AddToMusicList(List<Music>list)
        {
            string filepath = ("../../../MusicTextFile.txt");

            Console.WriteLine("Enter Album Title");
            string userMusicTitle = Console.ReadLine();

            Console.WriteLine("Enter Artist Name");
            string userMusicArtist= Console.ReadLine();

            Console.WriteLine("Enter Release Date");
            string userYear = Console.ReadLine();

            Console.WriteLine("Enter Music Rating");
            string userMusicRating = Console.ReadLine();

            Console.WriteLine("Enter Genre");
            string userMusicGenre = Console.ReadLine();


            list.Add(new Music
            {
                Title = userMusicTitle,
                Year = userYear,
                Genre = userMusicGenre,
                MediaType = "Music",
                Status = "In",
                Artist= userMusicArtist,
                Rating = userMusicRating
            });

            List<string> output = new List<string>();
            foreach (var music in list)
            {
                output.Add($"{ music.Title}|{music.Year}|{music.Genre}|{music.MediaType}|{music.Status}|{music.Artist}|{music.Rating}");
            }

            File.WriteAllLines(filepath, output);
        }
            

    }


}
