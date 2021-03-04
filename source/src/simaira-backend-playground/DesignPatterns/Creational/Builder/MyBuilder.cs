namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MyBuilder
    {
        public static void BuildHouse()
        {
            HouseDirector houseDirector = new HouseDirector();

            BasicHouseBuilder basicHouseBuilder = new BasicHouseBuilder();            
            houseDirector.ConstructHouse(basicHouseBuilder);
            var basicHouse = basicHouseBuilder.House;

            LuxuryHouseBuilder luxuryHouseBuilder = new LuxuryHouseBuilder();
            houseDirector.ConstructHouse(luxuryHouseBuilder);
            var luxuryHouse = basicHouseBuilder.House;

            RoyalHouseBuilder royalHouseBuilder = new RoyalHouseBuilder();
            houseDirector.ConstructHouse(royalHouseBuilder);
            var royalHouse = basicHouseBuilder.House;

        }        
    }
}
