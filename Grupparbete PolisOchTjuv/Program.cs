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

            List<Person> allPersons = new List<Person>();
            List<Person> fullPeopleList = new List<Person>();

            allPersons.AddRange(thiefList);
            allPersons.AddRange(policeList);
            allPersons.AddRange(citizenList);
            fullPeopleList.AddRange(allPersons);
            Console.ReadKey(true);

            int newsNumber = 1;
            bool textMode = false;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    char input = (char)key.KeyChar;

                    if (input == 'v')
                    {
                        textMode = !textMode;
                        Console.Clear();
                    }

                    newsNumber = Person.AddPerson(allPersons, fullPeopleList, input, newsFeed, newsNumber);

                }
                Thread.Sleep(100);
                Person.PersonMove(allPersons, myCity);
                Person.PersonMove(inmates, myPrison);
                Person.PersonMove(poorPeople, myPoorHouse);
                newsNumber = Person.PersonCollision(allPersons, inmates, poorPeople, newsFeed, newsNumber);
                newsNumber = Person.RemoveFromPrison(inmates, allPersons, newsFeed, newsNumber);
                newsNumber = Person.RemoveFromPoorHouse(poorPeople, allPersons, newsFeed, newsNumber);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    char input = (char)key.KeyChar;
                }

                if (!textMode)
                {

                    Console.WriteLine("CITY");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Place.PrintMap(myCity, allPersons);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("POORHOUSE");
                    Console.WriteLine("--------------------------------------------------");
                    PoorHouse.PrintMap(myPoorHouse, poorPeople);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("PRISON");
                    Console.WriteLine("----------");
                    Prison.PrintMap(myPrison, inmates);
                    Console.WriteLine("----------");
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("STATUS:");
                    Place.PrintStatus(allPersons, fullPeopleList, inmates, poorPeople);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Place.PrintNewsFeed(newsFeed);
                    Thread.Sleep(200);

                }
                else
                {
                    Person.PrintPersonInfo(fullPeopleList);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Console.WriteLine("STATUS:");
                    Place.PrintStatus(allPersons, fullPeopleList, inmates, poorPeople);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    Place.PrintNewsFeed(newsFeed);
                    Thread.Sleep(200);
                }
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
