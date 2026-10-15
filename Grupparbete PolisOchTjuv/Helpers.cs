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



        public static List<Person> CreatePeople()
        {
            List<Person> personList = new List<Person>();

            for (int i = 1; i < 10; i++)
            {
                Person person1 = new(GetName(), ) /*Person((GetName()), (int i = (Random.Next.Shared(1, 99)), (Random.Next.Shared(1, 99)), )*/
                
            }
            return personList;

            Comedy movie1 = new("Dum dummare", 139, 20, actors);
            movie1.Actors.Add("Kalle Banan(född 2001)");

            Action movie2 = new("Knogmackan", 192, 79, actors);
            movie2.Actors.Add("Tom Kross(född 1998)");

            SciFi movie3 = new("Sun Wars", 29, 119, actors);
            movie3.Actors.Add("Yoda(född 1491)");

            List<Movie> movies = new List<Movie>();             //Lista med objekt av classen Movie
            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);
        }


    }
}
