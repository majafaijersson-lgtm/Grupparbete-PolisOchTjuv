using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Grupparbete_PolisOchTjuv
{
    internal class Helpers
    {
        private static string GetName()
        {
            string[] Names =
            {
                "Andersson",
                "Johansson",
                "Karlsson",
                "Nilsson",
                "Eriksson",
                "Larsson",
                "Olsson",
                "Persson",
                "Svensson",
                "Gustafsson",
                "Pettersson",
                "Jonsson",
                "Jansson",
                "Hansson",
                "Bengtsson",
                "Jönsson",
                "Lindberg",
                "Jakobsson",
                "Magnusson",
                "Olofsson",
                "Lindström",
                "Lindqvist",
                "Lindgren",
                "Bergström",
                "Axelsson",
                "Berg",
                "Lundberg",
                "Lundgren",
                "Fredriksson",
                "Mattsson",
                "Holm",
                "Sandberg",
                "Eklund",
                "Dahlberg",
                "Sjöberg",
                "Engström",
                "Forsberg",
                "Håkansson",
                "Björk",
                "Nyström",
                "Westberg",
                "Blomqvist",
                "Strömberg",
                "Ekström",
                "Norberg",
                "Wikström",
                "Hedlund",
                "Sundberg",
                "Wallin",
                "Lindahl"
            };

            int rnd = Random.Shared.Next(0, Names.Length);
            return Names[rnd];
        }

        internal static void PrintCityOverview(City myCity, List<Person> cityList, PoorHouse myPoorHouse, List<Person> poorPeople, Prison myPrison, List<Person> inmates, List<Person> allPersonList, Queue<string> newsFeed)

        {
            Console.WriteLine("CITY");
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Place.PrintMap(myCity, cityList);
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
            Place.PrintStatus(cityList, allPersonList, inmates, poorPeople);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Place.PrintNewsFeed(newsFeed);
            Thread.Sleep(200);
        }

        internal static List<Police> CreatePolice()
        {
            List<Police> personList = new List<Police>();

            for (int i = 1; i < 12; i++)
            {
                int rndStartX = Random.Shared.Next(2, 99);
                int rndStartY = Random.Shared.Next(2, 24);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                List<string> seizedInventory = new List<string>();
                char icon = 'P';
                ConsoleColor iconColor = ConsoleColor.Blue;
                personList.Add(new Police(GetName(), icon, iconColor, rndStartX, rndStartY, rndMovementX, rndMovementY, seizedInventory));
            }

            return personList;
        }

        internal static List<Thief> CreateThief()
        {
            List<Thief> personList = new List<Thief>();
            

            for (int i = 1; i < 38; i++)
            {
                int rndStartX = Random.Shared.Next(2, 99);
                int rndStartY = Random.Shared.Next(2, 24);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                List<string> stolenInventory = new List<string>();
                char icon = 'T';
                ConsoleColor iconColor = ConsoleColor.Red;
                personList.Add(new Thief(GetName(),icon,iconColor, rndStartX, rndStartY, rndMovementX, rndMovementY, stolenInventory));
            }
            return personList;
        }

        internal static List<Citizen> CreateCitizen()
        {
            List<Citizen> personList = new List<Citizen>();
            
            for (int i = 1; i < 28; i++)
            {
                int rndStartX = Random.Shared.Next(2, 99);
                int rndStartY = Random.Shared.Next(2, 24);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                List<string> inventory = new List<string>();
                inventory.AddRange("keys", "mobile phone", "money", "clock");
                char icon = 'C';
                ConsoleColor iconColor = ConsoleColor.Green;
                personList.Add(new Citizen(GetName(),icon,iconColor, rndStartX, rndStartY, rndMovementX, rndMovementY, inventory));
                
            }
            return personList;


        }

    }
}
