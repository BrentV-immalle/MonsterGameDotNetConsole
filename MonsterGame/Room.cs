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
        List<Monster> monsters = new List<Monster>();
        List<Room> attachedRooms = new List<Room>();

        public string Name
        {
            get { return name; }
        }

        public Room(string name, int aantalMonsters = 3)
        {
            this.name = name;
            for(var i=0; i<aantalMonsters; i++)
            {
                monsters.Add(new Monster(OrkNameGenerator.GetRandomOrkNaam()));
            }
        }

        public void Attach(Room room)
        {
            attachedRooms.Add(room);
        }

        public void Enter(Hero hero)
        {
            Console.WriteLine("Hero enters {0}.", this.name);

            bool inRoom = true;

            while(inRoom)
            {
                PrintRoomMenu();
                
                var invoer = Console.ReadLine();
                invoer = invoer.ToLower();

                if (invoer == "x")
                {
                    inRoom = false;
                    Console.WriteLine("Hero leaves {0}.", this.Name);
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
            PrintAttachedRooms();
            PrintMonsters();

            Console.WriteLine("x. Leave room");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(">>> ");
            Console.ResetColor();
        }

        private void PrintMonsters()
        {
            Console.WriteLine("In this room there are {0} monsters.", monsters.Count);
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
