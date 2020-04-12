using Game.Resurrections;
using Game.Accelerates;
using System;
using Game.Armor;

namespace Game.Race
{
    class Undead : RaceBase
    {        
        public override int Health { get ; set ; }
        public override int ImpactForce { get; set; }
        public Undead()
        {
            this.Health = 100;            
            resurrectionBehavior = new Resurrection();
            base.TreatEstablished += this.IncreaseHealth;
        }
        public Undead(ArmorDecoratorBase armor)
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
            if (this.Health <= 30 && this.Health >=11 && !(this.acceleratesBehavior is StrongAccelerate))
            {
                this.SetAccelerateBehaviour(new StrongAccelerate());
                this.Health -= 10;
                Console.WriteLine("__UPGRADE__" + this.GetType().Name.ToString() + " +accelerate (-10 hp)");
            }
        }

        public override void IncreaseHealth(object sender, TreatEventArgs e)
        {
            this.Health += e.Undead;
            Console.WriteLine("____Buff " + sender.GetType().Name.ToString() + " " + e.Undead + " hp");
        }
    }
}
