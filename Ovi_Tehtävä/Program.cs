namespace Ovi_Tehtävä
{
    public class Program
    {
        static void Main(string[] args)
        {
            var validCommands = new List<string> { "avaa", "sulje", "sulje lukko", "avaa lukko" };
            DoorStates doorStates = DoorStates.Open;
            while (true)
            {
                Console.WriteLine("Hyväksytyt komennot: 'Avaa', 'Sulje', 'Sulje Lukko', 'Avaa Lukko'");
                Console.WriteLine("Ovi on nyt: " + doorStates.ToString());
                Console.WriteLine("Anna käsky: ");
                string? command = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(command) || !validCommands.Contains(command))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Virheellinen käsky: " + command);
                    Console.ResetColor();
                }

                //AUKI
                if (command == "avaa")
                {
                    Console.Clear();

                    if (doorStates == DoorStates.Closed)
                    {
                        doorStates = DoorStates.Open;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ovi on nyt auki");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ovi on jo oikeassa asennossa tai ei voi siirtyä haluttuun tilaan toiminnon suorittamiseksi.");
                        Console.ResetColor();
                    }
                }

                //KIINNI
                if (command == "sulje")
                {
                    Console.Clear();

                    if (doorStates == DoorStates.Open)
                    {
                        doorStates = DoorStates.Closed;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ovi on nyt suljettu");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ovi on joko jo oikeassa asennossa tai ei ole sopivassa tilassa toiminnon suorittamiseksi.");
                        Console.ResetColor();
                    }
                }

                //LUKITSE
                if (command == "sulje lukko")
                {
                    Console.Clear();

                    if (doorStates == DoorStates.Closed)
                    {
                        doorStates = DoorStates.Locked;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ovi on nyt lukittu");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ovi on joko jo halutussa asennossa tai ei ole oikeassa tilassa toiminnon suorittamista varten.");
                        Console.ResetColor();
                    }
                }

                //AVAA LUKKO
                if (command == "avaa lukko")
                {
                    Console.Clear();

                    if (doorStates == DoorStates.Locked)
                    {
                        doorStates = DoorStates.Closed;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ovi on nyt avattu lukosta");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ovi on joko jo halutussa asennossa tai ei ole oikeassa tilassa toiminnon suorittamiselle.");
                        Console.ResetColor();
                    }
                }

            }
        }

        public enum DoorStates
        {
            Open,
            Closed,
            Locked
        }
    }
}