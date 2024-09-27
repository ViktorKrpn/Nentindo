namespace Nentindo.Database.Models
{
    public class ResponsibilityArea
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }



    public class Subscribtion
    {
        public int Id { get; set; }
        public int ConcactId { get;set; }
        public virtual Contact Contact { get; set; }
    }

}


/*
 Die Leiter der entsprechenden Bereiche dürfen Artikel für die jeweilige Zielgruppe erstellen und  versenden.
 Mitarbeitende der Hauptorganisation dürfen Artikel für alle Themenbereiche erstellen. 
 Mitarbeitende der Unterorganisationen ist es nur gestattet, Newsletter für ihre eigenen Themenbereiche und Unterorganisationen senden.

    

 */