using Influencers.Models;
using Influencers.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace Influencers.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(InfluencersContext dbContext) : base(dbContext)
        {

        }

        public void AddTags(MatchCollection extractedHashtags)
        {
            foreach (var hashtag in extractedHashtags)
            {
                if (!TagExists(hashtag.ToString()))
                {
                    Add(new Tag() { Name = hashtag.ToString() });
                }

            }
        }

        public MatchCollection FilterHashtags(string tags)
        {
            MatchCollection hashtags = Regex.Matches(tags, @"[#]{1}[A-Za-z0-9-_]+\b");

            return hashtags;
        }

        //public IEnumerable<Tags> FilterSearchedTags(string tags)
        //{
        //    var searchedHashTags = FilterHashtags(tags).ToList();


        //}

        public Tag GetTagByName(string tagName)
        {
            return dbContext.Tags.Where(t => t.Name == tagName).SingleOrDefault();
        }

        public bool TagExists(string tag)
        {

            var tags = dbContext.Tags.Where(t => t.Name == tag).Count();

            if (tags != 0)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<Tuple<Tag, int>> GetMostUsedTags()
        {
            var mostUsedTags = dbContext.Tags
                .Select(t => new
                {
                    Tag = t,
                    Count = t.Articles.Count()
                })
                .OrderByDescending(x => x.Count)
                .AsEnumerable()
                .Select(t => new Tuple<Tag, int>(t.Tag, t.Count));

            return mostUsedTags;
        }
    }
}
