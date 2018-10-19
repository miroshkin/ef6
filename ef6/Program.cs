using System;
using System.Linq;
using ef6.Models;
using System.Data.Entity;
namespace ef6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var series = new Series() {Title = "The Amazing Spider-Man"};
                context.ComicBooks.Add(
                new ComicBook()
                        {
                        Series = series,
                        IssueNumber = 1,
                        PublishedOn = DateTime.Today
                        }
                );
                context.ComicBooks.Add(
                    new ComicBook()
                    {
                        Series = series,
                        IssueNumber = 2,
                        PublishedOn = DateTime.Today
                    }
                );
                context.SaveChanges();

                var books = context.ComicBooks
                    .Include(cb => cb.Series)
                    .ToList();

                foreach (var book in books)
                {
                    Console.WriteLine(book.DisplayText);
                }
                Console.ReadLine();
            }
        }
    }
}
