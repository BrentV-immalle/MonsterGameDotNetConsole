using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Creature
    {
        private static Random rndGen = new Random();
        private string name;
        private int hp;
        private int ap;

        public string Name
        {
            get { return name; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public Creature(string name, int hp = 100, int ap = 20)
        {
            this.name = name;
            this.hp = hp;
            this.ap = ap;
        }

        // returns wether creature died
        public bool Attack(Creature c)
        {
            var damage = rndGen.Next(0, this.ap + 1);
            c.HP -= damage;
            if (c.HP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} attacks {1} and does {2} damage. {1} dies.",
                this.name, c.name, damage);
                Console.ResetColor();
                return true;
            }
            else
            {
                Console.WriteLine("{0} attacks {1} and does {2} damage. {1} now has {3} HP.",
                this.name, c.name, damage, c.HP);
                return false;
            }
        }
    }
}
