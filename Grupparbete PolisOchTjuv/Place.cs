using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class Place
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Map { get; set; }

        public Place(int width, int heigth)
        {
            Width = width;
            Height = heigth;
            Map = new char[Height, Width];
        }

        public static void PrintMap(Place myPlace, List<Person> allPersons)

        {

            for (int row = 0; row < myPlace.Height; row++)
            {
                for (int col = 0; col < myPlace.Width; col++)
                {
                    if (col == 0 || col == myPlace.Width - 1)
                    {
                        Console.Write('X');
                    }

                    else
                    {
                        bool found = false;

                        foreach (Person person in allPersons)
                        {
                            if (person.CurrentPositionX == col && person.CurrentPositionY == row)
                            {
                                Console.ForegroundColor = person.IconColor;
                                //person.Map[CurrentPsoitionX, CurrentPositionY] = person.Icon;
                                Console.Write(person.Icon);
                                found = true;
                                Console.ResetColor();
                                break;
                            }
                        }

                        if (!found)
                        {

                            Console.Write(' ');
                        }
                    }
                }

                Console.WriteLine();

            }

  
            ////Grund till Newsfeed/Status
            //foreach (Person person in allPersons)
            //{
            //    Console.WriteLine(person.Icon + ", " + person.CurrentPositionY + " ," + person.CurrentPositionX + "      ");
            //}
        }

        public static void PrintStatus(List<Person> allPersons, int nrOfCitizen, int nrOfPolice, int nrOfThieves)
        {

            int citizen = 0;
            int police = 0;
            int thief = 0;

            foreach (Person person in allPersons)
            {
                if(person is Citizen)
                {
                    citizen++;
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

            Console.WriteLine($"Of {nrOfCitizen} citizens, {citizen} remain in the city.");
            Console.WriteLine($"Of {nrOfThieves} thieves, {thief} remain in the city.");
            Console.WriteLine($"There are {nrOfPolice} police in the city.");

        }

        public static void PrintNewsFeed(List<string> newsFeed)
        {
            // Poliser, C och T som tillkommer.
            // T som hamnar i finkan
            // T som kommer ut från finkan
            // C som hamnar i PH
            // C som kommer ut från PH?
            // T rånar C på item
            // De som hejar på varandra.

        }
    }

    class City : Place
    {
        public City(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            Map = new char[Height, Width];
        }

    }

    class Prison : Place
    {
        public Prison(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            Map = new char[Height, Width];
        }

    }

    class PoorHouse : Place
    {
        public PoorHouse(int width, int height) : base(width, height)
        {
            Width = width;
            Height = height;
            Map = new char[Height, Width];
        }

    }
}





