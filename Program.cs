using System;
using System.ComponentModel;
using static UTBDochazkaProjekt.Program;

namespace UTBDochazkaProjekt
{
    internal class Program
    {
        public struct Ukol
        {

            public Ukol(string id, string popis)
            {
                ID = id;
                Popis = popis;
            }

            public string ID { get; set; }
            public string Popis { get; set; }

        }

        static void Main(string[] args)
        {
            var ukoly = new List<Ukol>();
            string[] randomFakta = { 
                "Starověké kořeny: Seznamy úkolů existují již staletí. Starověcí Římané zvykli zapisovat úkoly na voskové tabulky s hrotem.",
                "Systém Benjamina Franklina: Benjamin Franklin je často připisován popularizaci seznamů úkolů. Měl denní rozvrh, který obsahoval seznam úkolů, které chtěl dokončit.",
                "Psychologické výhody: Vytváření seznamu úkolů může snížit úzkost a stres. Pomáhá lidem cítit se více organizovaní a mít kontrolu nad svými úkoly.",
                "Digitální transformace: S nástupem technologie se staly digitální aplikace a software pro seznamy úkolů velmi populárními. Nabízejí funkce jako upomínky a synchronizaci mezi zařízeními.",
                "Prioritizace: Seznamy úkolů jsou často organizovány pomocí metod prioritizace, jako je Eisenhowerova matice, která úkoly kategorizuje do čtyř kvadrantů podle naléhavosti a důležitosti."
            };


            while (true)
            {
                int spravnyVysledek = 30 + 15;

                Console.WriteLine("Vítejte v todolistu");
                Console.Write("captcha: 30 + 15 = ");
                int captchaInput = int.Parse(Console.ReadLine());

                if (captchaInput == spravnyVysledek)
                {
                    Console.WriteLine("Splneno");
                    break;
                }
                else
                {
                    Console.WriteLine("Zkuste to znovu\n");
                }
            }

            while (true)
            {
                Console.WriteLine("\nVyberte z následujících možností:\n");
                Console.WriteLine("1. Zobrazit seznam úkolů");
                Console.WriteLine("2. Přidat úkol");
                Console.WriteLine("3. Odstranit úkol");
                Console.WriteLine("4. Random fakt o todolistech");
                Console.WriteLine("5. Ukončit program\n");

                Console.Write("Volba: ");
                int volba = int.Parse(Console.ReadLine());

                switch (volba)
                {
                    // Vypis sezamu ukolů
                    case 1:
                        Console.WriteLine("Seznam úkolů:\n");

                        for (int i = 0; i < ukoly.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {ukoly[i].Popis}  {ukoly[i].ID}");
                        }

                        Console.WriteLine("\n");

                        break;

                    // Pridat ukol
                    case 2:
                        Console.Write("Napiste popis ukolu: ");
                        string popis = Console.ReadLine();

                        var utilMethods = new UtilityMethods();
                        string id = utilMethods.generateID();

                        try {
                            ukoly.Add(new Ukol(id, popis));
                        } catch (Exception e) {
                            Console.WriteLine($"Exception: {e}");
                        }

                        Console.WriteLine("Ukol uspesne pridan");
                        break;

                    // Odstranit ukol
                    case 3:
                        Console.Write("Napiste ID ukolu: ");
                        string userInputId = Console.ReadLine();
                        bool odebrano = false;

                        if (ukoly.Count > 0)
                        {
                            foreach (var item in ukoly.ToList())
                            {
                                if (item.ID == userInputId && userInputId is String)
                                {
                                    ukoly.Remove(item);
                                    odebrano = true;
                                    Console.WriteLine("Ukol uspesne odstranen");
                                }
                            }

                            if (!odebrano)
                            {
                                Console.WriteLine("Ukol se zadaným ID nebyl nalezen");
                            }
                        }

                        break;

                    // Random fakta
                    case 4:
                        Random random = new Random();
                        Console.WriteLine("");
                        Console.WriteLine(randomFakta[random.Next(0, randomFakta.Length)]);

                        break;

                    // Ukoncit program
                    case 5:
                        Console.WriteLine("Dekujeme za pouziti programu todolist");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class UtilityMethods
    {
        public string generateID()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }
    }
}


