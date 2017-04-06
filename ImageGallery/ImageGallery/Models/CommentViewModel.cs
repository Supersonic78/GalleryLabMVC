using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageGallery.Models
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public string UserEmail { get; set; }
    }
}