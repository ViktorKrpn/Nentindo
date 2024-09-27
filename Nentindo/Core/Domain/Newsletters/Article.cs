using Nentindo.Core.Domain.Users;

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
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
    }
}
