using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;

namespace DAL.Repositories
{
    class CommentRepository
    {
        public List<Comment> Get()
        {
            using (var ctx = new GalleryContext())
            {
                return ctx.Comments.ToList();
            } 
        }
    }
}
