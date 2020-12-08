using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;
using Xunit;

namespace TestLogic
{
    /// <summary>
    /// Test pour la classe Module
    /// </summary>
    public class TestModule
    {
        /// <summary>
        /// Test du computeAverage
        /// Doit calculer uniquement les examens de son module
        /// et renvoyer la moyenne
        /// </summary>
        [Fact]
        public void TestComputeAverage()
        {
            List<Exam> exams = new List<Exam>();

            Module module = new Module();
            module.Name = "Test";
            module.Coef = 2f;

            AvgScore emptyAverage = module.ComputeAverage(exams.ToArray());

            Exam exam0 = new Exam();
            exam0.Coef = 2f;
            exam0.Score = 12f;
            exam0.Module = module;

            Exam exam1 = new Exam();
            exam1.Coef = 2f;
            exam1.Score = 16f;
            exam1.Module = module;

            Exam exam2 = new Exam();
            exam2.Coef = 1f;
            exam2.Score = 18f;
            exam2.Module = module;

            exams.Add(exam0);
            exams.Add(exam1);
            exams.Add(exam2);

            float average = 2f * 12f + 2f * 16f + 18f;
            average /= 5f;

            AvgScore computedAverage = module.ComputeAverage(exams.ToArray());

            Assert.NotNull(computedAverage);
            Assert.Equal(average, computedAverage.Average);
            Assert.Null(emptyAverage);
        }
    }
}
