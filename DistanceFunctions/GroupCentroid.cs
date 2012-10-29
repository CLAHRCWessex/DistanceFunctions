using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace DistanceFunctions
{

    /// <summary>
    /// The centre of a group of eastings and northings
    /// </summary>
    public class GroupCentroid
    {

        EastingNorthingColumnIndexer indexes;
        protected DataTable points;

        protected int eastingCentre;
        protected int northingCentre;

        /// <summary>
        /// Create the group centroid
        /// </summary>
        /// <param name="points">DataTable containing at columns containing northings and eastings</param>
        /// <param name="indexes">Zero based indexes of columns containing eastings and northings</param>
        public GroupCentroid(DataTable points, EastingNorthingColumnIndexer indexes)
        {
            this.points = points;
            this.indexes = indexes;
        }

        private double CalculateAverage(int index)
        {
            double runningTotal = 0.0;
            int nullcases = 0;

            foreach (DataRow row in this.points.Rows)
            {
                // avoid calculation errors on missing values - exclude.
                if (row[index] != null)
                {
                    try
                    {
                        runningTotal += Convert.ToDouble(row[index]);
                    }
                    catch (InvalidCastException)
                    {
                        nullcases++;
                    }
                    
                }
       
            }

            return runningTotal / (this.points.Rows.Count - nullcases);
        }

        /// <summary>
        /// Returns the centre of the eastings
        /// </summary>
        /// <returns>Average easting rounded to nearest metre</returns>
        public int GetEastingCentre()
        {
            if (0 == this.eastingCentre)
            {
                this.eastingCentre = (int)this.CalculateAverage(this.indexes.EastingIndex);
            }
            
            return this.eastingCentre;
        }


        /// <summary>
        /// Returns the centre of the northings
        /// </summary>
        /// <returns>Average northing rounded to nearest metre</returns>
        public int GetNorthingCentre()
        {

            if (0 == this.northingCentre)
            {
                this.northingCentre = (int)this.CalculateAverage(this.indexes.NorthingIndex);
            }

            return this.northingCentre;
        }


        public Coordinate GetCentreCoordinates()
        {
            return new Coordinate(GetNorthingCentre(), GetEastingCentre());
        }
    }
}
