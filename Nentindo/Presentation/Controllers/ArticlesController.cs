using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nentindo.Core.Domain.Newsletters;
using Nentindo.Data;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Articles;
using Nentindo.Presentation.Models.Contacts;
using Nentindo.Services.Articles;
using Nentindo.Services.Contacts;
using System.Security.Claims;

namespace Nentindo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ArticlesController : NentindoControllerBase
    {
        IArticlesService _articlesService;
        public ArticlesController(DatabaseContext db, IArticlesService articlesService) : base(db)
        {
            _articlesService = articlesService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateArticle(ArticleCreateRequest request)
        {
            var response = new GenericResponse<Article>();
            try
            {
                response.Result = await _articlesService.CreateArticle(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllArticles()
        {
            var response = new GenericResponse<List<Article>>();
            try
            {
                response.Result = await _articlesService.Get();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
