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

                var comicBookId = 1;
                //var comicBook1 = context.ComicBooks.Find(comicBookId);
                //var comicBook2 = context.ComicBooks.Find(comicBookId);

                var comicBook1 = context.ComicBooks.SingleOrDefault(cb => cb.ComicBookId == comicBookId);
                comicBook1.Description = "New value";

                Debug.WriteLine("Changing the Description property value");
                var comicBook2 = context.ComicBooks.SingleOrDefault(cb => cb.ComicBookId == comicBookId);








                //var comicBooks = context.ComicBooks
                //     //.Include(cb => cb.Series)
                //     //.Include(cb => cb.Artists.Select(a => a.Artist))
                //     //.Include(cb => cb.Artists.Select(a => a.Role))
                //     .ToList();

                //foreach (var book in comicBooks)
                //{
                //    if (book.Series == null)
                //    {
                //        context.Entry(book).Reference(cb => cb.Series)
                //            .Load();
                //    }

                //    if (book.Series == null)
                //    {
                //        context.Entry(book).Reference(cb => cb.Series)
                //            .Load();
                //    }

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
