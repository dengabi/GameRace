using System;
using Game.Race;

namespace Game.Armor
{
    abstract class ArmorDecoratorBase
    {
        abstract public int GetHealth();
        abstract public string HealthDisplay();
    }
}
