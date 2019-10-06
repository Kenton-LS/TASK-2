using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL_CODE
{
    class GameEngine //where the magic happens... and most of the corrections
    {
        public static Random random = new Random();

        Map map; //filed for map
        bool gameOver = false; //set to true if game ends
        string winning = ""; //winning faction string
        int round = 0;

        const string UNITS_FILENAME = "units.txt";
        const string BUILDINGS_FILENAME = "buildings.txt";
        const string ROUND_FILENAME = "rounds.txt"; //makes sure round is consistent

        public GameEngine()
        {
            map = new Map(10, 10); //making map
        }

        public bool GameOver
        {
            get { return gameOver; }
        }

        public string Winning
        {
            get { return winning; }
        }

        public int Round
        {
            get { return round; }
        }

        ///
        
        /*public string DisplayMap()
        {
            return map.DisplayMap(); //map. allows form to access it
        }

        public string Information()
        {
            string info = ""; //making the space between each unit
            foreach (Unit unit in map.Units)
            {
                info += unit + "\n";
            }
            return info;
        }

        public string BuildingInformation()
        {
            string infoB = ""; ///////////////////////////////////////////maybe mistake here
            foreach (Building building in map.Buildings)
            {
                infoB += building + "\n";
            }
            return infoB;
        }*/

        ///

        public void Reset() //reset the map for a new simulation
        {
            map.Reset();
            gameOver = false;
            round = 0;
        }

        ///

        public void GameLoop()
        {
            UpdateUnits(); //break it into sizeable chunks
            UpdateBuildings();
            map.UpdateDisplay();
            round ++;

            /*foreach (Unit unit in map.Units) //link all units in map.Units
            {
                if(unit.IsDestroyed)
                {
                    continue; //guarding if statement: if it is destroyed, go to the next unit in the loop
                }

                Unit closest = unit.GetClosestUnit(map.Units);
                if (closest == null) //avoiding nesting more than 2 if statements (no spaghetti!)
                {
                    gameOver = true;
                    winning = unit.Faction;
                    map.UpdateDisplay();
                    return;
                }

                double percentageHealth = unit.Health / unit.MaxHealth;
                if(percentageHealth <= 0.25) //if health percentage is less than 25%, it must run randomly away
                {
                    unit.Run();
                }
                else if (unit.InRange(closest))
                {
                    unit.Combat(closest);
                }
                else
                {
                    unit.Move(closest);
                }
                MapBoundary(unit, map.Size); //if x < 0, reset x to 0 so it never leaves the map (push unit back in)
            }

            foreach(Building building in map.Buildings)
            {
                building.ResourceCheck(); //GENERATES RESOURCES
                FactorySpawnsUnits(map, fb, map.Size); ///////////////////////SPAWN IN FACTORY TROOPS

                if (building.IsDestroyedB)
                {
                    continue;
                }
                BuildingBoundary(building, map.Size);
                
            }


            
            map.UpdateDisplay();
            round++;*/
        }

        /// 
        /// 
        /// 
        ///
        public void UpdateBuildngs()
        {
            foreach (Building building in map.Buildings)
            {
                if (building is FactoryBuilding)
                {
                    FactoryBuilding factoryBuilding = (FactoryBuilding)building; //if building is a factory, it gets assigned

                    if (round % factoryBuilding.ProductionSpeed == 0) //if the round can be divided by the factory production speed, it creates a unit
                    {
                        Unit newUnit = factoryBuilding.CreateUnit();
                        map.AddUnit(newUnit);
                    }
                }
                else if (building is ResourceBuilding) //resource building
                {
                    ResourceBuilding resourceBuilding = (ResourceBuilding)building; //casting it
                    resourceBuilding.IncreaseResourceAmount();
                }
            }
        }

        public void UpdateUnits()
        {
            foreach (Unit unit in map.Units)
            {
                if(unit.IsDestroyed) //if unit is dead, it will be discarded
                {
                    continue;
                }

                Unit closestUnit = unit.GetClosestUnit(map.Units);
                if(closestUnit == null)
                {
                    gameOver = true;
                    winning = unit.Faction;
                    map.UpdateDisplay();
                    return;
                }

                double percent = unit.Health / unit.MaxHealth; //determining whether to run away. the original code was moved here from the unit class
                if(percent <= 0.25)
                {
                    unit.Run();
                }
                else if (unit.IsInRange(closestUnit))
                {
                    unit.Attack(closestUnit);
                }
                else { unit.Move(closestUnit);
                }
                MapBoundary(units, map.mapSize); //MapBoundary given new parameters
            }
        }
        /// 
        /// 
        /// 
        /// 
        /// 

        /*private void MapBoundary(Unit unit, int size)
        {
            if(unit.X < 0) //push in x
            {
                unit.X = 0;
            }
            else if(unit.X >= size)
            {
                unit.X = size - 1;
            }
            if(unit.Y < 0) //push in y
            {
                unit.Y = 0;
            }
            else if(unit.Y >= size)
            {
                unit.Y = size - 1;
            }
        }

        private void BuildingBoundary(Building building, int size)
        {
            if (building.X < 0) //push in x
            {
                building.X = 0;
            }
            else if (building.X >= size)
            {
                building.X = size - 1;
            }
            if (building.Y < 0) //push in y
            {
                building.Y = 0;
            }
            else if (building.Y >= size)
            {
                building.Y = size - 1;
            }
        }

        public void FactorySpawnsUnits(Map map, FactoryBuilding fb, int size) //FOR FACTORY TO SUMMON A UNIT
        {
            if (round % 5 == 0)
            {
                    //spawn a new unit at y-1; 
                    map.Spawn(fb);
                    //spawn a new unit at y+1;
            }
            else
            {

            }
        }*/

        private void MapBoundary(Unit unit, int mapSize)
        {
            if(unit.X < 0)
            {
                unit.X = 0;
            }
            else if(unit.X >= mapSize)
            {
                unit.X = mapSize - 1;
            }

            if(unit.Y < 0)
            {
                unit.Y = 0;
            }
            else if(unit.Y >= mapSize)
            {
                unit.Y = mapSize - 1;
            }
        }


    }
}
