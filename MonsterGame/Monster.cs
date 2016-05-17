using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Monster : Creature
    {  
        public Monster(string name, int hp=100, int ap=20) :
            base(name, hp, ap)
        {

        }

    }
}
