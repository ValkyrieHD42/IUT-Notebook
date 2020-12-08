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
using Storage;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        private Exam exam;
        private Logic.NoteBook noteBook;
        public EditExamWindow(Logic.NoteBook nb, Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            this.noteBook = nb;
            scoreBox.Text = exam.Score.ToString();
            teacherBox.Text = exam.Teacher;
            isAbsentBox.IsChecked = exam.IsAbsent;
            moduleBox.SelectedItem = exam.Module;
            dateBox.SelectedDate = exam.DateExam;

            Module[] m = noteBook.ListModules();

            foreach(Module module in m)
            {
                DrawModules(module);
            }
        }

        /// <summary>
        /// Affiche les modules en l'ajoutant dans la liste déroulante
        /// </summary>
        /// <param name="m"></param>
        private void DrawModules(Module m)
        {
            moduleBox.Items.Add(m);
        }

        /// <summary>
        /// Créé l'examen avec les valeur rentrée et l'ajoute au notebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            try {

                // Création de l'examen
                exam.DateExam = dateBox.DisplayDate;
                exam.IsAbsent = (bool)isAbsentBox.IsChecked;
                exam.Module = (Module)moduleBox.SelectedItem;
                exam.Score = (float)Convert.ToDouble(scoreBox.Text);
                exam.Teacher = teacherBox.Text;

                DialogResult = true;
            } 
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Annule l'action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Désactive la note et la met à 0 quand la case Absent est coché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onAbsentChecked(object sender, RoutedEventArgs e)
        {
            scoreBox.IsEnabled = false;
            scoreBox.Text = "0";
        }

        /// <summary>
        /// Réactive la note quand Asbent est décoché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAbsentUnchecked(object sender, RoutedEventArgs e)
        {
            scoreBox.IsEnabled = true;
        }
    }
}
