﻿using System;
using System.Collections.Generic;
using System.Text;
using Influencers.Models;
namespace Influencers.BusinessLogic.ViewModels.ArticleViewModels
{
    public class ArticleListViewModel
    {
        public List<ViewArticleViewModel> Articles { get; set; }
        public IEnumerable<Tuple<Tag,int>> MostUsedTags { get; set; }
        public string FilteredByTag { get; set; }
    }
}
