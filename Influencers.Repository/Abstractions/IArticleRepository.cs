﻿using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.Repository.Abstractions
{
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable<Article> GetArticlesByAuthorId(int authorId);
    }
}
