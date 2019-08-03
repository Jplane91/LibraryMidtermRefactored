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

                bookInfo.Add(newBook);
            }


            return bookInfo;
            
        }

        public static void PrintBookList(List<Book> list)
        {
            foreach(var book in list)
            {
                Console.WriteLine();
                Console.WriteLine("Title: " + book.Title + "\nAuthor: " + book.Author + "\nPages: " + book.Pages + "\nYear Published: " + book.Year);
            }
        }
        public static void SearchBookTitle(List<Book> list)
        {
            Console.WriteLine("Enter keyword for the title");
            string userBookTitleSearch = Console.ReadLine();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var book in list)
            {
                if(book.Title.Contains(userBookTitleSearch))
                {
                     Console.WriteLine("Title: " + book.Title + "\nAuthor: " + book.Author + "\nPages: " + book.Pages + "\nYear Published: " + book.Year);
                }
            }
                
        }

        public static void SearchBookAuthor(List<Book> list)
        {
            Console.WriteLine("Enter keywod for the author");
            string userAuthorSearch = Console.ReadLine();
            Console.WriteLine("Here are the results from the search: \n");
            foreach (var book in list)
            {
                if (book.Author.Contains(userAuthorSearch))
                {
                    Console.WriteLine("Author: " + book.Author + "\nTitle: " + book.Title +  "\nPages: " + book.Pages + "\nYear Published: " + book.Year);
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


            list.Add(new Book
            {
                Title = userBookTitle,
                Year = userBookYear,
                Genre = userBookGenre,
                MediaType = "Book",
                Status = "In",
                Pages = userBookPages,
                Author = userBookAuthor
            });

            List<string> output = new List<string>();
            foreach (var book in list)
            {
                output.Add($"{ book.Title}|{book.Year}|{book.Genre}|{book.MediaType}|{book.Status}|{book.Pages}|{book.Author}");
            }

            File.WriteAllLines(filepath, output);
        }
            

    }


}
