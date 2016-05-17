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
            
            Console.WriteLine("In this room there are {0} monsters.", monsters.Count);
            Console.WriteLine("Attack who?");
            int keuzeTeller = 0;
            foreach(var monster in monsters)
            {
                keuzeTeller++;
                Console.WriteLine("{0}. {1} (HP: {2})", keuzeTeller, monster.Name, monster.HP);
            }
            Console.WriteLine("x. Leave room");

            while(inRoom)
            {
                Console.WriteLine(">>>");
                var invoer = Console.ReadLine();
                if (invoer == "x" || invoer == "X")
                {
                    inRoom = false;
                }
                else
                {
                    var keuze = 0;

                    try
                    {
                        keuze = int.Parse(invoer);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Try again...");
                    }

                    try
                    {
                        hero.Attack(monsters[keuze - 1]);
                    } catch(IndexOutOfRangeException e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Monster doesn't exist. Try again.");
                    }

                }
            }
            
        }
    }
}
