using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class Person
    {
        public string Name { get; set; }
        public char Icon { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public int MovePositionX { get; set; }
        public int MovePositionY { get; set; }

        public Person(string name, char icon, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY)
        {
            Name = name;
            Icon = icon;
            CurrentPositionX = currentPositionX;
            CurrentPositionY = currentPositionY;
            MovePositionX = movePositionX;
            MovePositionX = movePositionY;
        }
    }

    class Thief : Person
    {
        public List<string> Inventory { get; set; }

        public Thief(string name, char icon, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name,icon, currentPositionX, currentPositionY, movePositionX, movePositionY)
        {
            Inventory = inventory;
        }

    }

    class Citizen : Person
    {
        public List<string> Inventory { get; set; }

        public Citizen(string name, char icon, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name,icon, currentPositionX, currentPositionY, movePositionX, movePositionY)
        {
            Inventory = inventory;
        }
    }

    class Police : Person
    {
        public List<string> Inventory { get; set; }
        
        public Police(string name, char icon, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name,icon, currentPositionX, currentPositionY, movePositionX, movePositionY)
        {
            Inventory = inventory;
        }
    }
}
