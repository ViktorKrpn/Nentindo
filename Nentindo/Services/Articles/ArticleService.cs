using Nentindo.Core.Domain.Newsletters;
using Nentindo.Data;
using Nentindo.Presentation.Models.Articles;

namespace Nentindo.Services.Articles
{
    public class ArticleService
    {
        DatabaseContext _db;

        public ArticleService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task CreateArticle(ArticleCreateRequest request)
        {
            var article = new Article
            {
                Title = request.Title,
                Summary = request.Summary,
                Description = request.Description,
                CompanyId = request.CompanyId,
            };

            _db.Add(article);
            await _db.SaveChangesAsync();

        }

    }
}
