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

        }

        public static void PrintStatus(List<Person> allPersons, List<Citizen> citizenList, List<Police> policeList, List<Thief> thiefList)
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

            Console.WriteLine($"Of {citizen} citizens, {citizen} remain in the city.");
            Console.WriteLine($"Of {thief} thieves, {thief} remain in the city.");
            Console.WriteLine($"There are {police} police in the city.");

        }

        public static void AddNewsFeed(Queue<string> newsFeed, string news)
        {
            newsFeed.Enqueue(news); //lägger till string sist i "kön". string news från main(ej tillagt ännu)

            if (newsFeed.Count > 5) //Om Newsfeed är > 5 så tas det äldsta elementet bort?
            {
                newsFeed.Dequeue();
            }

            // Poliser, C och T som tillkommer.
            // T som kommer ut från finkan
            // C som kommer ut från PH?
        }

        public static void PrintNewsFeed(Queue<string> newsFeed)
        {

            Console.WriteLine("NEWS FEED");

            foreach (string text in newsFeed.Reverse()) //Kan man reversera utskriften? Omvänd for-loop? reverse-metod?
            {
                Console.WriteLine(text); //Ändra newsnumber. Ta bort?
            }
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





