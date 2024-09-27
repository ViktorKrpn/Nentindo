namespace Nentindo.Core.Domain.Contacts
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }
}
