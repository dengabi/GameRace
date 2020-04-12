using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Treat;
using Game.Accelerates;
using Game.Resurrections;

namespace Game.Race
{
    public class TreatEventArgs
    {
        public int Human { get; private set; }
        public int Orc { get; private set; }
        public int Elf { get; private set; }
        public int Gnome { get; private set; }
        public int Undead { get; private set; }
       
        public TreatEventArgs(int human, int orc, int elf, int gnome, int undead)
        {
            Human = human;
            Orc = orc;
            Elf = elf;
            Gnome = gnome;
            Undead = undead;
        }
    }
    public delegate void TreatEstablishedEventHandler(object sender, TreatEventArgs e);
    abstract class RaceBase
    {
        Random rand = new Random();
        abstract public int Health {get; set; }
        abstract public int ImpactForce { get; set; }

        public ITreat treatBehavior;
        public IAccelerates acceleratesBehavior;
        public IResurrections resurrectionBehavior;

        public RaceBase()
        {
            treatBehavior = new NoTreat();
            acceleratesBehavior = new NoAccelerate();
            resurrectionBehavior = new NoResurrection();
        }
        public event TreatEstablishedEventHandler TreatEstablished;

        public void Buff()
        {
            if (TreatEstablished != null)
                TreatEstablished(this, new TreatEventArgs(rand.Next(5, 15), rand.Next(5, 15), rand.Next(5, 15), rand.Next(5, 15), rand.Next(5, 15)));
        }

        public void SetTreatBehaviour(ITreat newTreatBehavior)
        {
            treatBehavior = newTreatBehavior;
        }

        public void SetAccelerateBehaviour(IAccelerates newAcceleratesBehavior)
        {
            acceleratesBehavior = newAcceleratesBehavior;
        }

        public void SetResurrectBehaviour(IResurrections newResurrectBehavior)
        {
            resurrectionBehavior = newResurrectBehavior;
        } 
              
        public void Accelerate()
        {
            acceleratesBehavior.Accelerate(this);
        }

        public void Treat()
        {
            treatBehavior.Treat(this);
        }

        public void Resurrection()
        {
            resurrectionBehavior.Ressurect(this);
        }

        public void Display()
        {
            this.ImpactForce = rand.Next(15,25);
            Console.WriteLine(this.GetType().Name.ToString() + ": In the arena! " + this.Health + " hp");
        }
        public void Dead()
        {
            if (this.Health <= 0)
                Console.WriteLine(this.GetType().Name.ToString() + ": Dead...");
        }
       
        public void Fights(RaceBase enemy)
        {
            enemy.Damage(this);
            Console.WriteLine("\n" + this.GetType().Name.ToString() + ": Strikes for " + enemy.GetType().Name.ToString() + " " + this.ImpactForce + " ue");
        }
        public abstract void Damage(RaceBase race);
        public abstract void Upgrade();
        public abstract void IncreaseHealth(object sender, TreatEventArgs e);

    }
}
