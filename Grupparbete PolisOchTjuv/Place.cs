using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class Place
    {
        internal int Width { get; set; }
        internal int Height { get; set; }
        internal char[,] Map { get; set; }

        internal Place(int width, int heigth)
        {
            Width = width;
            Height = heigth;
            Map = new char[Height, Width];
        }

        internal static void PrintMap(Place myPlace, List<Person> cityList)
        {

            for (int row = 0; row < myPlace.Height; row++)                                                                                                      //Går igenom rad och skriver ut varje kolumn i den raden innan raden byts.
            {
                for (int col = 0; col < myPlace.Width; col++)
                {
                    if (col == 0 || col == myPlace.Width - 1)                                                                                                   //Om kant vänster eller höger -> X
                    {
                        Console.Write('X');
                    }

                    else                                                                                                                                        //annars, skriv ut person på deras platser
                    {
                        bool found = false;

                        foreach (Person person in cityList)
                        {
                            if (person.CurrentPositionX == col && person.CurrentPositionY == row)                                                               //Om det finns en person på den x och y koordinaten.
                            {
                                Console.ForegroundColor = person.IconColor;
                                Console.Write(person.Icon);
                                found = true;
                                Console.ResetColor();
                                break;
                            }
                        }

                        if (!found)                                                                                                                             //Om ingen kant, eller ingen person hittas så skrivs " ".
                        {

                            Console.Write(' ');
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        internal static void PrintStatus(List<Person> allPersons, List<Person> fullPeopleList, List<Person> inmates, List<Person> poorPeople)
        {
            int citizen = 0;
            int police = 0;
            int thief = 0;

            foreach (Person person in fullPeopleList)                                                                                                           //Går igenom alla personer i alla places.
            {
                if(person is Citizen)
                {
                    citizen++;                                                                                                                                  //Lägger till antal C, T och P i variablerna ovan.
                }
                if(person is Police)
                {
                    police++;
                }
                if(person is Thief)
                {
                    thief++;
                }  
            }

            Console.WriteLine($"Of {citizen} citizens, {citizen - poorPeople.Count} remain in the city.                                                       "); //Mellanslag = utskriftfix
            Console.WriteLine($"Of {thief} thieves, {thief - inmates.Count} remain in the city.                                                               "); //{alla thieves i alla places}, {alla thieves i alla places - fångar}
            Console.WriteLine($"There are {police} police in the city.                                                                                        ");
        }

        internal static void AddNewsFeed(Queue<string> newsFeed, string news)
        {
            newsFeed.Enqueue(news);                                                                                                                             //lägger till string sist i "kön". string news från main(ej tillagt ännu)

            if (newsFeed.Count > 5)                                                                                                                             //Om Newsfeed är > 5 så tas det äldsta elementet bort
            {
                newsFeed.Dequeue();                                                                                                                             
            }

           
        }

        internal static void PrintNewsFeed(Queue<string> newsFeed)
        {

            Console.WriteLine("NEWS FEED");

            foreach (string text in newsFeed.Reverse())                                                                                                     //Går igenom alla nyheter i newsFeed + reverserar ordningen för utskrift(Senaste händelse, skirvs längst upp)
            {
                Console.WriteLine($"{text}                                               "); 
            }
        }
    }

   internal class City : Place
    {
        public City(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            Map = new char[Height, Width];
        }

    }

    internal class Prison : Place
    {
        public Prison(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            Map = new char[Height, Width];
        }

    }

   internal class PoorHouse : Place
    {
        public PoorHouse(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            Map = new char[Height, Width];
        }

    }
}





