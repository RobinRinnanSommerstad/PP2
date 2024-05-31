using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Start
    {
        private List<Option> optionList = new List<Option>();

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til din gjøreliste");
                Console.WriteLine("1. Se oppgaver");
                Console.WriteLine("2. Legg til oppgaver");
                Console.WriteLine("3. Fjern oppgaver");
                Console.WriteLine("4. Avslutt");
                Console.Write("Velg et alternativ: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewOptions();
                        break;
                    case "2":
                        AddOption();
                        break;
                    case "3":
                        RemoveOption();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig valg. Trykk en knapp for å prøve igjen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ViewOptions()
        {
            Console.Clear();
            if (optionList.Count == 0)
            {
                Console.WriteLine("Ingen oppgaver funnet.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Dine oppgaver:");
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {optionList[i].Name}");
            }

            Console.Write("Skriv ID for oppgaven som skal vises (eller trykk Enter for å gå tilbake): ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int number) && number > 0 && number <= optionList.Count)
            {
                DisplayOption(optionList[number - 1]);
            }
        }

        private void DisplayOption(Option option)
        {
            Console.Clear();
            Console.WriteLine($"Navn: {option.Name}");
            Console.WriteLine($"Beskrivelse: {option.Description}");
            Console.WriteLine("Trykk en knapp for å gå tilbake.");
            Console.ReadKey();
        }

        private void AddOption()
        {
            Console.Clear();
            Console.Write("Hva er din nye oppgave? ");
            string optName = Console.ReadLine();
            Console.Write("Legg til en beskrivelse av oppgaven: ");
            string optDesc = Console.ReadLine();
            optionList.Add(new Option(optName, optDesc));
            Console.Clear();
            Console.WriteLine("Oppgave lagt til. Trykk en knapp for å gå videre.");
            Console.ReadKey();
        }

        private void RemoveOption()
        {
            Console.Clear();
            if (optionList.Count == 0)
            {
                Console.WriteLine("Ingen oppgaver å fjerne.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Velg en oppgave å fjerne:");
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {optionList[i].Name}");
            }

            Console.Write("Velg en oppgave: ");
            string userReply = Console.ReadLine();
            if (int.TryParse(userReply, out int number) && number > 0 && number <= optionList.Count)
            {
                optionList.RemoveAt(number - 1);
                Console.WriteLine("Oppgave fjernet. Trykk en knapp for å gå videre.");
            }
            else
            {
                Console.WriteLine("Ugyldig input. Trykk en knapp for å fortsette.");
            }
            Console.ReadKey();
        }
    }
}
