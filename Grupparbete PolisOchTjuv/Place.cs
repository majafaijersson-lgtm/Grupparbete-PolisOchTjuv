using System;
using System.Collections.Generic;
using System.Numerics;
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





