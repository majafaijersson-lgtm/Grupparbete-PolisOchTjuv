using System.Data;

namespace Grupparbete_PolisOchTjuv
{
    internal class Program
    {
        static void Main(string[] args)
        {

            City myCity = new City();

            City.PrintCity(myCity);

            //Console.WriteLine(Helpers.GetName()); //skriver ut ett randomiserat namn

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

            foreach (Person person in allPersons)
            {
                if(person is Police)
                {
                    Console.WriteLine(person.GetType().Name);
                }

            }

            

            //ANropa metod i Helpers




        }
    }
}
