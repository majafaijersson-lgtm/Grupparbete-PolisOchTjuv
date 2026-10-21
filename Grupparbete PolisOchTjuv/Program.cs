using System.Collections;
using System.Data;

namespace Grupparbete_PolisOchTjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Person> inmates = new List<Person>();
            List<Person> poorHouse = new List<Person>();


            City myCity = new City(100, 25);
            Prison myPrison = new Prison(10, 10);
            PoorHouse myPoorHouse = new PoorHouse(50, 10);

            Queue newsFeed = new Queue();

            

            List<Citizen> citizenList = new List<Citizen>();
            citizenList = Helpers.CreateCitizen();

            List<Police> policeList = new List<Police>();
            policeList = Helpers.CreatePolice();

            List<Thief> thiefList = new List<Thief>();
            thiefList = Helpers.CreateThief();

            List<Person> allPersons = new List<Person>();

            allPersons.AddRange(thiefList);
            allPersons.AddRange(policeList);
            allPersons.AddRange(citizenList);
            Console.ReadKey(true);
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                //Console.CursorVisible = false; tar bort flimmret?
                //Thread.Sleep(800);
                Person.PersonMove(allPersons, myCity);
                Person.PersonMove(inmates, myPrison);
                Person.PersonMove(poorHouse, myPoorHouse);
                Person.PersonCollision(allPersons, inmates, poorHouse, newsFeed);
                Console.WriteLine("CITY");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Place.PrintMap(myCity, allPersons);
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("POORHOUSE");
                Console.WriteLine("--------------------------------------------------");
                PoorHouse.PrintMap(myPoorHouse, poorHouse);
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("PRISON");
                Console.WriteLine("----------");
                Prison.PrintMap(myPrison, inmates);
                Console.WriteLine("----------");
                Console.WriteLine();
                Helpers.PrintLatestActions(newsFeed);
            }

            //Console.WriteLine(Helpers.GetName()); //skriver ut ett randomiserat namn

            //foreach (Person person in allPersons)
            //{
            //    if(person is Police)
            //    {
            //        Console.WriteLine(person.GetType().Name);
            //    }

            //}

            //ANropa metod i Helpers
        }
    }
}
