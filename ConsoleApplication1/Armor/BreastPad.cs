using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;

namespace Game.Armor
{
    class BreastPad : ArmorDecoratorBase
    {
        private ArmorDecoratorBase _armor;
        public BreastPad()
        {
        }
        public BreastPad(ArmorDecoratorBase armor)
        {
            _armor = armor;
        }

        public override int GetHealth()
        {
            return Convert.ToInt32(_armor?.GetHealth()) + 10;
        }

        public override string HealthDisplay()
        {
            return _armor?.HealthDisplay() + " + Breast Pad";
        }
    }
}
