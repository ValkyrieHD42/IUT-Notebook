using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestLogic
{
    /// <summary>
    /// Test pour la classe NoteBook
    /// </summary>
    public class TestNoteBook
    {
        [Fact]
        public void TestEquals()
        {
            NoteBook notebook = new NoteBook();
            NoteBook notebook2 = new NoteBook();

            Unit unit = new Unit();
            unit.Name = "Unit1";
            Module m1 = new Module();
            m1.Name = "Réseau";
            m1.Coef = 1f;

            Module m2 = new Module();
            m2.Name = "Conception";
            m2.Coef = 1f;

            unit.Add(m1);

            Unit unit2 = new Unit();
            unit2.Add(m2);

            Exam exam1 = new Exam();
            exam1.Coef = 2f;
            exam1.Module = m1;
            exam1.Score = 15;

            Exam exam2 = new Exam();
            exam2.Coef = 2f;
            exam2.Module = m1;
            exam2.Score = 15;

            notebook.AddUnit(unit);
            notebook.AddUnit(unit2);
            notebook.AddExam(exam1);
            notebook.AddExam(exam2);

            notebook2.AddUnit(unit);
            notebook2.AddUnit(unit2);
            notebook2.AddExam(exam1);
            notebook2.AddExam(exam2);

            Assert.True(notebook.Equals(notebook2));
        }
        /// <summary>
        /// Test ListUnit
        /// Doit être vide à l'initialisation
        /// </summary>
        [Fact]
        public void TestListUnitsEmpty()
        {
            NoteBook noteBook = new NoteBook();
            Assert.Empty(noteBook.ListUnits());
        }
        
        /// <summary>
        /// Test de ListUnit
        /// Ne doit pas être null
        /// </summary>
        [Fact]
        public void TestListUnitsNotNull()
        {
            NoteBook noteBook = new NoteBook();
            Assert.NotNull(noteBook.ListUnits());
        }

        /// <summary>
        /// Test de AddUnit
        /// Doit créer et ajouter une unité
        /// </summary>
        [Fact]
        public void TestAddUnit()
        {
            NoteBook notebook = new NoteBook();
            Unit unit = new Unit();
            unit.Name = "Conception";
            unit.Coef = 2;
            notebook.AddUnit(unit);
            Assert.Equal(notebook.ListUnits()[0], unit);
        }

        /// <summary>
        /// Test de AddUnit
        /// </summary>
        [Fact]
        public void TestAddUnitSingle()
        {
            NoteBook notebook = new NoteBook();
            Unit unit = new Unit();
            unit.Name = "Conception";
            unit.Coef = 2;
            notebook.AddUnit(unit);
            Assert.Single(notebook.ListUnits());
        }

        /// <summary>
        /// Test des exceptions AddUnit
        /// Ne peut ajouter les même
        /// </summary>
        [Fact]
        public void TestAddUnitSame()
        {
            NoteBook notebook = new NoteBook();
            Unit unit = new Unit();
            unit.Name = "Conception";
            unit.Coef = 2;
            notebook.AddUnit(unit);
            Assert.Throws<Exception>(() => {
                notebook.AddUnit(unit);
            });
        }

        [Fact]
        public void testRemoveExam()
        {
            NoteBook n = new NoteBook();
            Exam ex = new Exam();
            ex.Coef = 2;
            Module m = new Module();
            m.Name = "Concept";
            m.Coef = 3;
            Unit u = new Unit();
            u.Name = "Main";
            u.Coef = 1;
            u.Add(m);
            ex.Module = m;

            n.AddExam(ex);

            n.removeExam(ex);

            Assert.Empty(n.ListExams());
        }

        /// <summary>
        /// Test de removeUnit
        /// </summary>
        [Fact]
        public void testRemoveUnit()
        {
            NoteBook notebook = new NoteBook();
            Unit unit = new Unit();
            unit.Name = "Droit";

            notebook.AddUnit(unit);
            notebook.RemoveUnit(unit);
            Assert.Empty(notebook.ListUnits());
        }

        /// <summary>
        /// Test de ListModules
        /// </summary>
        [Fact]
        public void TestListModules()
        {
            NoteBook notebook = new NoteBook();
            Unit unit = new Unit();
            unit.Name = "Unit1";
            Module module = new Module();
            module.Name = "Réseau";
            module.Coef = 1f;

            Module module2 = new Module();
            module2.Name = "Conception";
            module2.Coef = 1f;

            unit.Add(module);

            Unit unit2 = new Unit();
            unit2.Add(module);

            notebook.AddUnit(unit);
            notebook.AddUnit(unit2);

            Assert.Equal(2, notebook.ListModules().Length);

        }

        /// <summary>
        /// Test de AddExam
        /// Ne doit pas être null
        /// </summary>
        [Fact]
        public void TestAddExamNotNull()
        {
            NoteBook notebook = new NoteBook();
            Assert.NotNull(notebook.Exam);
        }

        /// <summary>
        /// Test de AddExam
        /// ne doit pas être Empty
        /// </summary>
        [Fact]
        public void TestAddExamEmpty()
        {
            Exam exam = new Exam();
            NoteBook notebook = new NoteBook();

            notebook.AddExam(exam);
            Assert.NotEmpty(notebook.Exam);
        }

        /// <summary>
        /// Test de ListExam
        /// </summary>
        [Fact]
        public void TestListExams()
        {
            Exam exam = new Exam();
            NoteBook notebook = new NoteBook();

            notebook.AddExam(exam);
            List<Exam> listExam = new List<Exam>();
            listExam.Add(exam);

            Assert.Equal(listExam.ToArray(), notebook.ListExams());
        }

        /// <summary>
        /// Test du ComputeScore(), Doit calculer toutes les moyennes
        /// La moyenne général se situe en index 0
        /// </summary>
        [Fact]
        public void TestComputeScore()
        {
            Unit ue1 = new Unit();
            ue1.Name = "UE 1";
            ue1.Coef = 1f;

            Unit ue2 = new Unit();
            ue2.Name = "UE 2";
            ue2.Coef = 1f;

            // Module

            Module m1 = new Module();
            m1.Name = "Maths";
            m1.Coef = 1f;

            Module m2 = new Module();
            m2.Name = "Expression";
            m2.Coef = 1f;

            Module m3 = new Module();
            m3.Name = "Programmation";
            m3.Coef = 1f;

            Module m4 = new Module();
            m4.Name = "Système";
            m4.Coef = 1f;

            ue1.Add(m1);
            ue1.Add(m2);

            ue2.Add(m3);
            ue2.Add(m4);

            // Exam
            // UE1
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
            //UE2
            Exam ex5 = new Exam();
            ex5.Coef = 2f;
            ex5.Score = 11f;
            ex5.Module = m3;

            Exam ex6 = new Exam();
            ex6.Coef = 1f;
            ex6.Score = 8f;
            ex6.Module = m3;

            Exam ex7 = new Exam();
            ex7.Coef = 1f;
            ex7.Score = 19f;
            ex7.Module = m4;

            Exam ex8 = new Exam();
            ex8.Coef = 1f;
            ex8.Score = 13f;
            ex8.Module = m4;

            // Notebook

            NoteBook nb = new NoteBook();

            nb.AddUnit(ue1);
            nb.AddUnit(ue2);

            nb.AddExam(ex1);
            nb.AddExam(ex2);
            nb.AddExam(ex3);
            nb.AddExam(ex4);
            nb.AddExam(ex5);
            nb.AddExam(ex6);
            nb.AddExam(ex7);
            nb.AddExam(ex8);


            // Moyenne

            AvgScore avgM1 = new AvgScore(10, m1);
            AvgScore avgM2 = new AvgScore(16, m2);
            AvgScore ue1Avg = new AvgScore(13, ue1);

            AvgScore avgM3 = new AvgScore(10, m3);
            AvgScore avgM4 = new AvgScore(16, m4);
            AvgScore ue2Avg = new AvgScore(13, ue2);

            AvgScore[] allAvg = nb.ComputeScores();

            // Test de la moyenne générale
            Assert.Equal(13f, allAvg[0].Average);

            // Test de la moyenne UE1
            Assert.Equal(ue1Avg.Average, allAvg[1].Average);

            // Test de la moyenne UE2
            Assert.Equal(ue2Avg.Average, allAvg[4].Average);

        }
    }
}
