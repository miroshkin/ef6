using System;
using System.Linq;
using ef6.Models;
using System.Data.Entity;
using System.Diagnostics;
using EFTestApp.Models;

namespace ef6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                //var comicBooks = context.ComicBooks.ToList();

                
                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .ToList()
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    .ThenBy(cb => cb.PublishedOn)
                //    .ToList();

                var comicBooksQuery = context.ComicBooks
                    .Include(cb => cb.Series)
                    .OrderByDescending(cb => cb.IssueNumber);
                var comicBooks = comicBooksQuery.ToList();
                var comicBooks2 = comicBooksQuery
                    .Where(cb => cb.AverageRating < 7)
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }
                Console.WriteLine();
                Console.WriteLine("# of comic books:{0}", comicBooks.Count);

                Console.WriteLine();

                foreach (var comicBook in comicBooks2)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }

                Console.WriteLine();
                Console.WriteLine("# of comic books:{0}", comicBooks2.Count);

                //var books = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a => a.Artist))
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var book in books)
                //{
                //    var artistRoleNames = book.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(",", artistRoleNames);

                //    Console.WriteLine(book.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}

                Console.ReadLine();
            }
        }
    }
}
