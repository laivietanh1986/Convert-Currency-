using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void GetFitLine()
        {
            var data = new List<DataPoint>()
            {
                new DataPoint{X=43,Y=99},
                new DataPoint{X=21,Y=65},
                new DataPoint{X=25,Y=79},
                new DataPoint{X=42,Y=75},
                new DataPoint{X=57,Y=87},
                new DataPoint{X=59,Y=81},
                
            };
            var result = Calculator.LinearRegression(data.ToArray());
            var esp1 = Math.Abs(result.X - 65.1416);
            var esp2 = Math.Abs(result.Y - 0.385225);

            Assert.IsTrue(esp1>=0);
            Assert.IsTrue(esp1<=0.1);
            Assert.IsTrue(esp2>=0);
            Assert.IsTrue(esp2<=0.1);

        }
        [TestMethod]
        public void GetFitLine2()
        {
            var data = new List<DataPoint>()
            {
                new DataPoint{X=10,Y=15},
                new DataPoint{X=20,Y=20},
                new DataPoint{X=30,Y=25},
                

            };
            var result = Calculator.LinearRegression(data.ToArray());
            var esp1 = Math.Abs(result.X -10);
            var esp2 = Math.Abs(result.Y - 0.5);

            Assert.IsTrue(esp1 >= 0);
            Assert.IsTrue(esp1 <= 0.1);
            Assert.IsTrue(esp2 >= 0);
            Assert.IsTrue(esp2 <= 0.1);



        }
    }
}
