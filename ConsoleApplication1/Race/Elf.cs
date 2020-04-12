using Game.Treat;
using Game.Accelerates;
using System;
using Game.Armor;

namespace Game.Race
{
    class Elf:RaceBase
    {       
        public override int Health { get; set; }
        public override int ImpactForce { get; set; }
        public Elf()
        {
            this.Health = 100;
            treatBehavior = new TreatWithMana();
            base.TreatEstablished += this.IncreaseHealth;
        }
        public Elf(ArmorDecoratorBase armor)
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
            this.Health += e.Elf;
            Console.WriteLine("____Buff "+ sender.GetType().Name.ToString() + " " + e.Elf+ " hp");
        }
    }
}
