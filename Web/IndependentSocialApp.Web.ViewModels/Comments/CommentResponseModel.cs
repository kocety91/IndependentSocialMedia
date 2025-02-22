﻿namespace IndependentSocialApp.Web.ViewModels.Comments
{
    using System.Collections.Generic;
    using System.Linq;

    public class CommentResponseModel
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public int RepliesCount => this.Parent.Count();

        public int LikesCount { get; set; }

        public ICollection<CommentParent> Parent { get; set; }
    }
}
