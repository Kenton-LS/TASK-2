  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MODEL_CODE
{
    class ResourceBuilding : Building
    {
        public enum ResourceType
        {
            TWIGS,
            GRASS,
            ROCKS,
            LOGS
        }

        private string resourceType;
        private int resourcesGenerated;
        private int resourcesPerRound;
        private int resourcePoolRemaining;


        public ResourceBuilding(int x, int y, string faction) : base(x, y, 15, /*15,*/ '$', faction/*, "RESOURCE BUILDING", 0, 250, 25, "", 0, 0*/)
        {
            type = (ResourceType)GameEngine.random.Next(0, 4); //pass the position and faction to make it easier for map class to read
            resourcesGenerated = 0;
            resourcesPerRound = GameEngine.random.Next(1, 6);
            resourcePoolRemaining = GameEngine.random.Next(100, 200);
        }

        public ResourceBuilding(string values)
        {
            string[] parameters = values.Split(','); //split strings into array of parameters

            x = int.Parse(parameters[1]);

            y = int.Parse(parameters[2]); //pass everything to int

            health = int.Parse(parameters[3]);

            maxHealth = int.Parse(parameters[4]);

            type = (ResourceType)int.Parse(parameters[5]); //parse to int THEN resourceType

            resourcesPerRound = int.Parse(parameters[6]);

            resourcePoolRemaining = int.Parse(parameters[7]);

            faction = parameters[9];

            symbol = parameters[10][0]; //symbol is a char, returns the first character of the symbol 'string'

            isDestroyed = parameters[11] == "True" ? true : false; //makes sure are units are still dead during the reload
        }

        /////////////////////////
        
        public override void Destroy() //death method to change unit symbol and true the death boolean
        {
            isDestroyed = true;
            symbol = 'X';
        }

      /*  public override string ResourceType  removed code
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
        }*/


        /// RESOURCE GENERATION METHOD RESOURCECHECK() IS IN THE BUILDING CLASS

        ///FACTORY

        /*public override string FactoryUnitType
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
            set {spawnPoint = value; }
        }*/

        public override void Save()
        {
           string spaceMaker = " ";
            string saveString = resourceType + spaceMaker + x + spaceMaker + y + spaceMaker + health + spaceMaker + maxHealth + spaceMaker + 
                                symbol + spaceMaker + faction + spaceMaker + resourcesGenerated + spaceMaker + resourcePoolRemaining + spaceMaker + resourcesPerRound + "\n";

            const string FILE_NAME = "BUILDING.txt";

            FileStream outFile = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            writer.WriteLine(saveString);


            writer.Close();
            outFile.Close();
        }
    }
}
