using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
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

        public static void PrintPersonInfo(List<Person> fullPeopleList)
        {
            for (int i = 0; i < fullPeopleList.Count; i++)
            {
                Console.Write($"Person {i}: {fullPeopleList[i].GetType().Name}: ");
                foreach(String item in fullPeopleList[i].Inventory)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine($"- {fullPeopleList[i].CurrentPositionX}, {fullPeopleList[i].CurrentPositionY}.                       ");
                
            }
        }

        public static void PersonMove(List<Person> allPersons, Place map) //List inparameter rndMovementX och Y för att göra riktningsädnringar
        {
            foreach (Person person in allPersons)
            {

                person.CurrentPositionX += person.MovePositionX;
                person.CurrentPositionY += person.MovePositionY;

                if (person.CurrentPositionX <= 0)
                {
                    person.CurrentPositionX = map.Width;
                }
                else if (person.CurrentPositionX >= map.Width)
                {
                    person.CurrentPositionX = 0;
                }
                else if (person.CurrentPositionY <= 0)
                {
                    person.CurrentPositionY = map.Height;
                }
                else if (person.CurrentPositionY >= map.Height)
                {
                    person.CurrentPositionY = 0;
                }
            }
        }

        public static int SayHello(Person p1, Person p2, Queue<string> newsFeed, int newsNumber)
        {
            if (p1 is Citizen && p2 is Citizen) //C säger hej till C
            {
                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. {p1.GetType().Name} says hello to {p2.GetType().Name} !"));
                newsNumber++;
            }

            else if ((p1 is Citizen && p2 is Police) || //C säger Hej till P
                     (p1 is Police && p2 is Citizen))
            {
                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. {p1.GetType().Name} sayas hello to {p2.GetType().Name}!"));
                newsNumber++;
            }

            else if (p1 is Police && p2 is Thief && p2.Inventory.Count == 0) //P till T(inv = 0)
            {
                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Police says hello to Thief!"));
                newsNumber++;
            }
            else if (p1 is Thief && p2 is Police && p1.Inventory.Count == 0)//T(inv 0) till P 
            {
                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief says hello to Police!"));
                newsNumber++;

            }
            return newsNumber;
        }


        public static int PersonCollision(List<Person> allPersons, List<Person> inmates, List<Person> poorHouse, Queue<string> newsFeed, int newsNumber)
        {
            List<Person> removeList = new List<Person>();
            for (int p1 = 0; p1 < allPersons.Count -1; p1++)
            {
                for (int p2 = p1 + 1; p2 < allPersons.Count; p2++) // -1?
                {
                    if (allPersons[p1].CurrentPositionX == allPersons[p2].CurrentPositionX && allPersons[p1].CurrentPositionY == allPersons[p2].CurrentPositionY)
                    {
                        if (allPersons[p1] is Thief && allPersons[p2] is Citizen || allPersons[p1] is Citizen && allPersons[p2] is Thief)
                        {
                            if (allPersons[p2] is Citizen)
                            {
                                if (allPersons[p2].Inventory.Count > 0)
                                    {
                                    // Lägg till en random här för att slumpa föremål i lista/inventory
                                    Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief {allPersons[p1].Name} stole {allPersons[p2].Inventory[0]} from citizen {allPersons[p2].Name}."));
                                    allPersons[p1].Inventory.Add(allPersons[p2].Inventory[0]);
                                    allPersons[p2].Inventory.RemoveAt(0);
                                    newsNumber++;
                                }

                                if (allPersons[p2].Inventory.Count == 0)
                                {
                                    GeneratePosition(allPersons[p2], 50, 10);
                                    Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Citizen {allPersons[p2].Name} was sent to poorhouse"));
                                    poorHouse.Add(allPersons[p2]);
                                    //allPersons.RemoveAt(p2);
                                    removeList.Add(allPersons[p2]);
                                    newsNumber++;

                                }
                            }
                            if (allPersons[p1] is Citizen)
                            {
                                if (allPersons[p1].Inventory.Count > 0)
                                {
                                    // Lägg till en random här för att slumpa föremål i lista/inventory
                                    Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief {allPersons[p2].Name} stole {allPersons[p1].Inventory[0]} from citizen {allPersons[p1].Name}."));
                                    allPersons[p2].Inventory.Add(allPersons[p1].Inventory[0]);
                                    allPersons[p1].Inventory.RemoveAt(0);
                                    newsNumber++;

                                }

                                if (allPersons[p1].Inventory.Count == 0)
                                {
                                    GeneratePosition(allPersons[p1], 50, 10);
                                    Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Citizen {allPersons[p2].Name} was sent to poorhouse"));
                                    poorHouse.Add(allPersons[p1]);
                                    //allPersons.RemoveAt(p1);
                                    removeList.Add(allPersons[p1]);
                                    newsNumber++;
                                }
                            }
                        }

                        else if (allPersons[p1] is Police && allPersons[p2] is Thief || allPersons[p1] is Thief && allPersons[p2] is Police)
                        {
                            if (allPersons[p2] is Thief && allPersons[p2].Inventory.Count > 0)
                            {
                                GeneratePosition(allPersons[p2], 10, 10);
                                inmates.Add(allPersons[p2]);
                                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief {allPersons[p2].Name} was sent to jail"));
                                ((Thief)allPersons[p2]).PrisonStart = DateTime.Now;
                                ((Thief)allPersons[p2]).PrisonStop = ((Thief)allPersons[p2]).PrisonStart.AddSeconds(10 * allPersons[p2].Inventory.Count);
                                allPersons[p1].Inventory.AddRange(allPersons[p2].Inventory);
                                allPersons[p2].Inventory.Clear();
                                //allPersons.RemoveAt(p2);
                                removeList.Add(allPersons[p2]);
                                newsNumber++;
                                break;
                            }
                            else if (allPersons[p2].Inventory.Count == 0 && allPersons[p2] is Thief)
                            {
                                newsNumber = SayHello(allPersons[p1], allPersons[p2], newsFeed, newsNumber); //NYTT
                            }

                            if (allPersons[p1] is Thief && allPersons[p1].Inventory.Count > 0)
                            {
                                GeneratePosition(allPersons[p1], 10, 10);
                                inmates.Add((Thief)allPersons[p1]);
                                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief {allPersons[p1].Name} was sent to jail"));
                                ((Thief)allPersons[p1]).PrisonStart = DateTime.Now;
                                ((Thief)allPersons[p1]).PrisonStop = ((Thief)allPersons[p1]).PrisonStart.AddSeconds(10 * allPersons[p1].Inventory.Count);
                                allPersons[p2].Inventory.AddRange(allPersons[p1].Inventory);
                                allPersons[p1].Inventory.Clear();
                                //allPersons.RemoveAt(p1);
                                removeList.Add(allPersons[p1]);
                                newsNumber++;
                                break;
                            }
                            else if (allPersons[p1].Inventory.Count == 0 && allPersons[p1] is Thief)
                            {
                                newsNumber = SayHello(allPersons[p1], allPersons[p2], newsFeed, newsNumber); //NYTT newsNumber =
                            }

                        }

                        else if (allPersons[p1] is Police && allPersons[p2] is Citizen || allPersons[p1] is Citizen && allPersons[p2] is Police)
                        {
                            newsNumber = SayHello(allPersons[p1], allPersons[p2], newsFeed, newsNumber); //NYTT newsNumber =
                            break;

                        }
                    }
                    foreach (Person person in removeList)
                    {
                        allPersons.Remove(person);
                    }
                }
            }
            return newsNumber;
        }

        public static int AddPerson(List<Person> allPersons, List<Person> fullPeopleList, char key, Queue<string> newsFeed, int newsNumber)
        {
            switch (key)
            {

                case 'p':
                    List<Police> newPolice = Helpers.CreatePolice();
                    allPersons.Add(newPolice[0]);
                    fullPeopleList.Add(newPolice[0]);
                    newsFeed.Enqueue($"{newsNumber}. Police {newPolice[0].Name} arrives to the city.");
                    newsNumber++;
                    break;

                case 'c':
                    List<Citizen> newCitizen = Helpers.CreateCitizen();
                    allPersons.Add(newCitizen[0]);
                    fullPeopleList.Add(newCitizen[0]);
                    newsFeed.Enqueue($"{newsNumber}. Citizen {newCitizen[0].Name} arrives to the city.");
                    newsNumber++;
                    break;

                case 't':
                    List<Thief> newThief = Helpers.CreateThief();
                    allPersons.Add(newThief[0]);
                    fullPeopleList.Add(newThief[0]);
                    newsFeed.Enqueue($"{newsNumber}. Thief {newThief[0].Name} arrives to the city.");
                    newsNumber++;
                    break;

                //case 'v': // Ändra vy
                //          //bool viewText = true;


                //    //while (viewText)
                //    //{
                //    //    //if (Console.KeyAvailable)
                //    //    //{
                //    //    //    ConsoleKeyInfo keyInput = Console.ReadKey(true);
                //    //    //    char input = (char)keyInput.KeyChar;
                //    //    //    if(input == 'm')
                //    //    //    {
                //    //    //        break;
                //    //    //    }
                //    //    //}
                //    //}
                //    break;

                //case 'm':
                //    break;

            }
            return newsNumber;
        }              

        public static int RemoveFromPrison(List<Person> inmates, List<Person> allPersons, Queue<string> newsFeed, int newsNumber)
        {
            if (inmates.Count > 0)
            {
                for (int i = 0; i < inmates.Count; i++)
                {

                    if (((Thief)inmates[i]).PrisonStop <= DateTime.Now)
                    {
                        allPersons.Add(inmates[i]);
                        newsFeed.Enqueue($"{newsNumber}. Thief {inmates[i].Name} is released from prison into the city.");
                        inmates.Remove(inmates[i]);
                        newsNumber++;
                    }
                }
            }
            return newsNumber;
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
        public DateTime PrisonStart;
        public DateTime PrisonStop; //Använda det eller göra på annat sätt?

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
