using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace TestLogic
{
    /// <summary>
    /// Test pour la classe Unit
    /// </summary>
    public class TestUnit
    {
        [Fact]
        public void TestEquals()
        {
            Unit u = new Unit();
            u.Name = "UE1";
            u.Coef = 2f;

            Unit u2 = new Unit();
            u2.Name = "UE1";
            u2.Coef = 2f;

            Module m1 = new Module();
            m1.Name = "Module";
            m1.Coef = 2f;

            Module m2 = new Module();
            m2.Name = "Module 2";
            m2.Coef = 1f;

            u.Add(m1);
            u.Add(m2);
            u2.Add(m1);
            u2.Add(m2);

            Assert.True(u.Equals(u2));

            u2.Remove(m2);

            Assert.False(u.Equals(u2));
        }

        /// <summary>
        /// Test du ListModules, ne doit pas être null lors de sa création
        /// </summary>
        [Fact]
        public void TestListModulesNotNull()
        {
            Unit u = new Unit();
            Assert.NotNull(u.ListModules());
        }

        /// <summary>
        /// Création de ListModules, doit être vide à l'initialisation
        /// </summary>
        [Fact]
        public void TestListModulesEmpty()
        {
            Unit u = new Unit();
            Assert.Empty(u.ListModules());
        }

        /// <summary>
        /// Test de l'ajout de module
        /// </summary>
        [Fact]
        public void TestAdd()
        {
            Unit u = new Unit();
            Module m = new Module();
            u.Add(m);
            Assert.NotEmpty(u.ListModules());
        }

        /// <summary>
        /// Test de suppression de module
        /// </summary>
        [Fact]
        public void TestRemove()
        {
            Unit u = new Unit();
            Module m = new Module();
            u.Add(m);
            u.Remove(m);
            Assert.Empty(u.ListModules());
        }

        /// <summary>
        /// Test de compute Average
        /// Doit calculer les moyennes de ses modules
        /// et renvoi une liste avec la moyenne de l'unité et ses modules
        /// </summary>
        [Fact]
        public void TestComputeAverage()
        {
            // Unité

            Unit ue1 = new Unit();
            ue1.Name = "UE 1";
            ue1.Coef = 1f;

            // Module

            Module m1 = new Module();
            m1.Name = "Maths";
            m1.Coef = 1f;

            Module m2 = new Module();
            m2.Name = "Expression";
            m2.Coef = 1f;

            ue1.Add(m1);
            ue1.Add(m2);

            // Exam

            Exam ex1 = new Exam();
            ex1.Coef = 2f;
            ex1.Score = 11f;
            ex1.Module = m1;

            Exam ex2 = new Exam();
            ex2.Coef = 1f;
            ex2.Score = 8f;
            ex2.Module = m1;

            Exam ex3 = new Exam();
            ex3.Coef = 1f;
            ex3.Score = 19f;
            ex3.Module = m2;

            Exam ex4 = new Exam();
            ex4.Coef = 1f;
            ex4.Score = 13f;
            ex4.Module = m2;

            // Moyenne

            List<Exam> exams = new List<Exam>();
            exams.Add(ex1);
            exams.Add(ex2);
            exams.Add(ex3);
            exams.Add(ex4);

            // Average

            AvgScore[] avgComputed = ue1.ComputeAverages(exams.ToArray());

            List<AvgScore> avgScores = new List<AvgScore>();
            AvgScore avg1 = new AvgScore(10, m1);
            AvgScore avg2 = new AvgScore(16, m2);
            AvgScore ueAvg = new AvgScore(13, ue1);

            avgScores.Add(ueAvg);
            avgScores.Add(avg1);
            avgScores.Add(avg2);

            Assert.Equal(ueAvg.Average, avgComputed[0].Average);
            Assert.Equal(avgScores.ToArray().ToString(), avgComputed.ToString());

        }
    }
}
