using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bossfight
{
    internal class GameCharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        private int initialStamina;

        public GameCharacter(string name, int health, int strength, int stamina)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
            initialStamina = stamina;
        }

        public void Fight(GameCharacter opponent)
        {
            opponent.Health -= Strength;
            Stamina -= 10;
            Console.WriteLine($"{Name} attacks {opponent.Name} for {Strength} damage!");
        }

        public void Recharge()
        {
            Stamina = initialStamina;
            Console.WriteLine($"{Name} is recharging stamina...");
        }
    }
}
