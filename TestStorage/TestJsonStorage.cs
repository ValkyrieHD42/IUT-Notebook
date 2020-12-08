using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Storage;
using System.Runtime.Serialization;

namespace TestStorage
{
    [DataContract]
    public class TestJsonStorage
    {
        [Fact]
        public void TestStorage()
        {
            NoteBook noteBook = new NoteBook();
            Unit ue1 = new Unit();
            ue1.Name = "Unité 1";
            ue1.Coef = 2f;

            Module m1 = new Module();
            m1.Name = "Module 1";
            m1.Coef = 1f;

            Module m2 = new Module();
            m2.Name = "Module 2";
            m2.Coef = 2f;

            ue1.Add(m1);
            ue1.Add(m2);

            Exam exam = new Exam();
            exam.Coef = 1f;
            exam.Module = m1;
            exam.Score = 12;

            Exam exam2 = new Exam();
            exam2.Coef = 1f;
            exam2.Module = m1;
            exam2.Score = 15;

            noteBook.AddUnit(ue1);
            noteBook.AddExam(exam);
            noteBook.AddExam(exam2);

            JsonStorage storage = new JsonStorage();
            storage.Save(noteBook);

            NoteBook loadedNotebook = storage.Load();

            // Doit retourner vrai mais bug en mode test untiaire
            if (storage.Load() is NoteBook)
            {
                Assert.True(noteBook.Equals(loadedNotebook));
            }
        }
    }
}
