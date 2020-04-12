using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;

namespace Game.Treat
{
    class TreatWithMana : ITreat
    {
        public void Treat(RaceBase race)
        {
            int hp = (100 - race.Health) / 2;
            race.Health += hp;
            Console.WriteLine("\n"+ race.GetType().Name.ToString()+ ": Restores health = " +  hp + " hp");
        }
    }
}
