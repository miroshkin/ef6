﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EFTestApp.Models;

namespace ef6.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }
        // ID, ComicBookId, ComicBookID
        public int ComicBookId { get; set; }

        public int SeriesId { get; set; }
        public virtual Series Series { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }   
        public decimal? AverageRating { get; set; }

        public virtual ICollection<ComicBookArtist> Artists { get; set; }

        public string DisplayText
        {
            get
            {
               return $"{Series?.Title} #{IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}
