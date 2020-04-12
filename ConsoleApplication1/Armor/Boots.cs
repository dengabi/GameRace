using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;

namespace Game.Armor
{
    class Boots : ArmorDecoratorBase
    {
        private ArmorDecoratorBase _armor;
        public Boots(ArmorDecoratorBase armor)
        {
            _armor = armor;  
        }
        public Boots()
        {
           
        }
        public override int GetHealth()
        {
            return Convert.ToInt32(_armor?.GetHealth()) + 5;
        }

        public override string HealthDisplay()
        {
            return _armor?.HealthDisplay() + " + Boots";
        }
    }
}
