using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero("Ikke", 200, 30);

            var hall = new Room("hall");
            hall.Attach(new Room("office", 10));
            hall.Attach(new Room("kitchen", 15));

            hall.Enter(hero);
        }

    }
}
