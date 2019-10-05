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
        protected bool isDestroyedB = false;
        public static Random r = new Random();



        //new RESOURCE
        protected string resourceType;
        protected int resourcesGenerated;
        protected int resourcesPerRound;
        protected int resourcePoolRemaining;

        //new FACTORY
        protected string factoryUnitType;
        protected int productionSpeed;
        protected int spawnPoint;

        public Building(int x, int y, int health, int maxHealth, char symbol, string faction, 
                        string resourceType, int resourcesGenerated, int resourcePoolRemaining, int resourcesPerRound,
                        string factoryUnitType, int productionSpeed, int spawnPoint)
        {
            this.x = x;
            this.y = y;
            this.health = health;
            this.maxHealth = health; 
            this.faction = faction;
            this.symbol = symbol;
            this.resourceType = resourceType;
            this.resourcesGenerated = resourcesGenerated;
            this.resourcePoolRemaining = resourcePoolRemaining;
            this.resourcesPerRound = resourcesPerRound;
            this.factoryUnitType = factoryUnitType;
            this.productionSpeed = productionSpeed;
            this.spawnPoint = spawnPoint;
        }

        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract int Health { get; set; }
        public abstract int MaxHealth { get; }
        public abstract char Symbol { get; }
        public abstract string Faction { get; }
        public abstract bool IsDestroyedB { get; }

        //new
        public abstract string ResourceType { get; }
        public abstract int ResourcesGenerated { get; set; }
        public abstract int ResourcePoolRemaining { get; set; }
        public abstract int ResourcesPerRound { get; set; }

        public abstract string FactoryUnitType { get; }
        public abstract int ProductionSpeed { get; set; }
        public abstract int SpawnPoint { get; set; }

        ///

        public abstract void DestroyB();

        public override string ToString()
        {
            return resourceType + "\n" +
                   "X: " + x + " Y: " + y + "\n" +
                   "HP:  " + health + " / " + maxHealth + "\n" +
                   "FACTION:  " + faction + "\nSYMBOL:  " + symbol + "\n" +
                   "RSS GAINED >> " + resourcesGenerated + " / " + resourcePoolRemaining + " << LEFTOVER RSS" + "\n" +
                   "RSS PER ROUND:  " + resourcesPerRound + "\n";
        }

        public void ResourceCheck()
        {
            if (resourcePoolRemaining > 0 && isDestroyedB == false)
            {
                resourcesGenerated = resourcesGenerated + resourcesPerRound;
                resourcePoolRemaining = resourcePoolRemaining - resourcesPerRound;
            }
            else
            {
                DestroyB();
            }
        }

        public abstract void Save();


    }
}
