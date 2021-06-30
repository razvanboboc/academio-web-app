 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Influencers.BusinessLogic.Services;
using Influencers.BusinessLogic.ViewModels.ArticleViewModels;
using Influencers.BusinessLogic.ViewModels.AuthorViewModels;
using Influencers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Influencers.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly AuthorService authorService;

        public AuthorController(ILogger<ArticleController> logger, AuthorService authorService)
        {
            _logger = logger;
            this.authorService = authorService;
        }

        [HttpGet]
        public IActionResult JoinInfluencers()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Ranking()
        { 
            var authors = authorService.GetAll();
            var orderedAuthorsDescendingly = authorService.OrderAuthorsDescendingByVotes(authors);
            return View(new RankingViewModel { Authors = orderedAuthorsDescendingly });
        }
        [HttpPost]
        public IActionResult JoinInfluencers([FromForm]AddAuthorViewModel model)
        {
            authorService.Add(model.Nickname, model.Email);

            return Redirect(Url.Action("Index", "Article"));
        }
    }
}