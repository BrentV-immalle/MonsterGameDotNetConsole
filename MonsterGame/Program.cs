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
            Hero hero = new Hero("Immahero", 200, 80);

            var hall = new Room("hall", description: "A very narrow hallway...");
            var kitchen = new Room("kitchen", 15, "It smells like something died in here...");
            var office = new Room("office", 10, "It seems like a really long time ago somebody was working in here.\nThere is a broken computer-screen on a desk.\nThe seat of the chair has been largely eaten by mice.");
            var garden = new Room("garden", 5, "No sign of grass in this garden.\nIt contains only huge weeds.\nSome are longer than you.");

            garden.Attach(hall);
            hall.Attach(kitchen);
            hall.Attach(office);
            garden.Enter(hero);
        }

    }
}
