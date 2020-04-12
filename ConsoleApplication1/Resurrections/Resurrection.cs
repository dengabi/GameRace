using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;

namespace Game.Resurrections
{
    class Resurrection : IResurrections
    {
        public void Ressurect(RaceBase race)
        {
            if (race.Health <= 0)
            {
                race.Health = 100;
                Console.WriteLine(race.GetType().Name.ToString() + ": I'm alive again! (100 hp)");
            }
           
        }
    }
}
