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

        public static void PersonCollision(List<Person> allPersons, List<Person> inmates)
        {
            for (int p1 = 0; p1 < allPersons.Count; p1++)
            {
                for (int p2 = p1 + 1; p2 < allPersons.Count; p2++)
                {
                    if (allPersons[p1].CurrentPositionX == allPersons[p2].CurrentPositionX && allPersons[p1].CurrentPositionY == allPersons[p2].CurrentPositionY)
                    {

                        if (allPersons[p1] is Thief && allPersons[p2] is Citizen || allPersons[p1] is Citizen && allPersons[p2] is Thief)
                        {
                            if (allPersons[p2] is Citizen)
                            {
                                // Lägg till en random här för att slumpa föremål i lista/inventory
                                allPersons[p1].Inventory.Add(allPersons[p2].Inventory[0]);
                                allPersons[p2].Inventory.RemoveAt(0);
                                
                                //FUnktion för att hamna i  finkan om invetory <= 0

                            }
                            if (allPersons[p1] is Citizen)
                            {
                                // Lägg till en random här för att slumpa föremål i lista/inventory
                                allPersons[p2].Inventory.Add(allPersons[p1].Inventory[0]);
                                allPersons[p1].Inventory.RemoveAt(0);
                                //FUnktion för att hamna i  finkan om invetory <= 0

                            }

                        }

                        if (allPersons[p1] is Police && allPersons[p2] is Thief || allPersons[p1] is Thief && allPersons[p2] is Police)
                        {
                            if (allPersons[p2] is Thief)
                            {
                                // Lägg till en random här för att slumpa föremål i lista/inventory
                                allPersons[p1].Inventory.AddRange(allPersons[p2].Inventory);
                                allPersons[p2].Inventory.Clear();
                                inmates.Add(allPersons[p2]);
                                allPersons.RemoveAt(p2);
                                GeneratePosition(allPersons[p2], 10, 10);

                                //FUnktion för att hamna i finkan

                            }
                            if (allPersons[p1] is Thief)
                            {
                                // Lägg till en random här för att slumpa föremål i lista/inventory
                                allPersons[p2].Inventory.AddRange(allPersons[p1].Inventory);
                                allPersons[p1].Inventory.Clear();
                                inmates.Add(allPersons[p1]);
                                allPersons.RemoveAt(p1);
                                GeneratePosition(allPersons[p1], 10, 10);

                                //FUnktion för att hamna i finkan

                            }
                        }

                        if (allPersons[p1] is Police && allPersons[p2] is Citizen || allPersons[p1] is Citizen && allPersons[p2] is Police)
                        {

                        }

                    }

                }
            }

        }

        public static void GeneratePosition(Person person, int width, int height)
        {
            int rndStartX = Random.Shared.Next(2, width);
            int rndStartY = Random.Shared.Next(2, height);
            person.CurrentPositionX = rndStartX;
            person.CurrentPositionY = rndStartY;
        }
    }

     

        class Thief : Person
        {
            public Thief(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
            {
                Inventory = inventory;
            }
        }

        class Citizen : Person
        {
            public Citizen(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
            {
                Inventory = inventory;
            }
        }

        class Police : Person
        {
            public Police(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
            {
                Inventory = inventory;
            }
        }
    }
