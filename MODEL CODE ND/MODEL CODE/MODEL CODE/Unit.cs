using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL_CODE
{
    abstract class Unit
    {
        protected int x, y, health, maxHealth, speed, attack, attackRange;
        protected string faction, nameUnit;
        protected char symbol; //Mellee or ranged
        protected bool isAttacking = false; //set to false by default, doesn't need a parameter
        protected bool isDestroyed = false;
        public static Random r = new Random(); //to enable random in all classes

        public Unit(int x, int y, int health, int maxHealth, int speed, int attack, int attackRange, char symbol, string faction, string nameUnit) //CONSTRUCTOR
        {
            this.x = x; //Initialize everything
            this.y = y;
            this.health = health;
            this.maxHealth = health; //NB
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.faction = faction;
            this.nameUnit = nameUnit;
            this.symbol = symbol;
        }

        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract int Health { get; set; }
        public abstract int MaxHealth { get; }
        public abstract int Speed { get; set; }
        public abstract int Attack { get; set; }
        public abstract int AttackRange { get; set; }
        public abstract char Symbol { get; }
        public abstract string Faction { get; }
        public abstract string NameUnit { get; }
        public abstract bool IsDestroyed { get; }

        public abstract void Move(Unit closestUnit); //Abstract method declarations
        public abstract void Combat(Unit otherUnit);
        public abstract void Run();
        public abstract bool InRange(Unit otherUnit); //Returns a boolean
        public abstract Unit GetClosestUnit(Unit[] units); //Returns Units, takes an array of Units
        public abstract void Kill();

        protected double GetDistance(Unit otherUnit) //helper method
        {
            double xDistance = otherUnit.X - X; //get x distance
            double yDistance = otherUnit.Y - Y; //get y distance
            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance); //more efficient than Math.Pow
        }

        public override string ToString() //Rather place ToString here instead of dupicating it in other classes (Ranged & Melee)
        {
            return nameUnit + "\n" +
                   "X: " + x + " Y: " + y + "\n" +
                   "HP:  " + health + " / " + maxHealth + "\n" +
                   "FACTION:  " + faction + "\nSYMBOL:  " + symbol + "\n";
        }

        public abstract void Save();
    }
}
