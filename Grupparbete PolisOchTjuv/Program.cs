using System.Collections;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Grupparbete_PolisOchTjuv
{
    internal class Program
    {
       internal static void Main(string[] args)
       {
            
            List<Person> inmates = new List<Person>();
            List<Person> poorPeople = new List<Person>();

            Queue<string> newsFeed = new Queue<string>();

            City myCity = new City(100, 25);
            Prison myPrison = new Prison(10, 10);
            PoorHouse myPoorHouse = new PoorHouse(50, 10);

            List<Citizen> citizenList = new List<Citizen>();
            citizenList = Helpers.CreateCitizen();

            List<Police> policeList = new List<Police>();
            policeList = Helpers.CreatePolice();

            List<Thief> thiefList = new List<Thief>();
            thiefList = Helpers.CreateThief();

            List<Person> cityList = new List<Person>();
            List<Person> allPersonList = new List<Person>();

            cityList.AddRange(thiefList);
            cityList.AddRange(policeList);
            cityList.AddRange(citizenList);
            allPersonList.AddRange(cityList);
            Console.ReadKey(true);

            int newsNumber = 1;
            bool textMode = false;

            while (true)
            {
                                                                                                                                                        // Om tangentinmatning sparar en char input. Om input = V ändrar man bool.
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    char input = (char)key.KeyChar;

                    if (input == 'v')
                    {
                        textMode = !textMode;
                        Console.Clear();
                    }
                                                                                                                                                        // Newsnumber returnernas från metoden
                    newsNumber = Person.AddPerson(cityList, allPersonList, input, newsFeed, newsNumber);
                }

                Thread.Sleep(100);
                Person.PersonMove(cityList, myCity);
                Person.PersonMove(inmates, myPrison);
                Person.PersonMove(poorPeople, myPoorHouse);
                newsNumber = Person.PersonCollision(cityList, inmates, poorPeople, newsFeed, newsNumber);
                newsNumber = Person.RemoveFromPrison(inmates, cityList, newsFeed, newsNumber);
                newsNumber = Person.RemoveFromPoorHouse(poorPeople, cityList, newsFeed, newsNumber);

                if (!textMode)
                {
                    Helpers.PrintCityOverview(myCity, cityList, myPoorHouse, poorPeople, myPrison, inmates, allPersonList, newsFeed);
                }
                else
                {
                    Helpers.PrintTextOverview(cityList, poorPeople, myPrison, inmates, allPersonList, newsFeed);
                }

                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
