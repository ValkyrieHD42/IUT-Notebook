using Logic;
using Storage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic.NoteBook noteBook;
        private IStorage storage;
        public MainWindow()
        {
            InitializeComponent();
            this.storage = new JsonStorage();
            this.noteBook = storage.Load();
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(this.noteBook, this.storage);
            second.Show();
        }

        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            Exam exam = new Exam();
            EditExamWindow exams = new EditExamWindow(this.noteBook,exam);
            if (exams.ShowDialog() == true)
            {
                noteBook.AddExam(exam);
                storage.Save(noteBook);
            }
        }

        private void GoToMoyenne(object sender, RoutedEventArgs e)
        {
            ListExamWindow moyenne = new ListExamWindow(this.noteBook,this.storage);
            moyenne.Show();
        }

    }
}
