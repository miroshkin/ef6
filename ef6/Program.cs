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

                var comicBooks = context.ComicBooks
                     //.Include(cb => cb.Series)
                     //.Include(cb => cb.Artists.Select(a => a.Artist))
                     //.Include(cb => cb.Artists.Select(a => a.Role))
                     .ToList();

                foreach (var book in comicBooks)
                {
                    if (book.Series == null)
                    {
                        context.Entry(book).Reference(cb => cb.Series)
                            .Load();
                    }

                    if (book.Series == null)
                    {
                        context.Entry(book).Reference(cb => cb.Series)
                            .Load();
                    }

                    var artistRoleNames = book.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(",", artistRoleNames);

                    Console.WriteLine(book.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                Console.ReadLine();
            }
        }
    }
}
