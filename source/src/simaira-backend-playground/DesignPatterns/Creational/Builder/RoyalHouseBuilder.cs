namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RoyalHouseBuilder : LuxuryHouseBuilder
    {
        public RoyalHouseBuilder()
        {
            _house = new House(HouseType.Royal);
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

        public override void BuildGarage()
        {
            throw new NotImplementedException();
        }

        public override void BuildServantQuarter()
        {
            throw new NotImplementedException();
        }

        public virtual void BuildSwimingpool()
        {
            throw new NotImplementedException();
        }

        public virtual void BuildBar()
        {
            throw new NotImplementedException();
        }
    }
}
