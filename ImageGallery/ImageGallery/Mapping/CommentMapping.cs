using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Tables;
using ImageGallery.Models;
using WebGrease.Css.Extensions;

namespace ImageGallery.Mapping
{
    public static class CommentMapping
    {
        public static CommentViewModel ToModel(this Comment entity)
        {
            var model = new CommentViewModel()
            {
                Id = entity.Id,
                Text = entity.Text,
              //  User = entity.User.ToModel(),
            };

            return model;
        }
        public static List<CommentViewModel> ToModel(this ICollection<Comment> entitys)
        {
            var model = new List<CommentViewModel>();

            // ALternativ 1
            entitys.ForEach(x=> model.Add(x.ToModel()));

            // ALternativ 2
            //foreach (var comment in entitys)
            //{
            //    model.Add(comment.ToModel());
            //}


            return model;
        }
    }
}