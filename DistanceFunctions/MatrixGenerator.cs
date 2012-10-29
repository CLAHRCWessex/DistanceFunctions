using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace DistanceFunctions
{
    /// <summary>
    /// Generates a matrix of travel distances
    /// </summary>
    public class MatrixGenerator
    {
        protected IDistanceCalculator calculator;

        public MatrixGenerator(IDistanceCalculator calculator) 
        {
            this.calculator = calculator;
        }

        public DataTable GenerateMatrix(DataTable points, EastingNorthingColumnIndexer indexer)
        {

            DataTable matrix = CreateEmptyMatrix(points);

            for (int fromRow = 0; fromRow < points.Rows.Count; fromRow++)
            {
                
                Coordinate source = new Coordinate(Convert.ToInt32(points.Rows[fromRow][indexer.NorthingIndex]), 
                    Convert.ToInt32(points.Rows[fromRow][indexer.EastingIndex]));

                for (int toRow = 0; toRow < points.Rows.Count; toRow++)
                {
                   
                    Coordinate dest = new Coordinate(Convert.ToInt32(points.Rows[toRow][indexer.NorthingIndex]), 
                        Convert.ToInt32(points.Rows[toRow][indexer.EastingIndex]));

                    matrix.Rows[fromRow][toRow] = this.calculator.Calculate(source, dest);
                }
            }

            return matrix;
        }


        public DataTable CreateEmptyMatrix(DataTable points)
        {

            DataTable newMatrix = new DataTable();

            for (int col = 1; col <= points.Rows.Count; col++)
            {
                newMatrix.Columns.Add(col.ToString());
            }

            for (int row = 1; row <= points.Rows.Count; row++)
            {
                var toAdd = newMatrix.NewRow();
                newMatrix.Rows.Add(toAdd);
            }

            return newMatrix;
        }
    }


	
}
