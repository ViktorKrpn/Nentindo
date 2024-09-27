using Nentindo.Core.Domain.Newsletter;
using Nentindo.Core.Domain.Users;

namespace Nentindo.Core.Domain.Newsletters
{
    public class Newsletter
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual List<User> CreatedByUser { get; set; }
        public virtual List<Article> Articles { get; set; } = [];
        public int OrganizationId { get; set; }

    }
}
