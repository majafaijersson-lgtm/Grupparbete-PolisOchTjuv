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

            List<Person> personList = new List<Person>();

            personList = Helpers.CreatePolice();

            foreach (Police police in personList)
            {
                Console.WriteLine($"{police.Name}, {police.Inventory}");
            }

            foreach (Citizen citizen in personList)
            {
                Console.WriteLine($"{Citizen.Name}, {Citizen.Inventory}");
            }

            //ANropa metod i Helpers




        }
    }
}
