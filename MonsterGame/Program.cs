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

            var hall = new Room("hall", description: "A very narrow hallway...");
            var kitchen = new Room("kitchen", 15, "It smells like something died in here...");
            var office = new Room("office", 10, "It's a long time ago somebody was actually working in here...");
            var garden = new Room("garden", 5, "No sign of grass in this garden.\nIt contains only huge weeds.\nSome are longer than you.");

            garden.Attach(hall);
            hall.Attach(kitchen);
            hall.Attach(office);
            garden.Enter(hero);
        }

    }
}
