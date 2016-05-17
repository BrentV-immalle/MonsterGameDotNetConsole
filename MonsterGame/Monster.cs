using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Monster
    {
        // data-encapsulatie (bepaalde data verbergen)
        private static Random rndGen = new Random();
        private string name;
        private int hp;
        private int ap;

        public Monster(string name, int hp=100, int ap=20)
        {
            this.name = name;
            this.hp = hp;
            this.ap = ap;
            //Console.WriteLine("{0} was created.", name);
        }

        // returns wether monster died
        public bool Attack(Monster m)
        {
            var damage = rndGen.Next(0, this.ap+1);
            m.HP -= damage;
            if(m.HP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} attacks {1} and does {2} damage. {1} dies.",
                this.name, m.name, damage);
                Console.ResetColor();
                return true;
            } else
            {
                Console.WriteLine("{0} attacks {1} and does {2} damage. {1} now has {3} HP.",
                this.name, m.name, damage, m.HP);
                return false;
            }    
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }


    }
}
