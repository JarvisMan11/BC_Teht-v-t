using System;

class Tavara
{
    public double Paino { get; set; }
    public double Tilavuus { get; set; }

    public Tavara(double paino, double tilavuus)
    {
        Paino = paino;
        Tilavuus = tilavuus;
    }
}

class Nuoli : Tavara
{
    public Nuoli() : base(0.1, 0.05) { }
}

class Jousi : Tavara
{
    public Jousi() : base(1, 4) { }
}

class Köysi : Tavara
{
    public Köysi() : base(1, 1.5) { }
}

class Vesi : Tavara
{
    public Vesi() : base(2, 2) { }
}

class RuokaAnnos : Tavara
{
    public RuokaAnnos() : base(1, 0.5) { }
}

class Miekka : Tavara
{
    public Miekka() : base(5, 3) { }
}

class Reppu
{
    public int MaxTavarat { get; set; }
    public double MaxPaino { get; set; }
    public double MaxTilavuus { get; set; }

    private Tavara[] tavarat;
    private int tavaratCount;

    public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
    {
        MaxTavarat = maxTavarat;
        MaxPaino = maxPaino;
        MaxTilavuus = maxTilavuus;
        tavarat = new Tavara[maxTavarat];
        tavaratCount = 0;
    }

    public bool Lisää(Tavara tavara)
    {
        double nykyinenPaino = 0;
        double nykyinenTilavuus = 0;

        foreach (var t in tavarat)
        {
            if (t != null)
            {
                nykyinenPaino += t.Paino;
                nykyinenTilavuus += t.Tilavuus;
            }
        }

        if (tavaratCount >= MaxTavarat || nykyinenPaino + tavara.Paino > MaxPaino || nykyinenTilavuus + tavara.Tilavuus > MaxTilavuus)
        {
            return false;
        }

        tavarat[tavaratCount++] = tavara;
        return true;
    }

    public void NäytäTiedot()
    {
        double nykyinenPaino = 0;
        double nykyinenTilavuus = 0;

        foreach (var t in tavarat)
        {
            if (t != null)
            {
                nykyinenPaino += t.Paino;
                nykyinenTilavuus += t.Tilavuus;
            }
        }

        Console.Clear();
        Console.WriteLine($"Reppussa on tällä hetkellä {tavaratCount}/{MaxTavarat} tavaraa, {nykyinenPaino}/{MaxPaino} painoa ja {nykyinenTilavuus}/{MaxTilavuus} tilavuutta.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reppu reppu = new Reppu(10, 30, 20);
        Tavara nuoli = new Nuoli();
        Tavara jousi = new Jousi();
        Tavara köysi = new Köysi();
        Tavara vesi = new Vesi();
        Tavara ruoka = new RuokaAnnos();
        Tavara miekka = new Miekka();

        while (true)
        {
            reppu.NäytäTiedot();

            Console.WriteLine("\nValitse toiminto:");
            Console.WriteLine("1. Lisää Nuoli");
            Console.WriteLine("2. Lisää Jousi");
            Console.WriteLine("3. Lisää Köysi");
            Console.WriteLine("4. Lisää Vesi");
            Console.WriteLine("5. Lisää Ruoka-annos");
            Console.WriteLine("6. Lisää Miekka");
            Console.WriteLine("7. Lopeta");

            string valinta = Console.ReadLine()!;

            switch (valinta)
            {
                case "1":
                    if (!reppu.Lisää(nuoli))
                    {
                        Console.WriteLine("Reppu on täynnä.");
                    }
                    break;
                case "2":
                    if (!reppu.Lisää(jousi))
                    {
                        Console.WriteLine("Reppu on täynnä.");
                    }
                    break;
                case "3":
                    if (!reppu.Lisää(köysi))
                    {
                        Console.WriteLine("Reppu on täynnä.");
                    }
                    break;
                case "4":
                    if (!reppu.Lisää(vesi))
                    {
                        Console.WriteLine("Reppu on täynnä.");
                    }
                    break;
                case "5":
                    if (!reppu.Lisää(ruoka))
                    {
                        Console.WriteLine("Reppu on täynnä.");
                    }
                    break;
                case "6":
                    if (!reppu.Lisää(miekka))
                    {
                        Console.WriteLine("Reppu on täynnä.");
                    }
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Virheellinen valinta.");
                    break;
            }

            System.Threading.Thread.Sleep(1000);
        }
    }
}
