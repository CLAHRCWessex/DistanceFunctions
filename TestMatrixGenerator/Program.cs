using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDotNet;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using DistanceFunctions;
using System.Drawing;

using LocalSearch;

namespace TestMatrixGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
			DataTable tableOutput = null;
            var adapter = new ExcelWorkBookAdaptor();
            adapter.Open("C:/temp/Book1.xlsx");
            var xlRangeAdapter = new ExcelRangeToDataTableAdapter(adapter[0]);
            Point topLeft = new Point(1, 1);
            Point bottomRight = new Point(2, 20);

            try
            {
                tableOutput = xlRangeAdapter.ReadTable("A1:B21");
            }
            catch(Exception ex)
            {
            	Console.Write(ex.Message);
            }
            finally
            {
                adapter.CloseNoSave();
            }
            
            
            var calc = new PythagoreanCalculator();

            //var generator = new CentroidDistanceGenerator(calc);
            //CentroidTest(tableOutput, generator);

            MatrixTest(tableOutput, ref adapter, ref topLeft, calc);
            
            
        }

        private static void CentroidTest(DataTable tableOutput, CentroidDistanceGenerator generator)
        {
            var average = generator.AverageDistance(tableOutput, new EastingNorthingColumnIndexer(0, 1));
            Console.WriteLine(string.Format("Average distance from centroid: {0}", average));
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void MatrixTest(DataTable tableOutput, ref ExcelWorkBookAdaptor adapter, ref Point topLeft, PythagoreanCalculator calc)
        {
            var generator = new MatrixGenerator(calc);
            var matrix = generator.GenerateMatrix(tableOutput, new EastingNorthingColumnIndexer(0, 1));

            if (null != matrix)
            {
                adapter = new ExcelWorkBookAdaptor();
                adapter.NewBook();
                adapter.Show();
                var tableAdapter = new DataTableToExcelAdaptor(adapter[0], matrix);
                tableAdapter.Write(topLeft);


            }

            var len = new SimpleTourLengthCalculator(matrix);
            Console.WriteLine(len.TourLength(Enumerable.Range(0, 4).ToList<int>()).ToString());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
