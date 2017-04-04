﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Tables;

namespace ImageGallery.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public List<Album> Albums { get; set; }
        public List<Comment> Comments { get; set; }
    }
}