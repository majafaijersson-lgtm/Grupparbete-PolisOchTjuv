using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class Person
    {
        public string Name { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public int MovePositionX { get; set; }
        public int MovePositionY { get; set; }

        public Person(string name, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY)
        {
            Name = name;
            CurrentPositionX = currentPositionX;
            CurrentPositionY = currentPositionY;
            MovePositionX = movePositionX;
            MovePositionX = movePositionY;
        }
    }

    class Thief : Person
    {
        public List<string> Inventory { get; set; }

        public Thief(string name, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, currentPositionX, currentPositionY, movePositionX, movePositionY)
        {
            Inventory = inventory;
        }

    }

    class Citizen : Person
    {
        public List<string> Inventory { get; set; }

        public Citizen(string name, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, currentPositionX, currentPositionY, movePositionX, movePositionY)
        {
            Inventory = inventory;
        }
    }

    class Police : Person
    {
        public List<string> Inventory { get; set; }

        public Police(string name, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, currentPositionX, currentPositionY, movePositionX, movePositionY)
        {
            Inventory = inventory;
        }
    }
}
