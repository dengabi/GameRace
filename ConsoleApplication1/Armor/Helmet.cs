using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;

namespace Game.Armor
{
    class Helmet : ArmorDecoratorBase
    {
        private ArmorDecoratorBase _armor;
        public Helmet()
        {
        }
        public Helmet(ArmorDecoratorBase armor)
        {
            _armor = armor;
        }

        public override int GetHealth()
        {
            return Convert.ToInt32(_armor?.GetHealth()) + 5;
        }

        public override string HealthDisplay()
        {
            return _armor?.HealthDisplay() + " + Helmet";
        }
    }
}
