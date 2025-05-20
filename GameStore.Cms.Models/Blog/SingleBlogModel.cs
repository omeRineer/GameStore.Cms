﻿namespace GameStore.Cms.Models.Blog
{
    public class SingleBlogModel
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public Common.File CoverImage { get; set; }

    }
}
