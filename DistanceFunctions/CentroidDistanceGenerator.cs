using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Drawing;

namespace DistanceFunctions
{
    public class CentroidDistanceGenerator
    {
        protected IDistanceCalculator calculator;

        public CentroidDistanceGenerator(IDistanceCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<double> GenerateDistances(DataTable points, EastingNorthingColumnIndexer indexer)
        {
            var centroid = new GroupCentroid(points, indexer);
            var distances = new List<double>();        

            foreach (DataRow row in points.Rows)
            {
                distances.Add(this.calculator.Calculate(centroid.GetCentreCoordinates(), 
                    new Coordinate((int)row[indexer.NorthingIndex], (int)row[indexer.EastingIndex])));
            }

            return distances;

        }


        /// <summary>
        /// Calculates the average distance of points from the centroid in one single pass
        /// </summary>
        /// <param name="points">Datatable containing northings and eastings</param>
        /// <param name="eastingIndex">Zero based column index for eastings</param>
        /// <param name="northingIndex">Zero based column index for northings</param>
        /// <returns></returns>
        public double AverageDistance(DataTable points, EastingNorthingColumnIndexer indexer)
        {
            var centroid = new GroupCentroid(points, indexer);
            double runningTotal = 0;
            int nullcases = 0;

            foreach (DataRow row in points.Rows)
            {
                try
                {
                    runningTotal += this.calculator.Calculate(centroid.GetCentreCoordinates(),
                        new Coordinate(Convert.ToInt32(row[indexer.NorthingIndex]), Convert.ToInt32(row[indexer.EastingIndex])));
                }
                catch (InvalidCastException)
                {
                    nullcases++;
                }

            }

            return runningTotal/(points.Rows.Count-nullcases);
        }


        /// <summary>
        /// Calculates the distances of each point from the group centroid
        /// </summary>
        /// <param name="points">Datatable containing northings and eastings</param>
        /// <param name="eastingIndex">Zero based column index for eastings</param>
        /// <param name="northingIndex">Zero based column index for northings</param>
        /// <returns>A list of distances from centroid</returns>
        public List<double> GetIndividualDistances(DataTable points, EastingNorthingColumnIndexer indexer)
        {
            var centroid = new GroupCentroid(points, indexer);
            int nullcases = 0;
            List<double> results = new List<double>();

            foreach (DataRow row in points.Rows)
            {
                try
                {
                    results.Add(this.calculator.Calculate(centroid.GetCentreCoordinates(),
                        new Coordinate(Convert.ToInt32(row[indexer.NorthingIndex]), Convert.ToInt32(row[indexer.EastingIndex]))));
                }
                catch (InvalidCastException)
                {
                    nullcases++;
                }

            }

            return results;
        }

    }


}
