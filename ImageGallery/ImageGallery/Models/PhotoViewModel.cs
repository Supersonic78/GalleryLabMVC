﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Models
{
    public class PhotoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<CommentViewModel> Comments { get; set; }

        public AlbumViewModel Album { get; set; }
        public Guid AlbumRefId { get; set; }
    }
}