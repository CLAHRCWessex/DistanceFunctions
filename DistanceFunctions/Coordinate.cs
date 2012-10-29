using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFunctions
{

    /// <summary>
    /// Coordinate Structure for eastings and northings
    /// </summary>
    public struct Coordinate
    {
        private readonly int easting;
        private readonly int northing;

        public int Easting { get { return this.easting; } }
        public int Northing { get { return this.northing; } }

        public Coordinate(int northing, int easting)
        {
            this.easting = easting;
            this.northing = northing;
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", this.Easting, this.Northing);
        }

    }
}
