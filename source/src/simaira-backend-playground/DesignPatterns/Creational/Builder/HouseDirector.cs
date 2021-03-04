namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HouseDirector
    {
        public void ConstructHouse(BasicHouseBuilder houseBuilder)
        {
            houseBuilder.BuildFloor();
            houseBuilder.BuildWalls();
            houseBuilder.BuildRoof();            
            houseBuilder.BuildDoors();
            houseBuilder.BuildWindows();
        }

        public void ConstructHouse(LuxuryHouseBuilder houseBuilder)
        {
            houseBuilder.BuildFloor();
            houseBuilder.BuildWalls();
            houseBuilder.BuildRoof();
            houseBuilder.BuildDoors();
            houseBuilder.BuildWindows();
            houseBuilder.BuildGarage();
            houseBuilder.BuildServantQuarter();
        }

        public void ConstructHouse(RoyalHouseBuilder houseBuilder)
        {
            houseBuilder.BuildFloor();
            houseBuilder.BuildWalls();
            houseBuilder.BuildRoof();
            houseBuilder.BuildDoors();
            houseBuilder.BuildWindows();
            houseBuilder.BuildGarage();
            houseBuilder.BuildServantQuarter();
            houseBuilder.BuildSwimingpool();
            houseBuilder.BuildBar();
        }
    }
}
