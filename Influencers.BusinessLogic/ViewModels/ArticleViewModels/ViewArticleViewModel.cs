using Influencers.BusinessLogic.DTOs;
using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic.ViewModels.ArticleViewModels
{
    public class ViewArticleViewModel
    {
        public Article Article { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<Tuple<Tag, int>> MostUsedTags { get; set; }
     }
}
