namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BasicHouseBuilder : HouseBuilder
    {
        public BasicHouseBuilder()
        {
            _house = new House(HouseType.Basic);
        }

        public override void BuildDoors()
        {
            throw new NotImplementedException();
        }

        public override void BuildFloor()
        {
            throw new NotImplementedException();
        }

        public override void BuildRoof()
        {
            throw new NotImplementedException();
        }

        public override void BuildWalls()
        {
            throw new NotImplementedException();
        }

        public override void BuildWindows()
        {
            throw new NotImplementedException();
        }
    }
}
