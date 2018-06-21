using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public static class Calculator
    {
        public static DataPoint LinearRegression(DataPoint[]data)
        {
            DataPoint RetPt;          
            
            var SumX = data.Sum(dt => dt.X);
            var SumY = data.Sum(dt => dt.Y);
            var SumX2 = data.Sum(dt => dt.X * dt.X);
            var SumXY = data.Sum(dt => dt.X * dt.Y);
            var D = (data.Length * SumX2) - (SumX * SumX);
            
            RetPt.X = ((SumY * SumX2) - (SumXY * SumX)) / D; //Intercept

            RetPt.Y = ((data.Length * SumXY) - (SumY * SumX)) / D; //Slope

            return RetPt;
        }
    
    }
}
