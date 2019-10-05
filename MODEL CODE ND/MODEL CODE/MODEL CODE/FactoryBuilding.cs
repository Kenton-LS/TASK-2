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
        enum FactoryType //spawning specific types of factories
        {
            MELEE,
            RANGED
        }

        private FactoryType factoryType;
        private int productionSpeed;
        private int spawnPoint; //we already have the x, we just need the y for the factory

        public FactoryBuilding(int x, int y, string faction) : base(x, y, 10, /*10,*/ 'F', faction/*, "FACTORY BUILDING", 0, 0, 0, "", 6, 0*/)
        {
            if (y >= Map.Size - 1)
            {
                spawnPoint = y - 1;
            }
            else
            {
                spawnPoint = y + 1;
            }
            factoryType = (FactoryType)GameEngine.random.Next(0, 2);
            productionSpeed = GameEngine.random.Next(3, 7);
        }
        
        ////////////////////////////////////////////////////////

        public FactoryBuilding (string values) //for loading
        {
            string[] parameters = values.Split(','); //split strings into array of parameters

            x = int.Parse(parameters[1]);

            y = int.Parse(parameters[2]); //pass everything to int

            health = int.Parse(parameters[3]);

            maxHealth = int.Parse(parameters[4]);

            factoryType = (FactoryType)int.Parse(parameters[5]); //parse to int THEN resourceType

            productionSpeed = int.Parse(parameters[6]);

            spawnPoint = int.Parse(parameters[7]);

            faction = parameters[9];

            symbol = parameters[10][0]; //symbol is a char, returns the first character of the symbol 'string'

            isDestroyed = parameters[11] == "True" ? true : false; //makes sure are units are still dead during the reload
        }

        public override void Destroy()
        {
            isDestroyed = true;
            symbol = 'X';
        }


        public int ProductionSpeed
        {
            get { return productionSpeed; } //expose this for game engine spawn unit method
        }

        //////////////////////////////
       
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
