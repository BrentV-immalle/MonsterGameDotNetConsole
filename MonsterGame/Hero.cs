using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Hero : Creature
    {
        public Hero(string name, int hp=1000, int ap=30) :
            base(name)
        {

        }
    }
}
