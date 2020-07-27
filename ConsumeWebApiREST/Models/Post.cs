using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebApiREST.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedTime { get; set; }
        public string AuthorName { get; set; }
        public string TotalLikes { get; set; }
    }
}