using System;

namespace Bokhylla
{
    class Program
    {
        // Skapar en instans av Bibliotekarie för att hantera bokhyllan
        static Bibliotekarie bibliotekarie = new Bibliotekarie();
        static void Main(string[] args)
        {
            // Variabel som håller koll på om programmet ska fortsätta köras
            bool isRunning = true;
            
            Console.WriteLine("Välkommen till Bibliotekarien!");
            Console.WriteLine("Jag är bibliotekarie till bokhyllan.");

            // Huvudloopen för programmet
            while (isRunning)
            {
                // Menyval
                Console.WriteLine("[1] Lägg till en ny bok: ");
                Console.WriteLine("[2] Visa alla böcker: ");
                Console.WriteLine("[3] Sök efter bok: ");
                Console.WriteLine("[4] Sök efter utgivningsår: ");
                Console.WriteLine("[5] Sortera böcker på utgivningsår: ");
                Console.WriteLine("[6] Radera allt i bokhyllan: ");
                Console.WriteLine("[7] Avsluta program: ");

                // Läser in användarens val
                string val = Console.ReadLine();

                // Hanterar användarens val med en switch-sats
                switch (val)
                {
                    case "1":
                        bibliotekarie.LäggTillBok();
                        break;
                    case "2":
                        bibliotekarie.VisaBöcker();
                        break;
                    case "3":
                        bibliotekarie.SökBok();
                        break;
                    case "4":
                        bibliotekarie.SökUtgivningsår();
                        break;
                    case "5":
                        bibliotekarie.SorteraBöckerEfterÅrtal();
                        break;
                    case "6":
                        bibliotekarie.RaderaBokhylla();
                        break;
                    case "7":
                        // Avslutar programmet
                        isRunning = false;
                        break;                
                    default:
                        Console.WriteLine("Ogiltligt val. Välj mellan 1-5");
                        break;
                }
            }
        }
    }
}
