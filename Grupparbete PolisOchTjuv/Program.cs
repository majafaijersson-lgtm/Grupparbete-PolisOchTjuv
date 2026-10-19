using System.Data;

namespace Grupparbete_PolisOchTjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {

            City myCity = new City();

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

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                //Console.CursorVisible = false; tar bort flimmret?
                Thread.Sleep(250);
                Person.PersonMove(allPersons);
                City.PrintCity(myCity, allPersons);

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
