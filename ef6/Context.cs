using System.Data.Entity;
using ef6.Models;

namespace ef6
{
    public class Context:DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}