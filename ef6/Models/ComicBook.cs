using System;

namespace ef6.Models
{
    public class ComicBook
    {
        // ID, ComicBookId, ComicBookID
        public int ComicBookId { get; set; }
        public Series Series { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }   
        public decimal? AverageRating { get; set; }

        public string DisplayText
        {
            get
            {
               return $"{Series?.Title} #{IssueNumber}";
            }
        }
    }
}
