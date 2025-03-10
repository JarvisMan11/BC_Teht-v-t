Ruoka_annos_Generaattori_Tehtävä
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p_valids = new List<string> { "lohi", "lammas", "tofu" };
            var l_valids = new List<string> { "kvinoa", "bulgur", "couscous" };
            var k_valids = new List<string> { "chili", "valkosipuli", "yrttimausteet" };
            var ateriat = new List<string> { "" };
            int tilausnumero = 0;

            Paaraakaaine paaraakaaine = Paaraakaaine.nauta;
            Lisuke lisuke = Lisuke.peruna;
            Kastike kastike = Kastike.curry;

            Console.WriteLine("Tervetuloa ravintolaan. Valitkaa annoksenne ruokaaineet:");

            while (true)
            {
                while (tilausnumero < 3)
                {
                    tilausnumero++;
                    Console.WriteLine("Valitse pääruoka-aine: Lohi, Lammas tai Tofu");
                    string? p_valinta = Console.ReadLine()?.ToLower();
                    if (string.IsNullOrEmpty(p_valinta) || !p_valids.Contains(p_valinta))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Virheellinen valinta: '{p_valinta}' ei ole kelvollinen.");
                        Console.ResetColor();
                        return;
                    }
                    paaraakaaine = (Paaraakaaine)Enum.Parse(typeof(Paaraakaaine), p_valinta);

                    Console.WriteLine("Valitse lisuke: Kvinoa, Bulgur tai Couscous");
                    string? l_valinta = Console.ReadLine()?.ToLower();
                    if (string.IsNullOrEmpty(l_valinta) || !l_valids.Contains(l_valinta))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Virheellinen valinta: '{l_valinta}' ei ole kelvollinen.");
                        Console.ResetColor();
                        return;
                    }
                    lisuke = (Lisuke)Enum.Parse(typeof(Lisuke), l_valinta);

                    Console.WriteLine("Valitse kastike: Chili, Valkosipuli tai Yrttimausteet");
                    string? k_valinta = Console.ReadLine()?.ToLower();
                    if (string.IsNullOrEmpty(k_valinta) || !k_valids.Contains(k_valinta))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Virheellinen valinta: '{k_valinta}' ei ole kelvollinen.");
                        Console.ResetColor();
                        return;
                    }
                    kastike = (Kastike)Enum.Parse(typeof(Kastike), k_valinta);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    ateriat.Add($"Ateria {tilausnumero}: {paaraakaaine} ja {lisuke}, {kastike}-kastikkeella.");
                    Console.WriteLine($"Ateriasi on nyt tallennettu listaan, numerolla {tilausnumero}. Valitsit {paaraakaaine} ja {lisuke} {kastike}-kastikkeella.");
                    Console.ResetColor();
                }

                while (tilausnumero == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    foreach (var ateria in ateriat)
                    {
                        Console.WriteLine(ateria);
                    }
                    Console.ResetColor();
                    return;
                }
            }
        }

        public enum Paaraakaaine
        {
            lohi,
            lammas,
            tofu
        }

        public enum Lisuke
        {
            kvinoa,
            bulgur,
            couscous
        }

        public enum Kastike
        {
            chili,
            valkosipuli,
            yrttimausteet
        }
    }
}
