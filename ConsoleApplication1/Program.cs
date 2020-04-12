using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Race;
using Game.Armor;
using Game.Accelerates;
using Game.Treat;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int check = 0;
            List<RaceBase> warriars = new List<RaceBase>();
            warriars.Add(new Human(new Boots()));
            warriars.Add(new Orc(new Boots(new Helmet())));
            warriars.Add(new Gnome(new Legs()));
            warriars.Add(new Elf(new BreastPad(new Boots(new Helmet()))));
            warriars.Add(new Undead(new Boots(new ShoulderPads(new Legs()))));
            int person1 = 0;
            int person2 = 0;

            while (warriars.Count > 1)
            {
                if (warriars.Count <= 4 && check == 0)
                {
                    check = 1;
                    foreach (RaceBase race in warriars)
                    {
                        race.Buff();
                    }
                }

                foreach (RaceBase war in warriars)
                {
                    war.Display();                    
                }

                person1 = rand.Next(warriars.Count);
                do
                {
                    person2 = rand.Next(warriars.Count);
                    if (person2 != person1)
                        break;
                }
                while (true);

                if (rand.Next(3) == 1)
                {
                    warriars[person1].Accelerate();
                }

                warriars[person1].Fights(warriars[person2]);

                if (rand.Next(3) == 1)
                {
                    warriars[person2].Upgrade();
                    warriars[person2].Treat();
                    warriars[person2].Resurrection();
                }

                for (int i = 0; i < warriars.Count; i++)
                {
                    if (warriars[i].Health <= 0)
                    {
                        warriars[i].Dead();
                        warriars.RemoveAt(i);
                    }
                }              

                Console.WriteLine();
            }           
            
        }
    }
}
