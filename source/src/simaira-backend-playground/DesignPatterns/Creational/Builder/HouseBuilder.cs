namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class HouseBuilder
    {
        protected House _house;

        // Gets vehicle instance

        public House House
        {
            get { return _house; }
        }

        // Abstract build methods

        public abstract void BuildRoof();
        public abstract void BuildFloor();
        public abstract void BuildWalls();
        public abstract void BuildDoors();
        public abstract void BuildWindows();
    }
}
