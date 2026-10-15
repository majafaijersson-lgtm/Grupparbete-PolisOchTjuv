using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class City
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public char[,] Map { get; set; }

        public City()
        {
            Width = 100;
            Height = 25;
            Map = new char[Height, Width];
        }

        public static void PrintCity(City myCity)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            for (int row = 0; row < myCity.Height; row++)
            {
                for (int col = 0; col < myCity.Width; col++)
                {
                    if (col == 0 || col == myCity.Map.GetLength(1) - 1)
                    {
                        Console.Write('X');
                    }
                    myCity.Map[row, col] = ' ';
                    Console.Write(myCity.Map[row, col]);

                }
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
    }
}
