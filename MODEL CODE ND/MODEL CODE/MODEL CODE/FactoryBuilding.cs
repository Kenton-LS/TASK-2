using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MODEL_CODE
{
    class FactoryBuilding : Building
    {
        public FactoryBuilding(int x, int y, string faction) : base(x, y, 10, 10, 'F', faction, "FACTORY BUILDING", 0, 0, 0, "", 6, 0) { }


        public override int X
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

        public override int MaxHealth
        {
            get { return health; }
        }

        public override string Faction
        {
            get { return faction; }
        }

        public override char Symbol
        {
            get { return symbol; }
        }

        /////////////////////////
        public override bool IsDestroyedB //DEATH
        {
            get { return isDestroyedB; }
        }

        public override void DestroyB()
        {
            if (health <= 0)
            {
                isDestroyedB = true;
                symbol = 'X';
            }
        }

        //////////////////////////////

        /// new

        public override string ResourceType
        {
            get { return resourceType; }
        }

        public override int ResourcePoolRemaining
        {
            get { return resourcePoolRemaining; }
            set { resourcePoolRemaining = value; }
        }

        public override int ResourcesGenerated
        {
            get { return resourcesGenerated; }
            set { resourcesGenerated = value; }
        }

        public override int ResourcesPerRound
        {
            get { return resourcesPerRound; }
            set { resourcesPerRound = value; }
        }

        /// FACTORY FIELDS
        public override string FactoryUnitType
        {
            get { return factoryUnitType; }
        }

        public override int ProductionSpeed
        {
            get { return productionSpeed; }
            set { productionSpeed = value; }
        }

        public override int SpawnPoint
        {
            get { return spawnPoint; }
            set { spawnPoint = value; }
        }

        public override string ToString()
        {
            return resourceType + "\n" +
                   "X: " + x + " Y: " + y + "\n" +
                   "HP:  " + health + " / " + maxHealth + "\n" +
                   "FACTION:  " + faction + "\nSYMBOL:  " + symbol + "\n" +
                   "PRODUCTION SPEED:  " + productionSpeed + "\n"  /*+
                   "RSS GAINED >> " + resourcesGenerated + " / " + resourcePoolRemaining + " << LEFTOVER RSS" + "\n" +
                   "RSS PER ROUND:  " + resourcesPerRound + "\n"*/;
        }

        public override void Save()
        {
            string spaceMaker = " ";
            string saveString = resourceType + spaceMaker + x + spaceMaker + y + spaceMaker + health + spaceMaker + maxHealth + spaceMaker +
                                symbol + spaceMaker + faction + spaceMaker + productionSpeed + "\n";

            const string FILE_NAME = "BUILDING.txt";

            FileStream outFile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            writer.WriteLine(saveString);


            writer.Close();
            outFile.Close();
        }
    }
}
