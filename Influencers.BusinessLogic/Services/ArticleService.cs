﻿using Influencers.Models;
using Influencers.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic.Services
{
    public class ArticleService
    {
        private IArticleRepository articleRepository;
        private IAuthorRepository authorRepository;

        public ArticleService(IArticleRepository articleRepository, IAuthorRepository authorRepository)
        {
            this.articleRepository = articleRepository;
            this.authorRepository = authorRepository;
        }
        public void UpdateArticleVotes(int articleId, int flag)
        {
            articleRepository.UpdateArticleVotes(articleId, flag);
        }

        public IEnumerable<Article> GetAll()
        {
            var articles = articleRepository.GetAll();

            return articles;
        }

        public void AddArticle(string title, string content, string email)
        {
            var author = authorRepository.GetAuthorByEmail(email);

            articleRepository.Add(new Article()
            {
                Title = title,
                Content = content,
                AddedTime = DateTime.Now,
                Author = author,
                Votes = 0,
            });
        }

        public void UpdateArticle(int articleId, string content)
        {
            var article = articleRepository.GetArticleById(articleId);

            article.Content = content;

            articleRepository.Update(article);
        }

        public Article GetArticleById(int id)
        {
            return articleRepository.GetArticleById(id);
        }

        public IEnumerable<Article> GetPreviewedArticles(IEnumerable<Article> articles)
        {
            return articleRepository.GetPreviewedArticles(articles);
        }

        public IEnumerable<Article> OrderArticlesDescendinglyByVotes(IEnumerable<Article> articles)
        {
            return articleRepository.OrderArticlesDescendinglyByVotes(articles);
        }

        public IEnumerable<Article> OrderArticleMostRecent(IEnumerable<Article> articles)
        {
            return articleRepository.OrderArticleMostRecent(articles);
        }

        public IEnumerable<Article> CategorizeHot(IEnumerable<Article> articles)
        {
            return articleRepository.CategorizeHot(articles);
        }
        public Article GetNewestAddedArticle(string title, string content, string email)
        {
            return articleRepository.GetNewestAddedArticle(title, content, email);
        }

    }
}
