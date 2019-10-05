 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL_CODE
{
    abstract class Building
    {
        protected int x, y, health, maxHealth;
        protected string faction;
        protected char symbol;
        protected bool isDestroyed = false;
        //public static Random r = new Random();



       /* //new RESOURCE
        protected string resourceType; removed code, this will be implemented in enum form in the resource building class
        protected int resourcesGenerated;
        protected int resourcesPerRound;
        protected int resourcePoolRemaining;

        //new FACTORY
        protected string factoryUnitType;
        protected int productionSpeed;
        protected int spawnPoint;*/

        public Building(int x, int y, int health, /*int maxHealth, */char symbol, string faction/*, 
                        string resourceType, int resourcesGenerated, int resourcePoolRemaining, int resourcesPerRound,
                        string factoryUnitType, int productionSpeed, int spawnPoint*/)
        {
            this.x = x; 
            this.y = y;
            this.health = health;
            this.maxHealth = health; //initializing everything
            this.faction = faction;
            this.symbol = symbol;
           /* this.resourceType = resourceType;
            this.resourcesGenerated = resourcesGenerated;
            this.resourcePoolRemaining = resourcePoolRemaining;
            this.resourcesPerRound = resourcesPerRound;
            this.factoryUnitType = factoryUnitType;
            this.productionSpeed = productionSpeed;
            this.spawnPoint = spawnPoint;*/
        }

        public Building() { }

        public int X { get { return x; } } //other classess are supposed to change the variable, ONLY THEN do you add a 'set'for exposing.

        public int Y { get { return y; } } //removed the 'abstract' properties

        //public abstract int Health { get; set; }
        //public abstract int MaxHealth { get; }

        public char Symbol { get { return symbol; } }

        public string Faction { get { return faction; } }

        public abstract void Destroy(); //moved up here, removed bool

        public abstract string SaveGame(); //replaced the save void instead of abstract ToString(), the method is already virtual

        
        /*public abstract string ResourceType { get; }
        public abstract int ResourcesGenerated { get; set; }
        public abstract int ResourcePoolRemaining { get; set; } //replaced in resource and factory classes respectively
        public abstract int ResourcesPerRound { get; set; }

        public abstract string FactoryUnitType { get; }
        public abstract int ProductionSpeed { get; set; }
        public abstract int SpawnPoint { get; set; }*/

        ///

        public override string ToString() //the properties on both the base and inherited classes
        {
            return "X: " + x + " Y: " + y + "\n" +
                   "HP:  " + health + " / " + maxHealth + "\n" +
                   "FACTION:  " + faction + "\nSYMBOL:  " + symbol + "\n";
                  // "RSS GAINED >> " + resourcesGenerated + " / " + resourcePoolRemaining + " << LEFTOVER RSS" + "\n" +
                   //"RSS PER ROUND:  " + resourcesPerRound + "\n";
        }

        /*public void ResourceCheck()
        {
            if (resourcePoolRemaining > 0 && isDestroyedB == false)
            {
                resourcesGenerated = resourcesGenerated + resourcesPerRound;
                resourcePoolRemaining = resourcePoolRemaining - resourcesPerRound; //all moved to resource class
            }
            else
            {
                DestroyB();
            }
        }

        public abstract void Save();*/


    }
}
