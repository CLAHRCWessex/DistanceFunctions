using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFunctions
{
    public struct EastingNorthingColumnIndexer
    {
        private readonly int eastingIndex;
        private readonly int northingIndex;

        public int EastingIndex { get { return this.eastingIndex; } }
        public int NorthingIndex { get { return this.northingIndex; } }

        public EastingNorthingColumnIndexer(int eastingIndex, int northingIndex)
        {
            this.eastingIndex = eastingIndex;
            this.northingIndex = northingIndex;
        }

        public override string ToString()
        {
            return string.Format("Eastings in column {0}; Northings in column {1}", this.EastingIndex, this.NorthingIndex);
        }

    }
}
