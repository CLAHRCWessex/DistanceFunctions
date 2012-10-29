using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DistanceFunctions
{
    public interface IDistanceCalculator
    {
        double Calculate(Coordinate source, Coordinate dest);
    }
}
