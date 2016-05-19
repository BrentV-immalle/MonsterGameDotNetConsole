using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class OrkNameGenerator
    {
        static List<char> klinkers = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        static List<char> medeklinkers = new List<char> { 'g', 'b', 'z', 'k' };
        static Random rndGen = new Random();

        public static string GetRandomOrkNaam()
        {
            string naam = "";
            naam += medeklinkers[rndGen.Next(medeklinkers.Count)].ToString().ToUpper();
            naam += klinkers[rndGen.Next(klinkers.Count)];
            naam += medeklinkers[rndGen.Next(medeklinkers.Count)];

            return naam;
        }
    }
    
}
