using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour ListExamWindow.xaml
    /// </summary>
    public partial class ListExamWindow : Window
    {
        Logic.NoteBook noteBook;
        private IStorage storage;
        public ListExamWindow(Logic.NoteBook n, IStorage store)
        {
            this.noteBook = n;
            this.storage = store;
            InitializeComponent();
            DrawExams();
        }

        /// <summary>
        /// Affiche les examens
        /// </summary>
        private void DrawExams()
        {
            exams.Items.Clear();
            foreach (Exam e in noteBook.ListExams())
            {
                exams.Items.Add(e);
            }

            scores.Items.Clear();
            foreach (AvgScore avg in noteBook.ComputeScores())
            {
                scores.Items.Add(avg.ToString());
            }
        }

        private void exams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
        }

        private void editExam(object sender, MouseButtonEventArgs e)
        {
            if (exams.SelectedItem is Exam exam)
            {
                EditExamWindow editExam = new EditExamWindow(noteBook, exam);
                if (editExam.ShowDialog() == true)
                {
                    storage.Save(noteBook);
                    DrawExams();
                }
            }
        }

        private void removeExam(object sender, RoutedEventArgs e)
        {
            if(exams.SelectedItem is Exam exam)
            {
                MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer cet examen ?", "Attention", MessageBoxButton.YesNo);
                if (r == MessageBoxResult.Yes)
                {
                    noteBook.removeExam(exam);
                    storage.Save(noteBook);
                    DrawExams();
                }
            }
        }
    }
}
