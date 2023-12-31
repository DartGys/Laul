﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class Album
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime PublishDate { get; set; }
        public string Genre { get; set; }
        public Guid ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
