using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestLogic
{
    public class TestAvgScore
    {
        /// <summary>
        /// Test du ToString() de AvgScore
        /// </summary>
        [Fact]
        public void TestToString()
        {
            Module module = new Module();
            module.Name = "Maths";

            AvgScore avg = new AvgScore(14f, module);

            Assert.Equal("Maths Moyenne : 14",avg.ToString());
        }
    }
}
