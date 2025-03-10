using System;
using System.Runtime.CompilerServices;
namespace Nuoli_Kauppa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nuoli uusiNuoli = new Nuoli("", "", 0);
            string? input;
            Console.WriteLine("Astupa sisään nuolikauppaan! Minkälaiset kärjet sopisivat parhaiten tarpeisiisi? Valikoimastamme löydät puuta, terästä ja timanttia valinta on sinun!: ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input)) { uusiNuoli.AsetaKarki(input.ToLower()); }
            Console.ResetColor();
            Console.WriteLine("Hieno valinta! Seuraavaksi päätetään nuolensulan materiaali. Haluatko sen olevan kevyt lehti, perinteinen kanansulka vai majesteettinen kotkansulka? Valitse viisaasti!: ");
            Console.ForegroundColor = ConsoleColor.Green;

            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input)) { uusiNuoli.AsetaSulka(input.ToLower()); }
            Console.ResetColor();
            Console.WriteLine("Mahtavaa! Nyt valitaan vielä nuolen pituus. Haluatko sen olevan 60 cm, 100 cm vai jotain siltä väliltä? Päätä, mikä sopii parhaiten tarpeisiisi!: ");
            Console.ForegroundColor = ConsoleColor.Green;

            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input)) { uusiNuoli.AsetaPituus(int.Parse(input)); }
            input = null;

            Console.ResetColor();
            Console.Clear();

            string teksti = uusiNuoli.AnnaNuoli();
            Console.WriteLine(teksti);
        }

        public class Nuoli
        {
            private string karki;
            private string sulka;
            private int pituus;
            private float hinta;

            public Nuoli(string karki, string sulka, int pituus)
            {
                this.karki = karki;
                this.sulka = sulka;
                this.pituus = pituus;
                this.pituus = 0;
                this.hinta = 0f;
            }
            public void AsetaKarki(string karki)
            {
                this.karki = karki;
            }
            public void AsetaSulka(string sulka)
            {
                this.sulka = sulka;
            }
            public void AsetaPituus(int pituus)
            {
                this.pituus = pituus;
            }
            public string AnnaNuoli()
            {
                LaskeHinta();
                string teksti = $"Nuolesi kärki on nytten siis {karki}, sulka on {sulka} ja nuolen pituus on {pituus}. Kokonaishinta nuolelle on {hinta}";
                return teksti;
            }

            private double LaskeHinta()
            {
                if (karki == "puu") hinta += 3f;
                if (karki == "teräs") hinta += 5f;
                if (karki == "timantti") hinta += 50f;

                if (sulka == "lehti") hinta += 0f;
                if (sulka == "kanansulka") hinta += 1f;
                if (sulka == "kotkansulka") hinta += 5f;

                for (int i = 0; i < pituus; i++)
                {
                    hinta += 0.05f;
                }
                
                return hinta;
            }
        }
    }
}