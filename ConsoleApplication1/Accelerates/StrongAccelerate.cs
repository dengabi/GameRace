using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;

namespace Game.Accelerates
{
    class StrongAccelerate : IAccelerates
    {
        public void Accelerate(RaceBase race)
        {
            race.ImpactForce = race.ImpactForce * 2;
            Console.WriteLine(race.GetType().Name.ToString() + ": Strong acceleration = " + race.ImpactForce.ToString());
        }
    }
}
