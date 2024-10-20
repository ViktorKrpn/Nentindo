using Nentindo.Core.Domain.Newsletters;
using Nentindo.Core.Domain.Users;
using Nentindo.Presentation.Models.Articles;

namespace Nentindo.Services.Articles
{
    public interface IArticlesService
    {
        public Task<Article> CreateArticle(ArticleCreateRequest request);
        public Task<List<Article>> Get();
    }
}
