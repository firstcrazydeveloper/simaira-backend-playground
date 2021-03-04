namespace simaira_backend_playground.DesignPatterns.Creational.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class House
    {
        private HouseType _housType;
        private IDictionary<string, string> _parts;

        public House(HouseType houseType)
        {
            _housType = houseType;
            _parts = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

    }
}
