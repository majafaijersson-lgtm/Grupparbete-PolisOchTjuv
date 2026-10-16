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

        public static void PrintCity(City myCity, List<Person> allPersons)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------");

            for (int row = 0; row < myCity.Height; row++)
            {
                for (int col = 0; col < myCity.Width; col++)
                {
                    if (col == 0 || col == myCity.Width - 1)
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
                                //person.Map[CurrentPsoitionX, CurrentPositionY] = person.Icon;
                                Console.Write(person.Icon);
                                found = true;
                                break;
                            }
                        }

                        if(!found)
                        {
                            
                            Console.Write(' ');
                        }
                    }
          

                }
                Console.WriteLine();
            }

         



                Console.WriteLine("----------------------------------------------------------------------------------------------------");

            //Grund till Newsfeed/Status
            foreach (Person person in allPersons)
            {
                Console.WriteLine(person.Icon + ", " + person.CurrentPositionY + " ," + person.CurrentPositionX);
            }
        }
    }
}
