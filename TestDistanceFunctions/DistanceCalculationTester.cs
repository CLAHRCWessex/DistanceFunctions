/*
 * Created by SharpDevelop.
 * User: Tom
 * Date: 21/08/2012
 * Time: 19:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;
using DistanceFunctions;
using System.Data;
using System.Drawing;

namespace TestDistanceFunctions
{
	/// <summary>
	/// Tests all distance calculation functionality
	/// </summary>
	[TestFixture]
	public class DistanceCalculationTester
	{
		
		/// <summary>
		/// Answer is 50,000
		/// </summary>
		[Test]
		public void TestPythagCalc(){
			
			//Point source = new Point(10000,40000);
			//Point dest = new Point(40000, 80000);
			//double answer = 50000;
			
			//var calc = new PythagoreanCalculator();
			//Assert.AreEqual(calc.Calculate(source, dest), answer);
			
		}
		
		
		public void TestMatrixCalculation(){
			var xCol = new List<double>(){
				10000, 40000, 50798, 11170, 48533
			};
			
			var yCol = new List<double>(){
				40000, 80000, 10058, 55923, 33924	
			};
			
			var variables = new Dictionary<string, List<double>>();
			variables.Add("x", xCol);
			variables.Add("y", yCol);
		}
	}
}