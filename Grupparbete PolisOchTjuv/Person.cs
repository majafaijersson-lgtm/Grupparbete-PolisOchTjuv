using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class Person
    {
        public string Name { get; set; }
        public char Icon { get; set; }
        public ConsoleColor IconColor { get; set; }
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public int MovePositionX { get; set; }
        public int MovePositionY { get; set; }
        public List<string> Inventory { get; set; }

        public Person(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory)
        {
            Name = name;
            Icon = icon;
            IconColor = iconColor;
            CurrentPositionX = currentPositionX;
            CurrentPositionY = currentPositionY;
            MovePositionX = movePositionX;
            MovePositionY = movePositionY;
            Inventory = inventory;
        }

        public static void PersonMove(List<Person> allPersons) //List inparameter rndMovementX och Y för att göra riktningsädnringar
        {
            foreach (Person person in allPersons)
            {

                person.CurrentPositionX += person.MovePositionX;
                person.CurrentPositionY += person.MovePositionY;

                if (person.CurrentPositionX <= 0)
                {
                    person.CurrentPositionX = 100;
                }
                else if (person.CurrentPositionX >= 100)
                {
                    person.CurrentPositionX = 0;
                }
                else if (person.CurrentPositionY <= 0)
                {
                    person.CurrentPositionY = 25;
                }
                else if (person.CurrentPositionY >= 25)
                {
                    person.CurrentPositionY = 0;
                }
            }
        }

        public static void PersonCollision(List<Person> allPersons)
        {
            for (int i = 0; i < allPersons.Count; i++)
            {
                for (int j = i + 1; j < allPersons.Count; j++)
                {
                    if (allPersons[i].CurrentPositionX == allPersons[j].CurrentPositionX && allPersons[i].CurrentPositionY == allPersons[j].CurrentPositionY)
                    {

                        if (allPersons[i] is Thief && allPersons[j] is Citizen || allPersons[i] is Citizen && allPersons[j] is Thief)
                        {
                            if (allPersons[j] is Citizen)
                            {
                                // Lägg till en random här för att slumpa föremål i lista/inventory
                                allPersons[i].Inventory.Add(allPersons[j].Inventory[0]);
                                allPersons[j].Inventory.RemoveAt(0);
                                
                            }
                            if (allPersons[i] is Citizen)
                            {
                                // Lägg till en random här för att slumpa föremål i lista/inventory
                                allPersons[j].Inventory.Add(allPersons[i].Inventory[0]);
                                allPersons[i].Inventory.RemoveAt(0);

                            }


                        }

                        if (allPersons[i] is Police && allPersons[j] is Thief || allPersons[i] is Thief && allPersons[j] is Police)
                        {

                        }

                        if (allPersons[i] is Police && allPersons[j] is Citizen || allPersons[i] is Citizen && allPersons[j] is Police)
                        {

                        }

                    }


                }
            }

        }

    }

        class Thief : Person
        {
            public List<string> Inventory { get; set; }

            public Thief(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
            {
                Inventory = inventory;
            }
        }

        class Citizen : Person
        {
            public List<string> Inventory { get; set; }

            public Citizen(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
            {
                Inventory = inventory;
            }
        }

        class Police : Person
        {
            public List<string> Inventory { get; set; }

            public Police(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
            {
                Inventory = inventory;
            }
        }
    }
