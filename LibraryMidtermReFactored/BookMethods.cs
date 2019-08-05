using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryMidtermReFactored
{
    public class BookMethods
    {

        public static List<Book> BookTxtToList()
        {
            string filepath = ("../../../BookTextFile.txt");

            List<Book> bookInfo = new List<Book>();
            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach(var line in lines)
            {
                string[] entries = line.Split('|');
                Book newBook = new Book();
                newBook.Title = entries[0];
                newBook.Year = entries[1];
                newBook.Genre = entries[2];
                newBook.MediaType = entries[3];
                newBook.Status = entries[4];
                newBook.Pages = entries[5];
                newBook.Author = entries[6];
                newBook.Format = entries[7];

                bookInfo.Add(newBook);
            }


            return bookInfo;
            
        }

        public static void PrintBookList(List<Book> list)
        {
            foreach(var book in list)
            {
                Console.WriteLine();
                Console.WriteLine("Title: " + book.Title + "\nAuthor: " + book.Author);
            }
        }
        public static void SearchBookTitle(List<Book> list)
        {
            Console.WriteLine("Enter keyword for the title");
            string userBookTitleSearch = Console.ReadLine().ToLower();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var book in list)
            {
                if(book.Title.ToLower().Contains(userBookTitleSearch))
                {
                     Console.WriteLine("Title: " + book.Title + "\nAuthor: " + book.Author + "\nPages: " + book.Pages
                         + "\nYear Published: " + book.Year + "\nFormat: " + book.Format + "\nStatus: " + book.Status);
                }
                
            }
                
        }

        public static void SearchBookAuthor(List<Book> list)
        {
            Console.WriteLine("Enter keyword for the author");
            string userAuthorSearch = Console.ReadLine().ToLower();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var book in list)
            {
                if (book.Author.ToLower().Contains(userAuthorSearch))
                {
                    Console.WriteLine("Title: " + book.Title + "\nAuthor: " + book.Author + "\nPages: " + book.Pages
                     + "\nYear Published: " + book.Year + "\nFormat: " + book.Format + "\nStatus: " + book.Status);
                }
            }
        }

        public static void AddToBookList(List<Book>list)
        {
            string filepath = ("../../../BookTextFile.txt");

            Console.WriteLine("Enter Book Title");
            string userBookTitle = Console.ReadLine();

            Console.WriteLine("Enter Author");
            string userBookAuthor = Console.ReadLine();

            Console.WriteLine("Enter Published Date");
            string userBookYear = Console.ReadLine();

            Console.WriteLine("Enter Page Count");
            string userBookPages = Console.ReadLine();

            Console.WriteLine("Enter Genre");
            string userBookGenre = Console.ReadLine();

            Console.WriteLine("Enter Format(Paperback, Hardcover, Audiobook)");
            string userBookFormat = Console.ReadLine();


            list.Add(new Book
            {
                Title = userBookTitle,
                Year = userBookYear,
                Genre = userBookGenre,
                MediaType = "Book",
                Status = "in",
                Pages = userBookPages,
                Author = userBookAuthor,
                Format = userBookFormat
            });

            List<string> output = new List<string>();
            foreach (var book in list)
            {
                output.Add($"{ book.Title}|{book.Year}|{book.Genre}|{book.MediaType}|{book.Status}|{book.Pages}|{book.Author}|{book.Format}");
            }

            File.WriteAllLines(filepath, output);
        }

        //public static string[] RewriteCheckStatus(string[] words)
        //{
        //    DateTime today = DateTime.Now;
        //    DateTime answer = today.AddDays(14);
        //    String.Format("{0:M/d/yyyy}", answer);
        //    if (words[4] == "in")
        //    {
        //        Console.WriteLine($"You have checked this out until {answer}");
        //        words[4].Replace("in", $"checked out until {answer}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Are you checking this in?");
        //        string response = Console.ReadLine();
        //        if (response == "y")
        //        {
        //            Console.WriteLine("Thank you for checking this in.");
        //            words[4].Replace(words[4], "in");
        //        }
        //        else if (response == "n")
        //        {
        //            Console.WriteLine("This book is currently checked out");//would like to add the date it is checked out until
        //        }//needs validation
        //    }
        //    return words;
        //}


    }


}
