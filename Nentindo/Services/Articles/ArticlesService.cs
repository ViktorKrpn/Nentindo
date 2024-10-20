using Nentindo.Core.Domain.Newsletters;
using Nentindo.Core.Domain.Users;
using Nentindo.Data;
using Nentindo.Presentation.Models.Articles;

namespace Nentindo.Services.Articles
{

    // A newsletter can contains multiple articles. One article can apper in multiple newsletters.
    public class ArticlesService: NentindoServiceBase, IArticlesService
    {

        public ArticlesService(DatabaseContext db, IHttpContextAccessor httpContextAccessor) : base(db, httpContextAccessor)
        {
        }

        public async Task<Article> CreateArticle(ArticleCreateRequest request)
        {
            var article = new Article
            {
                Title = request.Title,
                Summary = request.Summary,
                Description = request.Description,
                CompanyId = CurrentUser.CompanyId,
                CreatedByUserId = CurrentUser.Id
            };

            Db.Add(article);
            await Db.SaveChangesAsync();

            return article;
        }

        public async Task<List<Article>> Get()
        {
            return Db.Articles.ToList();
        }

    }
}
