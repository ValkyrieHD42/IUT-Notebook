using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestLogic
{
    /// <summary>
    /// Test pour la classe Exam
    /// </summary>
    public class TestExam
    {
        /// <summary>
        /// Test du module
        /// </summary>
        [Fact]
        public void TestModule()
        {
            Exam exam = new Exam();
            Module module = new Module();
            exam.Module = module;

            Assert.Equal(module, exam.Module);
        }

        /// <summary>
        /// Test des exceptions du module
        /// </summary>
        [Fact]
        public void TestModuleException()
        {
            Exam exam = new Exam();

            Assert.Throws<Exception>(() => {
                exam.Module = null;
            });
        }

        /// <summary>
        /// Test de la variable Teacher
        /// </summary>
        [Fact]
        public void TestTeacher()
        {
            Exam exam = new Exam();
            exam.Teacher = "Patrice";
            Assert.Equal("Patrice", exam.Teacher);
        }

        /// <summary>
        /// Test de la DateExam
        /// </summary>
        [Fact]
        public void TestDateExam()
        {
            Exam exam = new Exam();
            DateTime date = DateTime.Today;
            exam.DateExam = date;
            Assert.Equal(DateTime.Today, exam.DateExam);
        }

        /// <summary>
        /// Test du coef
        /// </summary>
        [Fact]
        public void TestCoef()
        {
            Exam exam = new Exam();
            exam.Coef = 2f;
            Assert.Equal(2f, exam.Coef);
        }

        /// <summary>
        /// Test des exceptions du coef
        /// </summary>
        [Fact]
        public void TestCoefValue()
        {
            Exam exam = new Exam();
            Assert.Throws<Exception>(() => {
                exam.Coef = -2f;
            });
        }

        /// <summary>
        /// Test isAbsent
        /// </summary>
        [Fact]
        public void TestIsAbsent()
        {
            Exam exam = new Exam();
            exam.IsAbsent = false;
            Assert.False(exam.IsAbsent);
        }

        /// <summary>
        /// Test isAbsent
        /// Par défaut doit être à True
        /// </summary>
        [Fact]
        public void TestDefaultIsAbsent()
        {
            Exam exam = new Exam();
            Assert.True(exam.IsAbsent);
        }

        /// <summary>
        /// Test de la note
        /// </summary>
        [Fact]
        public void TestScore()
        {
            Exam exam = new Exam();
            exam.Score = 19f;
            Assert.Equal(19f, exam.Score);
        }

        /// <summary>
        /// Test de la note
        /// Par défaut doit être à 0
        /// </summary>
        [Fact]
        public void TestDefaultScore()
        {
            Exam exam = new Exam();
            Assert.Equal(0, exam.Score);
        }

        /// <summary>
        /// Test des contraintes métier
        /// Score doit être entre 0 et 20
        /// </summary>
        [Fact]
        public void TestScoreValue()
        {
            Exam exam = new Exam();
            Assert.Throws<Exception>(() => {
                exam.Score = -2f;
            });
            Assert.Throws<Exception>(() => {
                exam.Score = 22f;
            });
        }

        /// <summary>
        /// Test de la fonction Equals
        /// Compare 2 objet Exam
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            Module m = new Module();
            m.Coef = 2f;
            m.Name = "Module";

            Exam exam = new Exam();
            exam.Score = 19f;
            exam.Coef = 2f;
            exam.Module = m;
            exam.Teacher = "Dupont";

            Exam exam2 = new Exam();
            exam2.Score = 19f;
            exam2.Coef = 2f;
            exam2.Module = m;
            exam2.Teacher = "Dupont";

            Assert.True(exam.Equals(exam2));

            exam2.DateExam = DateTime.Now.AddSeconds(2);

            Assert.False(exam.Equals(exam2));
        }
    }
}
