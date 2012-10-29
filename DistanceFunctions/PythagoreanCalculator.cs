/*
 * Created by SharpDevelop.
 * User: Tom
 * Date: 21/08/2012
 * Time: 19:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Data;

namespace DistanceFunctions
{
	/// <summary>
	/// Calculates the distance between two points specified in Northings and Eastings
	/// </summary>
    public class PythagoreanCalculator : IDistanceCalculator
    {
        public PythagoreanCalculator()
        {

        }

        public double Calculate(Coordinate source, Coordinate dest)
        {
            return Math.Sqrt((Math.Pow((dest.Northing - source.Northing), 2.0) + Math.Pow((dest.Easting - source.Easting), 2.0)));
        }

    }
		
		
}
