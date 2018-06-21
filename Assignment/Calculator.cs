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

            int I = 0;

            float SumX = 0;
            
            float SumY = 0;
            
            float SumX2 = 0;
            
            float SumXY = 0;
            
            float D = 0;

            DataPoint RetPt;

            for (I = 0; I < data.Length; I++)
            {

                SumX += data[I].X;

                SumY += data[I].Y;

                SumX2 += data[I].X * data[I].X;

                SumXY += data[I].X * data[I].Y;
            }

            D = data.Length * SumX2 - SumX * SumX;

            RetPt.X = (SumY * SumX2 - SumXY * SumX) / D; //Intercept

            RetPt.Y = (data.Length * SumXY - SumY * SumX) / D; //Slope

            return RetPt;
        }
    
    }
}
