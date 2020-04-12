using Game.Accelerates;
using Game.Treat;
using System;
using Game.Armor;

namespace Game.Race
{
    class Orc : RaceBase
    {
        
        public override int Health { get ;  set ; }
        public override int ImpactForce { get; set; }
        public Orc()
        {
            this.Health = 100;
            acceleratesBehavior = new StrongAccelerate();
            base.TreatEstablished += this.IncreaseHealth;
        }
        public Orc(ArmorDecoratorBase armor)
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
            if (this.Health <= 30 && this.Health >= 21 && !(this.treatBehavior is TreatWithMana))
            {
                this.SetTreatBehaviour(new TreatWithMana());
                this.Health -= 20;
                Console.WriteLine("__UPGRADE__" + this.GetType().Name.ToString() + " +treat (-20 hp)");
            }
        }

        public override void IncreaseHealth(object sender, TreatEventArgs e)
        {
            this.Health += e.Orc;
            Console.WriteLine("____Buff " + sender.GetType().Name.ToString() + " " + e.Orc + " hp");
        }
    }
}

