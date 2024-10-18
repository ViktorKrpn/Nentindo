using Nentindo.Core.Domain.Companies;
using Nentindo.Core.Domain.Newsletters;
using Nentindo.Core.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nentindo.Presentation.Models.Articles
{
    public class ArticleCreateRequest
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
