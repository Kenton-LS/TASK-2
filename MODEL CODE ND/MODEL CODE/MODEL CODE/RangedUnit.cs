using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MODEL_CODE
{
    class RangedUnit : Unit
    {
        public RangedUnit(int x, int y, /*int health, int maxHealth, int speed, int attack, int attackRange, char symbol,*/ string faction/*, string nameUnit*/)
              : base(x, y, 5, 5, 1, 2, 3, 'R', faction, "Ranged") { } //use the base keyword

        public RangedUnit(string values) : base(values) { } //shortened due to unit class having these fused


        /*  public override int X //overridden properties
          {
              get { return x; }
              set { x = value; }
          }

          public override int Y
          {
              get { return y; }
              set { y = value; }
          }

          public override int Health
          {
              get { return health; }
              set { health = value; }
          }

          public override int Attack
          {
              get { return attack; }
              set { attack = value; }
          }

          public override int AttackRange
          {
              get { return attackRange; }
              set { attackRange = value; }
          }

          public override int Speed
          {
              get { return Speed; }
              set { Speed = value; }
          }

          public override int MaxHealth //readonly
          {
              get { return health; }
          }

          public override string Faction
          {
              get { return faction; }
          }

          public override string NameUnit
          {
              get { return nameUnit; }
          }

          public override char Symbol //readonly
          {
              get { return symbol; }
          }

          ///

          public override bool IsDestroyed
          {
              get { return isDestroyed; }
          }

          public override bool InRange(Unit otherUnit)
          {
              return GetDistance(otherUnit) <= attackRange; //repeats this method, saves need for rewriting copious code
          }

          public override void Kill()
          {
              isDestroyed = true;
              isAttacking = false;
              symbol = 'X';
          }

          ///

          public override Unit GetClosestUnit(Unit[] units) //takes in an array of units
          {
              double closest = int.MaxValue; //assigns the largest possible number for distance
              Unit closestUnit = null;

              foreach (Unit otherUnit in units) //working through all the Units
              {
                  if (otherUnit == this || otherUnit.Faction == faction || otherUnit.IsDestroyed) //ignore attacking your own faction Units
                  {
                      continue;
                  }

                  double distance = GetDistance(otherUnit); //calls method, gets distance, checks closest unit and closest distance
                  if (distance < closest)
                  {
                      closest = distance; //find closest Unit to this one
                      closestUnit = otherUnit;
                  }
              }
              return closestUnit; //return the closest Unit available
          }

          ///

          public override void Combat(Unit otherUnit)
          {
              isAttacking = false; //units attack by subtracting ATK from HP 
              otherUnit.Health -= attack;

              if (otherUnit.Health <= 0) //if HP < or = to 0, destroy the unit
              {
                  otherUnit.Kill();
              }
          }

          ///

          public override void Move(Unit closestUnit)
          {
              isAttacking = false;
              int xDirection = closestUnit.X - X;
              int yDirection = closestUnit.Y - Y;

              if (Math.Abs(xDirection) > Math.Abs(yDirection)) //Abs makes end result positive
              {
                  x += Math.Sign(xDirection); //Sign returns if it is positive or negative
              }
              else
              {
                  y += Math.Sign(yDirection);
              } //essentially makes unit move 1 space in a direction
          }

          public override void Run()
          {
              isAttacking = false;
              int direction = r.Next(0, 4); //totally random method of movement, fitting the guidelines
              if (direction == 0)
              {
                  x += 1; // x + 1
              }
              else if (direction == 1)
              {
                  x -= 1; // x - 1
              }
              else if (direction == 2)
              {
                  y += 1; // y + 1
              }
              else if (direction == 3)
              {
                  y -= 1; //y - 1
              }
          }

          public override void Save()
          {
              string spaceMaker = " ";
              string saveString = nameUnit + spaceMaker + x + spaceMaker + y + spaceMaker + health + spaceMaker + maxHealth + spaceMaker +
                                  symbol + spaceMaker + faction + "\n";

              const string FILE_NAME = "UNIT.txt";

              FileStream outFile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
              StreamWriter writer = new StreamWriter(outFile);
              writer.WriteLine(saveString);


              writer.Close();
              outFile.Close();
          }*/

        public override string SaveGame()
        {
            return string.Format(
                $"Ranged, {x}, {y}, {health}, {maxHealth}, {speed}, {attack}, {attackRange}, " + $"{faction}, {symbol}, {nameUnit}, {IsDestroyed}");
        }
    
    }
}