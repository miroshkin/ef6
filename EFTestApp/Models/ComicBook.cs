using System;

namespace ef6.Models
{
    public class ComicBook
    {
        // ID, ComicBookId, ComicBookID
        public int ComicBookId { get; set; }
        public string SeriesTitle { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }   
    }
}
