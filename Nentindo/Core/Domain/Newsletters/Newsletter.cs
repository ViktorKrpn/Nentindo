using Nentindo.Core.Domain.Companies;
using Nentindo.Core.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nentindo.Core.Domain.Newsletters
{
    public class Newsletter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual User CreatedByUser { get; set; }
        public virtual List<Article> Articles { get; set; } = [];
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
