namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LuxuryHouseBuilder : HouseBuilder
    {
        public LuxuryHouseBuilder()
        {
            _house = new House(HouseType.Luxury);
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

        public virtual void BuildGarage()
        {
            throw new NotImplementedException();
        }

        public virtual void BuildServantQuarter()
        {
            throw new NotImplementedException();
        }
    }
}
