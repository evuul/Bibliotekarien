using System;
using System.Collections.Generic;

namespace Bokhylla
{
    public class Bibliotekarie
    {
        // En privat lista som representerar bokhyllan
        private List<Bok> bokhylla = new List<Bok>();

        // Metod för att lägga till en ny bok i bokhyllan
        public void LäggTillBok()
        {
            Console.WriteLine("Ange bokinformation:");

            Console.Write("Titel: ");
            string titel = Console.ReadLine();
            // Hantering för att inte registrera bok utan titel
            if (string.IsNullOrWhiteSpace(titel))
            {
                Console.WriteLine("Titel får inte vara tom. Boken har inte lagts till.");
                return;
            }

            Console.Write("Författare: ");
            string författare = Console.ReadLine();
            // Hantering för att inte registrera bok utan författare
            if (string.IsNullOrWhiteSpace(författare))
            {
                Console.WriteLine("Författare får inte vara tom. Boken har inte lagts till.");
                return;
            }

            Console.Write("Årtal: ");
            int årtal;
            // Hantering för att inte kunna lägga till ett negativt årtal
            while (!int.TryParse(Console.ReadLine(), out årtal) || årtal < 0)
            {
                Console.WriteLine("Ogiltigt årtal. Ange ett positivt heltal.");
            }

            Console.WriteLine("Vilken typ av bok är det? [1] Skönlitteratur, [2] Novell, [3] Fantasy?");
            int genreVal;
            // Hantering för ogiltigt genreval
            while (!int.TryParse(Console.ReadLine(), out genreVal) || genreVal < 1 || genreVal > 3)
            {
                Console.WriteLine("Ogiltigt val. Ange en siffra mellan 1-3.");
            }

            // Skapar en ny bok baserat på användarens val
            Bok nyBok;

            if (genreVal == 1)
            {
                nyBok = LäggTillSkönlitteratur(titel, författare, årtal);
            }
            else if (genreVal == 2)
            {
                nyBok = LäggTillNovell(titel, författare, årtal);
            }
            else if (genreVal == 3)
            {
                nyBok = LäggTillFantasy(titel, författare, årtal);
            }
            else
            {
                Console.WriteLine("Ogiltligt val. Ange en siffra mellan 1-3.");
                return;
            }

            // Lägger till nya boken i bokhyllan
            bokhylla.Add(nyBok);
            Console.WriteLine("Boken har lagts till i bokhyllan!");
        }

        // Privata hjälpmetoder för att lägga till specifika boktyper
        private Bok LäggTillSkönlitteratur(string titel, string författare, int årtal)
        {
            Console.WriteLine("Hur många sidor är boken:");
            int antalSidor;
            // Hantering för ogiltigt antal sidor
            while (!int.TryParse(Console.ReadLine(), out antalSidor) || antalSidor < 0)
            {
                Console.WriteLine("Ogiltigt antal sidor. Ange ett positivt heltal.");
            }
            return new Skönlitteratur(titel, författare, årtal, antalSidor);
        }

        private Bok LäggTillNovell(string titel, string författare, int årtal)
        {
            Console.WriteLine("Ange huvudpersoner för Novell-boken:");
            string huvudpersoner = Console.ReadLine();
            return new Novell(titel, författare, årtal, huvudpersoner);
        }

        private Bok LäggTillFantasy(string titel, string författare, int årtal)
        {
            Console.WriteLine("Ange det fiktiva universumet för Fantasy-boken:");
            string fiktivtUniversum = Console.ReadLine();
            return new Fantasy(titel, författare, årtal, fiktivtUniversum);
        }

        // Metod för att visa alla böcker i bokhyllan
        public void VisaBöcker()
        {
            Console.WriteLine("Här är utbudet av böcker i bokhyllan");

            if (bokhylla.Count == 0)
            {
                Console.WriteLine("Just nu finns inga böcker i bokhyllan.");
            }
            else
            {
                foreach (var bok in bokhylla)
                {
                    Console.WriteLine($"{bok}");
                }
            }
        }

        // Metod för att söka efter en bok baserat på en sökterm
        public void SökBok()
        {
            Console.WriteLine("Vilken bok söker du efter?");
            string sökterm = Console.ReadLine();

            if (string.IsNullOrEmpty(sökterm))
            {
                Console.WriteLine("Din sökning innehåller ingen text. Här ser du en lista på alla böcker: ");
                VisaBöcker();
                return;
            }
            bool sökningHittad = false;
            foreach (var bok in bokhylla)
            {
                if (bok.Titel.Contains(sökterm, StringComparison.OrdinalIgnoreCase) ||
                    bok.Författare.Contains(sökterm, StringComparison.OrdinalIgnoreCase) ||
                    bok.Genre.Contains(sökterm, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(bok);
                    sökningHittad = true;
                }
            }
            if (!sökningHittad)
            {
                Console.WriteLine("Jag kunde inte hitta boken du sökte efter.");
            }
        }

        // Metod för att söka på utgivningsår
        public void SökUtgivningsår()
        {
            Console.WriteLine("Vilket årtal vill du söka på? ");
            bool sökningHittad = false;

            if (int.TryParse(Console.ReadLine(), out int årtal))
            {
                foreach (var bok in bokhylla)
                {
                    if (bok.Årtal == årtal)
                    {
                        Console.WriteLine(bok);
                        sökningHittad = true;
                    }
                }
                if (!sökningHittad)
                {
                    Console.WriteLine("Inga böcker på angivet årtal hittades");
                }
            }
            else
            {
                Console.WriteLine("Ogiltligt årtal. Ange ett positivt heltal");
            }
        }
         public void SorteraBöckerEfterÅrtal()
        {
            if (bokhylla.Count == 0)
            {
                Console.WriteLine("Bokhyllan är tom och jag kan inte sortera några böcker.");
                return;
            }            
            var sorteradeBöcker = bokhylla.OrderBy(bok => bok.Årtal).ToList();

            // Uppdatera bokhyllan med sorterade böcker
            bokhylla = sorteradeBöcker;

            Console.WriteLine("Jag har sorterat böckerna efter årtal nu.");
        }

        // Metod för att radera hela bokhyllan
        public void RaderaBokhylla()
        {
            Console.WriteLine("Är du säker på att du vill radera hela din bokhylla? (J/N)");
            string svar = Console.ReadLine().ToUpper();
            while (svar != "J" && svar != "N")
            {
                Console.WriteLine("Ogiltligt svar. Svara med J eller N.");
                svar = Console.ReadLine().ToUpper();
            }
            if (svar == "J")
            {
                bokhylla.Clear();
                Console.WriteLine("Du har raderat bokhyllan");
            }
            else if (svar == "N")
            {
                Console.WriteLine("Radering av bokhyllan är avbruten");
            }
        }
    }
}
