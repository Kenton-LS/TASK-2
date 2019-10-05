using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MODEL_CODE
{
    class Map
    {
        int mapSize = 20;
        public int randomNumberOfUnits;
        public int numberOfBuildings;
        Unit[] units;
        Building[] buildings;
        string[,] map; //map stored in a string to hsve 3 characters represent a block
        string[] factions = { "BLUE", "RED" };
        string[] nameUnits1 = { "PIKEMAN", "SWORDSMAN", "KNIGHT", "BESERKER", "PALADIN" };
        string[] nameUnits2 = { "ARCHER", "MAGE", "CROSSBOWMAN", "GRENADIER", "SPEARTHROWER" };

        Random r = new Random();

        ///

        public Map(int randomNumberOfUnits, int numberOfBuildings)
        {
            this.randomNumberOfUnits = randomNumberOfUnits; //pass the number of units
            this.numberOfBuildings = numberOfBuildings;
            Reset();
        }

        public Unit[] Units
        {
            get { return units; }
        }

        public Building[] Buildings
        {
            get { return buildings; }
        }

        public int Size
        {
            get { return mapSize; }
        }

        public string DisplayMap() //building and returning a string
        {
            string mapString = ""; //building a string and returning it
            for(int y = 0; y < mapSize; y++)
            {
                for(int x = 0; x < mapSize; x++)
                {
                    mapString += map[x, y];
                }
            }
            return mapString;
        }

        public void Reset()
        {
            map = new string[mapSize, mapSize]; //initialie map
            units = new Unit[randomNumberOfUnits]; //initialize units
            buildings = new Building[numberOfBuildings]; ///////////////////////////////////////////maybe here
            InitializeUnits(); //calling methods
            InitializeBuildings();
            UpdateDisplay();
            
        }

        ///

        public void UpdateDisplay() //clears the map, sets everything to dots
        {
            for(int y = 0; y < mapSize; y++)
            {
                for(int x = 0; x < mapSize; x++)
                {
                    map[x, y] = " . ";
                }
            }
            foreach(Unit unit in units)
            {
                map[unit.X, unit.Y] = unit.Faction[0] + "/" + unit.Symbol;
            }

            foreach(Building building in buildings)
            {
                map[building.X, building.Y] = building.Faction[0] + "/" + building.Symbol;
            }
        }

        ///
      
        public void InitializeUnits()
        {
            for(int i = 0;i < units.Length; i++)
            {
                int x = r.Next(0, mapSize); //generate x and y values
                int y = r.Next(0, mapSize);
                int factionIndex = r.Next(0, 2); //decides blue or red team
                int nameIndex = r.Next(0, 5);
                int unitType = r.Next(0, 2); //decides ranged or melee

                while(map[x, y] != null)
                {
                    x = r.Next(0, mapSize);
                    y = r.Next(0, mapSize);
                }

                if(unitType == 0)
                {
                    units[i] = new MeleeUnit(x, y, factions[factionIndex], nameUnits1[nameIndex]);
                }
                else
                {
                    units[i] = new RangedUnit(x, y, factions[factionIndex], nameUnits2[nameIndex]);
                }
                map[x, y] = units[i].Faction[0] + "/" + units[i].Symbol; //returns the team and the unit type
                
                
            }
        }
   
        public void InitializeBuildings()
        {
            
            for (int ii = 0; ii < buildings.Length; ii++)
            {

                int bx = r.Next(0, mapSize);
                int by = r.Next(0, mapSize);
                int factionIndex = r.Next(0, 2);
                int buildingType = r.Next(0, 2);

                while (map[bx, by] != null)
                {
                    bx = r.Next(0, mapSize);
                    by = r.Next(0, mapSize);
                }

                if (buildingType == 0)
                {
                    buildings[ii] = new ResourceBuilding(bx, by, factions[factionIndex]);
                
                }
                else
                {
                    buildings[ii] = new FactoryBuilding(bx, by, factions[factionIndex]);
                   
                }
                
                map[bx, by] = buildings[ii].Faction[0] + "/" + buildings[ii].Symbol;
            }
        }

        /// 
        ///  FACTORY
        /// 

        public void Spawn(Building building)
        {
            for (int iii = 0; iii < buildings.Length; iii++)
            {
                Array.Resize(ref units, units.Length + 1);

                int cx = buildings[iii].X; //generate x and y values
                int cy = buildings[iii].Y + 1;
                if(buildings[iii].Y > mapSize)
                {
                    cy = buildings[iii].Y - 1;
                }

                int factionIndex = r.Next(0, 2); //decides blue or red team
                int nameIndex = r.Next(0, 5);
                int unitType = r.Next(0, 2); //decides ranged or melee

               /* if (map[cx, cy] != null)
                {
                    
                }*/

                if (unitType == 0)
                {
                    units[units.Length - 1] = new MeleeUnit(cx, cy, factions[factionIndex], nameUnits1[nameIndex]);
                }
                else
                {
                    units[units.Length - 1] = new RangedUnit(cx, cy, factions[factionIndex], nameUnits1[nameIndex]);
                }

                map[cx, cy] = units[iii].Faction[0] + "/" + units[iii].Symbol;
           
            }
        }
    }
}
