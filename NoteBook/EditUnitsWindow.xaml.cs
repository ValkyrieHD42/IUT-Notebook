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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Logic.NoteBook noteBook;
        private IStorage storage;
        public EditUnitsWindow(Logic.NoteBook noteBook, IStorage store)
        {
            InitializeComponent();
            this.noteBook = noteBook;
            this.storage = store;
            DrawUnits();
        }

        /// <summary>
        /// Met a jour / Affiche la liste des unités
        /// </summary>
        private void DrawUnits()
        {
            var list = noteBook.ListUnits();
            unitsList.Items.Clear();
            foreach (var item in list)
                unitsList.Items.Add(item);
        }

        /// <summary>
        /// Met a jour / Affiche la liste des modules
        /// </summary>
        private void DrawModules()
        {
            if (unitsList.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                moduleList.Items.Clear();
                foreach (Module m in list)
                    moduleList.Items.Add(m);
            }
        }
        /// <summary>
        /// Modifier un module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditModule(object sender, MouseButtonEventArgs e)
        {
            if (moduleList.SelectedItem is Module m)
            {
                EditElementWindow third = new EditElementWindow(m);
                if (third.ShowDialog() == true)
                {
                    storage.Save(noteBook);
                    DrawModules();
                }
            }
        }

        /// <summary>
        /// Modifier une unité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (unitsList.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    storage.Save(noteBook);
                    DrawUnits();
                }
            }
        }
        /// <summary>
        /// Ajoute une unité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    noteBook.AddUnit(newUnit);
                    storage.Save(noteBook);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Enlève une unité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (unitsList.SelectedItem is Unit unit)
                {
                    MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer l'unité '" + unit.Name + "' ?", "Oui", MessageBoxButton.YesNo);
                    if (r == MessageBoxResult.Yes)
                    {
                        noteBook.RemoveUnit(unit);
                        storage.Save(noteBook);
                        DrawUnits();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Sélection d'une unité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        /// <summary>
        /// Ajoute un module à l'unité sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (unitsList.SelectedItem is Unit unit)
                {
                    Module newModule = new Module();
                    EditElementWindow third = new EditElementWindow(newModule);
                    if (third.ShowDialog() == true)
                    {
                        unit.Add(newModule);
                        storage.Save(noteBook);
                        DrawModules();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (unitsList.SelectedItem is Unit unit)
                {
                    if(moduleList.SelectedItem is Module module)
                    {
                        MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer le module '" + module.Name + "' ?", "Attention", MessageBoxButton.YesNo);
                        if (r == MessageBoxResult.Yes)
                        {
                            unit.Remove(module);
                            storage.Save(noteBook);
                            DrawModules();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }

}