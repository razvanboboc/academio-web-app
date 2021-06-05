using Influencers.BusinessLogic.Services;
using Influencers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Influencers.Controllers
{
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly TagService tagService;

        public TagController(ILogger<TagController> logger, TagService tagService)
        {
            _logger = logger;
            this.tagService = tagService;
        }

        [HttpGet]
        public JsonResult GetMostUsedTags()
        {
            return Json(tagService.GetMostUsedTags());
        }
    }
}
