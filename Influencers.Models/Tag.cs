﻿using System;
using System.Collections.Generic;

namespace Influencers.Models
{
    public partial class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArticleTags> Articles { get; set; }
    }
}
