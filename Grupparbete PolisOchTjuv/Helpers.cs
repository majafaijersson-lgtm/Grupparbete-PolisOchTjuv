using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Grupparbete_PolisOchTjuv
{
    internal class Helpers
    {
        public static string GetName()
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

        public static List<Police> CreatePolice()
        {
            List<Police> personList = new List<Police>();
            List<string> seizedInventory = new List<string>();

            for (int i = 1; i < 6; i++)
            {
                int rndStartX = Random.Shared.Next(2, 99);
                int rndStartY = Random.Shared.Next(2, 24);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                char icon = 'P';
                ConsoleColor iconColor = ConsoleColor.Blue;
                personList.Add(new Police(GetName(), icon, iconColor, rndStartX, rndStartY, rndMovementX, rndMovementY, seizedInventory));
                //Person person1 = new(GetName(), ) /*Person((GetName()), (int i = (Random.Next.Shared(1, 99)), (Random.Next.Shared(1, 99)), )*/    
            }

            return personList;
        }

        public static List<Thief> CreateThief()
        {
            List<Thief> personList = new List<Thief>();
            List<string> stolenInventory = new List<string>();

            for (int i = 1; i < 11; i++)
            {
                int rndStartX = Random.Shared.Next(2, 99);
                int rndStartY = Random.Shared.Next(2, 24);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                char icon = 'T';
                ConsoleColor iconColor = ConsoleColor.Red;
                personList.Add(new Thief(GetName(),icon,iconColor, rndStartX, rndStartY, rndMovementX, rndMovementY, stolenInventory));
            }
            return personList;
        }

        public static List<Citizen> CreateCitizen()
        {
            List<Citizen> personList = new List<Citizen>();
            List<string> inventory = new List<string>();
            for (int i = 1; i < 16; i++)
            {
                int rndStartX = Random.Shared.Next(2, 99);
                int rndStartY = Random.Shared.Next(2, 24);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                char icon = 'C';
                ConsoleColor iconColor = ConsoleColor.Green;
                personList.Add(new Citizen(GetName(),icon,iconColor, rndStartX, rndStartY, rndMovementX, rndMovementY, inventory));
                
            }
            inventory.AddRange("nycklar", "mobiltelefon", "pengar", "klocka");

            return personList;


        }


    }
}
