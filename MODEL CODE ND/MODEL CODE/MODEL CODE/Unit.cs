﻿using System;
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
        public static Random random = new Random(); //to enable random in all classes

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

        public Unit(string values)
        {
            string[] parameters = values.Split(','); //split strings into array of parameters

            x = int.Parse(parameters[1]);

            y = int.Parse(parameters[2]); //pass everything to int

            health = int.Parse(parameters[3]);

            maxHealth = int.Parse(parameters[4]);

            speed = int.Parse(parameters[5]);

            attack = int.Parse(parameters[6]);

            attackRange = int.Parse(parameters[7]);

            faction = parameters[8];

            symbol = parameters[9][0]; //symbol is a char, returns the first character of the symbol 'string'

            nameUnit = parameters[10]

            isDestroyed = parameters[11] == "True" ? true : false; //makes sure are units are still dead during the reload
        }

        public abstract string SaveGame();

        public int X { get { return x; } set { x = value; } }

        public int Y { get { return y; } set { y = value; } }

        public int Health { get { return health; } set { health = value; } }

        public int MaxHealth { get { return maxHealth; } }

        public string Faction { get { return faction; } }

        public char Symbol { get { return symbol; } }

        public bool IsDestroyed { get { return isDestroyed; } }

        public string NameUnit { get { return nameUnit; } }

        ///////////////////
       
        public virtual void Destroy() //death method
        {
            isDestroyed = true;
            isAttacking = false;
            symbol = 'X';
        }

        public virtual void Attack(Unit otherUnit)
        {
            isAttacking = true;
            otherUnit.Health -= attack;

            if(otherUnit.Health <= 0)
            {
                otherUnit.Health = 0;
                otherUnit.Destroy();
            }
        }
    }
     

      /*  public abstract void Move(Unit closestUnit); //Abstract method declarations
        public abstract void Combat(Unit otherUnit);
        public abstract void Run();
        public abstract bool InRange(Unit otherUnit); //Returns a boolean
        public abstract Unit GetClosestUnit(Unit[] units); //Returns Units, takes an array of Units
        public abstract void Kill();*/

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
                   "FACTION:  " + faction[0] + "\nSYMBOL:  " + symbol + "\n";
        }
    }
}
