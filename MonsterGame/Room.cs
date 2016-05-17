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

        public Room(string name, int aantalMonsters = 3)
        {
            this.name = name;
            for(var i=0; i<aantalMonsters; i++)
            {
                monsters.Add(new Monster(OrkNameGenerator.GetRandomOrkNaam()));
            }
        }

        public void Enter(Hero hero)
        {
            Console.WriteLine("Hero enters {0}.", this.name);

            bool inRoom = true;

            while(inRoom)
            {
                PrintRoomMenu();
                
                var invoer = Console.ReadLine();
                if (invoer == "x" || invoer == "X")
                {
                    inRoom = false;
                }
                else
                {
                    // TODO: check invoer!
                    var keuze = int.Parse(invoer);
                    if (hero.Attack(monsters[keuze - 1]))
                    {
                        monsters.RemoveAt(keuze - 1);
                    };
                }
            }
        }

        private void PrintRoomMenu()
        {
            Console.WriteLine("In this room there are {0} monsters.", monsters.Count);
            Console.WriteLine("Attack who?");
            int keuzeTeller = 0;
            foreach (var monster in monsters)
            {
                keuzeTeller++;
                Console.WriteLine("{0}. {1} (HP: {2})", keuzeTeller, monster.Name, monster.HP);
            }
            Console.WriteLine("x. Leave room");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(">>> ");
            Console.ResetColor();
        }
    }
}
