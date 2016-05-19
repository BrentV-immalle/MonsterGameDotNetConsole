using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Room
    {
        private string name;
        private string description;
        List<Monster> monsters = new List<Monster>();
        List<Room> attachedRooms = new List<Room>();

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public Room(string name, int aantalMonsters = 3, string description = "")
        {
            this.name = name;
            for(var i=0; i<aantalMonsters; i++)
            {
                monsters.Add(new Monster(OrkNameGenerator.GetRandomOrkNaam()));
            }
            this.description = description;
        }

        public void Attach(Room room)
        {
            attachedRooms.Add(room);
            //also make sure we can go the other way
            if (!room.IsAttached(this))
            {
                room.Attach(this);
            }
        }

        private bool IsAttached(Room room)
        {
            if(attachedRooms.Contains(room))
            {
                return true;
            }
            return false;
        }

        public void Enter(Hero hero)
        {
            Console.WriteLine("{0} enters {1}.", hero.Name, this.name);

            bool inRoom = true;

            while(inRoom)
            {
                PrintRoomMenu();
                
                var invoer = Console.ReadLine();
                invoer = invoer.ToLower();

                if (invoer == "x")
                {
                    inRoom = false;
                    Console.WriteLine("{0} leaves game.", hero.Name);
                    Environment.Exit(0);
                }
                else
                {
                    int monsterkeuze;
                    if( int.TryParse(invoer, out monsterkeuze) )
                    {
                        // it's a number, so we're selecting a monster
                        if( monsterkeuze > 0 && monsterkeuze <= monsters.Count)
                        {
                            // attack monster and remove if dead
                            if (hero.Attack(monsters[monsterkeuze - 1]))
                            {
                                monsters.RemoveAt(monsterkeuze - 1);
                            };
                        }
                    }
                    else
                    {
                        // it's a letter, so we're selecting a room
                        char r = 'a'; 
                        var index = invoer[0] - r;
                        Console.WriteLine(invoer);
                        Console.WriteLine(index);
                        attachedRooms[index].Enter(hero);
                    }

                }
            }
        }

        private void PrintRoomMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this.description);
            Console.ResetColor();

            PrintAttachedRooms();
            PrintMonsters();

            Console.WriteLine("x. Leave game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(">>> ");
            Console.ResetColor();
        }

        private void PrintMonsters()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("In this room there are {0} monsters.", monsters.Count);
            Console.ResetColor();

            Console.WriteLine("Attack who?");
            int keuzeTeller = 0;
            foreach (var monster in monsters)
            {
                keuzeTeller++;
                Console.WriteLine("{0}. {1} (HP: {2})", keuzeTeller, monster.Name, monster.HP);
            }
        }

        private void PrintAttachedRooms()
        {
            char keuze = 'a';
            foreach(var room in attachedRooms)
            {
                Console.WriteLine("{0}. Go to {1}", keuze, room.Name);
                keuze++;
            }
        }
    }
}
