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
            Hero hero = new Hero("Ikke", 200, 80);

            var hall = new Room("hall");

            var kitchen = new Room("kitchen", 15);
            var office = new Room("office", 10);

            var garden = new Room("garden", 5);

            garden.Attach(hall);
            hall.Attach(kitchen);
            hall.Attach(office);
            garden.Enter(hero);
        }

    }
}
