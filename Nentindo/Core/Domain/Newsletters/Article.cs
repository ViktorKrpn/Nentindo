using Nentindo.Core.Domain.Companies;
using Nentindo.Core.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nentindo.Core.Domain.Newsletters
{
    /// <summary>
    /// The class is missing the logic for images for simplicity reasons.
    /// </summary>
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual User CreatedByUser { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        // probably should be many to many
        public int? NewsletterId { get; set; }
        public virtual Newsletter Newsletter { get; set; }

    }
}
