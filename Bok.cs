using System;

namespace Bokhylla
{
    // Klass för alla typer av böcker
    public class Bok
    {
        // Här är mina egenskaer
        public string Titel { get; set; }
        public string Författare { get; set; }
        public int Årtal { get; set; }
        public string Genre { get; set; }

        // Konstruktor för att skapa en ny bok med specificerade egenskaper
        public Bok(string titel, string författare, int årtal, string genre)
        {
            Titel = titel;
            Författare = författare;
            Årtal = årtal;
            Genre = genre;
        }

        // Överskuggar ToString-metoden för att ge en formaterad strängrepresentation av boken
        public override string ToString()
        {
            return $" Titel: {Titel}, Författare: {Författare}, Årtal: {Årtal}, Genre: {Genre}";
        }
    }

    // Underklass för skönlitteratur med ytterligare attribut
    public class Skönlitteratur : Bok
    {
        public int AntalSidor { get; set; }

        // Konstruktor som använder grundklassens konstruktor och lägger till antal sidor
        public Skönlitteratur(string titel, string författare, int årtal, int antalSidor) : base(titel, författare, årtal, "Skönlitteratur")
        {
            AntalSidor = antalSidor;
        }

        // Överskuggar ToString-metoden för att inkludera antal sidor
        public override string ToString()
        {
            return base.ToString() + $", antal sidor: {AntalSidor}";
        }
    }

    // Underklass för fantasy med ytterligare attribut
    public class Fantasy : Bok
    {
        public string FiktivtUniversum { get; set; }

        // Konstruktor som använder grundklassens konstruktor och lägger till fiktivt universum
        public Fantasy(string titel, string författare, int årtal, string fiktivtUniversum) : base(titel, författare, årtal, "Fantasy")
        {
            FiktivtUniversum = fiktivtUniversum;
        }

        // Överskuggar ToString-metoden för att inkludera fiktivt universum
        public override string ToString()
        {
            return base.ToString() + $", fiktivt universum: {FiktivtUniversum}";
        }
    }

    // Underklass för novell med ytterligare attribut
    public class Novell : Bok
    {
        public string Huvudpersoner { get; set; }

        // Konstruktor som använder grundklassens konstruktor och lägger till huvudpersoner
        public Novell(string titel, string författare, int årtal, string huvudpersoner) : base(titel, författare, årtal, "Novell")
        {
            Huvudpersoner = huvudpersoner;
        }

        // Överskuggar ToString-metoden för att inkludera huvudpersoner
        public override string ToString()
        {
            return base.ToString() + $", huvudpersoner: {Huvudpersoner}";
        }
    }
}
