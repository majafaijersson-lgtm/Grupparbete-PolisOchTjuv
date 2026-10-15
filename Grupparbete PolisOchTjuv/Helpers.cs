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

            for (int i = 1; i < 10; i++)
            {
                int rndStartX = Random.Shared.Next(1, 100);
                int rndStartY = Random.Shared.Next(1, 25);
                int rndMovementX = Random.Shared.Next(-1, 2);
                int rndMovementY = Random.Shared.Next(-1, 2);
                personList.Add(new Police(GetName(), rndStartX, rndStartY, rndMovementX, rndMovementY, seizedInventory));
                //Person person1 = new(GetName(), ) /*Person((GetName()), (int i = (Random.Next.Shared(1, 99)), (Random.Next.Shared(1, 99)), )*/
                
            }

            return personList;


        }

        //public static List<Person> CreateThief()
        //{

        //}


    }
}
