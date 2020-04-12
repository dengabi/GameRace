using Game.Treat;
using Game.Accelerates;
using System;
using Game.Armor;

namespace Game.Race
{

    class Gnome: RaceBase
    {     
        public override int Health { get ; set ; }
        public override int ImpactForce { get; set; }

        public Gnome()
        {
            this.Health = 100;
            treatBehavior = new TreatWithMana();
            base.TreatEstablished += this.IncreaseHealth;
        }
        public Gnome(ArmorDecoratorBase armor)
        {
            this.Health = armor.GetHealth() + 100;
            Console.WriteLine(this.GetType().Name.ToString() + " Easy clothed " + armor.HealthDisplay());
            acceleratesBehavior = new StrongAccelerate();
            base.TreatEstablished += this.IncreaseHealth;
        }
        public override void Damage(RaceBase race)
        {
            Health -= race.ImpactForce;
        }
        public override void Upgrade()
        {
            if (this.Health <= 30 && this.Health >=21 && !(this.acceleratesBehavior is StrongAccelerate))
            {
                this.SetAccelerateBehaviour(new StrongAccelerate());
                this.Health -= 20;
                Console.WriteLine("__UPGRADE__" + this.GetType().Name.ToString() + " +accelerate (-20 hp)");
            }
        }
        public override void IncreaseHealth(object sender, TreatEventArgs e)
        {
            this.Health += e.Gnome;
            Console.WriteLine("____Buff " + sender.GetType().Name.ToString() + " " + e.Gnome + " hp");
        }
    }
}
