using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTestApp.Models
{
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }
        public int Id { get; set; }

        [Required, StringLength(100), Column("FullName")]
        public string Name { get; set; }

        public ICollection<ComicBookArtist> ComicBooks { get; set; }

    }
}
