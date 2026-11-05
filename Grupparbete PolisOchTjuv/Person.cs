using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace Grupparbete_PolisOchTjuv
{
    internal class Person
    {
        internal string Name { get; set; }
        internal char Icon { get; set; }
        internal ConsoleColor IconColor { get; set; }
        internal int CurrentPositionX { get; set; }
        internal int CurrentPositionY { get; set; }
        internal int MovePositionX { get; set; }
        internal int MovePositionY { get; set; }
        internal List<string> Inventory { get; set; }

        internal Person(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory)
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

        internal static void PrintPersonInfo(List<Person> fullPeopleList)                                                                                           //SKriver ut type, invenotry, pos x +y för alla personer. Används i PrintTextOverview.
        {
            for (int i = 0; i < fullPeopleList.Count; i++)
            {
                Console.Write($"Person {i}: {fullPeopleList[i].GetType().Name}: ");
                foreach (String item in fullPeopleList[i].Inventory)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine($"- {fullPeopleList[i].CurrentPositionX}, {fullPeopleList[i].CurrentPositionY}.                                                                                                                       ");

            }
        }

        internal static void PersonMove(List<Person> cityList, Place map)                                                                                           //List innehåller koordinater och map innehåller strukturen/ritning för kartan.
        {
            foreach (Person person in cityList)
            {

                person.CurrentPositionX += person.MovePositionX;                                                                                                    //Nuvarande position + riktningsändring i x- och y-led
                person.CurrentPositionY += person.MovePositionY;

                if (person.CurrentPositionX <= 0)
                {
                    person.CurrentPositionX = map.Width;                                                                                                            //Om personen rör sig utanför kanten så återställs currentposition till motsatt sida.
                }
                else if (person.CurrentPositionX >= map.Width)
                {
                    person.CurrentPositionX = 0;
                }
                else if (person.CurrentPositionY <= 0)
                {
                    person.CurrentPositionY = map.Height;                                                                                                           //Samma som ovan fast y-led
                }
                else if (person.CurrentPositionY >= map.Height)
                {
                    person.CurrentPositionY = 0;
                }
            }
        }

        internal virtual int SayHello(Person p2, Queue<string> newsFeed, int newsNumber)                                                                            //Polymorfism
        {
            return newsNumber;
        }

        internal static int PersonCollision(List<Person> cityList, List<Person> inmates, List<Person> poorPeople, Queue<string> newsFeed, int newsNumber)
        {
            List<Person> removeList = new List<Person>();                                                                                                           //Samlar personen som ska byta plats. De tas bort i slutet.

            for (int p1 = 0; p1 < cityList.Count - 1; p1++)                                                                                                         //Tar en person och jämför med alla andra personer i cityList(två första for-looparna).
            {
                for (int p2 = p1 + 1; p2 < cityList.Count; p2++)                                                                                                    //Ej  cityList.COunt - 1 pga loopen avslutas innan sista indexet för att det är slut på personer att jämföra. 
                {
                    if (cityList[p1].CurrentPositionX == cityList[p2].CurrentPositionX && cityList[p1].CurrentPositionY == cityList[p2].CurrentPositionY)           //Positionsjämförelse p1 och p2.
                    {
                        if (cityList[p1] is Thief && cityList[p2] is Citizen || cityList[p1] is Citizen && cityList[p2] is Thief)
                        {
                            var thief = (Thief)(cityList[p1] is Thief ? cityList[p1] : cityList[p2]);                                                               //Undersöker vilken av p1 och p2 som är tjuv -> sparar i varsin variabel.
                            var citizen = (Citizen)(cityList[p1] is Citizen ? cityList[p1] : cityList[p2]);

                                if (citizen.Inventory.Count > 0)                                                                                                    //Om inventory > 0 så blir den rånad
                                {
                                    Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief {thief.Name} stole {citizen.Inventory[0]} from citizen {citizen.Name}."));
                                    thief.Inventory.Add(citizen.Inventory[0]);
                                    citizen.Inventory.RemoveAt(0);
                                    newsNumber++;
                                }

                                if (citizen.Inventory.Count == 0)                                                                                                   //När den blir bestulen och inventory blir == 0
                                {
                                    GeneratePosition(citizen, 50, 10);
                                    Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Citizen {citizen.Name} was sent to poorhouse."));
                                    citizen.PoorHouseStart = DateTime.Now;
                                    citizen.PoorHouseStop = citizen.PoorHouseStart.AddSeconds(10);
                                    poorPeople.Add(citizen);
                                    removeList.Add(citizen);
                                    newsNumber++;
                                }

                        }

                        else if (cityList[p1] is Police && cityList[p2] is Thief || cityList[p1] is Thief && cityList[p2] is Police)                                //Om en av personerna är police och den andra tjuv
                        {
                            var thief = (Thief)(cityList[p1] is Thief ? cityList[p1] : cityList[p2]);
                            var police = (Police)(cityList[p1] is Police ? cityList[p1] : cityList[p2]);

                            if (thief.Inventory.Count > 0)
                            {
                                GeneratePosition(thief, 10, 10);
                                inmates.Add(thief);
                                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. Thief {thief.Name} was sent to jail."));
                                thief.PrisonStart = DateTime.Now;
                                thief.PrisonStop = thief.PrisonStart.AddSeconds(10 * thief.Inventory.Count);
                                police.Inventory.AddRange(thief.Inventory);
                                thief.Inventory.Clear();
                                removeList.Add(thief);
                                newsNumber++;
                                break;
                            }
                            else if (thief.Inventory.Count == 0)
                            {
                                newsNumber = cityList[p1].SayHello(cityList[p2], newsFeed, newsNumber);
                            }
                        }

                        else if (cityList[p1] is Police && cityList[p2] is Citizen || cityList[p1] is Citizen && cityList[p2] is Police)                            //Om polis och medborgare möts
                        {
                            newsNumber = cityList[p1].SayHello(cityList[p2], newsFeed, newsNumber);
                            break;

                        }
                        else if (cityList[p1] is Citizen && cityList[p2] is Citizen)
                        {
                            newsNumber = cityList[p1].SayHello(cityList[p2], newsFeed, newsNumber);
                            break;
                        }
                    }

                    foreach (Person person in removeList)                                                                                                           //Tar bort alla som ska flyttas till annat place från cityList.
                    {
                        cityList.Remove(person);
                    }
                }
            }
            return newsNumber;
        }

        internal static int AddPerson(List<Person> allPersons, List<Person> fullPeopleList, char key, Queue<string> newsFeed, int newsNumber)
        {
            switch (key)
            {

                case 'p':

                    List<Police> newPolice = Helpers.CreatePolice();
                    allPersons.Add(newPolice[0]);
                    fullPeopleList.Add(newPolice[0]);
                    Place.AddNewsFeed(newsFeed, $"{newsNumber}. Police {newPolice[0].Name} arrives to the city.");
                    newsNumber++;
                    break;

                case 'c':
                    List<Citizen> newCitizen = Helpers.CreateCitizen();
                    allPersons.Add(newCitizen[0]);
                    fullPeopleList.Add(newCitizen[0]);
                    Place.AddNewsFeed(newsFeed, $"{newsNumber}. Citizen {newCitizen[0].Name} arrives to the city.");
                    newsNumber++;
                    break;

                case 't':
                    List<Thief> newThief = Helpers.CreateThief();
                    allPersons.Add(newThief[0]);
                    fullPeopleList.Add(newThief[0]);
                    Place.AddNewsFeed(newsFeed, $"{newsNumber}. Thief {newThief[0].Name} arrives to the city.");
                    newsNumber++;
                    break;

            }
            return newsNumber;
        }

        internal static int RemoveFromPrison(List<Person> inmates, List<Person> allPersons, Queue<string> newsFeed, int newsNumber)
        {
            if (inmates.Count > 0)
            {
                for (int i = 0; i < inmates.Count; i++)
                {

                    if (((Thief)inmates[i]).PrisonStop <= DateTime.Now)                                                                                         //Loopen körs om fångens stopptid har passerat Datetime.Now.
                    {
                        allPersons.Add(inmates[i]);
                        Place.AddNewsFeed(newsFeed, $"{newsNumber}. Thief {inmates[i].Name} is released from prison into the city.");
                        inmates.Remove(inmates[i]);
                        newsNumber++;
                    }
                }
            }
            return newsNumber;
        }

        internal static int RemoveFromPoorHouse(List<Person> poorPeople, List<Person> allPersons, Queue<string> newsFeed, int newsNumber)
        {
            if (poorPeople.Count > 0)
            {
                for (int i = 0; i < poorPeople.Count; i++)
                {

                    if (((Citizen)poorPeople[i]).PoorHouseStop <= DateTime.Now)                                                                                 //Loopen körs om slumens stopptid har passerat Datetime.Now.
                    {
                        poorPeople[i].Inventory.Add("money");
                        allPersons.Add(poorPeople[i]);
                        Place.AddNewsFeed(newsFeed, $"{newsNumber}. Slum {poorPeople[i].Name} is released from poor house into the city with a bit of money.");
                        poorPeople.Remove(poorPeople[i]);
                        newsNumber++;
                    }
                }
            }
            return newsNumber;
        }

        private static void GeneratePosition(Person person, int width, int height)
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
        public DateTime PrisonStop;

        public Thief(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
        {
            Inventory = inventory;

        }
        internal override int SayHello(Person p2, Queue<string> newsFeed, int newsNumber)
        {
            if (p2 is Police && this.Inventory.Count == 0)
            {
                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. {this.GetType().Name} {this.Name} says hello to {p2.GetType().Name} {p2.Name}."));
                newsNumber++;
            }

            return newsNumber;
        }
    }

    class Citizen : Person
    {
        public DateTime PoorHouseStart;
        public DateTime PoorHouseStop;

        public Citizen(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
        {
            Inventory = inventory;
        }
        internal override int SayHello(Person p2, Queue<string> newsFeed, int newsNumber)
        {
            Place.AddNewsFeed(newsFeed, $"{newsNumber}. {this.GetType().Name} {this.Name} says hello to {p2.GetType().Name} {p2.Name}.");
            return newsNumber + 1;
        }
    }

    class Police : Person
    {
        public Police(string name, char icon, ConsoleColor iconColor, int currentPositionX, int currentPositionY, int movePositionX, int movePositionY, List<string> inventory) : base(name, icon, iconColor, currentPositionX, currentPositionY, movePositionX, movePositionY, inventory)
        {
            Inventory = inventory;
        }

        internal override int SayHello(Person p2, Queue<string> newsFeed, int newsNumber)
        {
            if (p2 is Thief && p2.Inventory.Count == 0)
            {
                Place.AddNewsFeed(newsFeed, ($"{newsNumber}. {this.GetType().Name} {this.Name} says hello to {p2.GetType().Name} {p2.Name}."));
                newsNumber++;
            }

            return newsNumber;
        }
    }
}
