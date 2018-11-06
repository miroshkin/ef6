using System;
using System.Linq;
using ef6.Models;
using System.Data.Entity;
using EFTestApp.Models;

namespace ef6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var series1 = new Series() {Title = "The Amazing Spider-Man"};
                var series2 = new Series() {Title = "The Invincible Iron Man"};

                var artist1 = new Artist {Name = "Stan Ley"};
                var artist2 = new Artist {Name = "John Smith"};
                var artist3 = new Artist {Name = "Jack Kirbey"};

                var role1 = new Role()
                {
                    Name = "Script"
                };

                var role2 = new Role()
                {
                    Name = "Pencils"
                };


                var comicBook1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicBook1.AddArtist(artist1,role1);
                comicBook1.AddArtist(artist2, role2);

                context.ComicBooks.Add(comicBook1);

                var comicBook2 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };

                comicBook2.AddArtist(artist2, role1);
                comicBook2.AddArtist(artist3, role2);

                context.ComicBooks.Add(comicBook2);

                var comicBook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };

                context.ComicBooks.Add(comicBook3);
                context.SaveChanges();

                var books = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();

                foreach (var book in books)
                {
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
