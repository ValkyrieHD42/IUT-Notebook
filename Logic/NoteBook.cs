using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe centrale gérant le notebook de notre application
    /// </summary>
    [DataContract]
    public class NoteBook
    {
        [DataMember] private List<Exam> exams = new List<Exam>();
        [DataMember] private List<Unit> units = new List<Unit>();
        [DataMember] private PedagogicalElement globalScore = new PedagogicalElement() { Coef = 1, Name = "Général" };

        public List<Exam> Exam
        {
            get { return this.exams;  }
        }

        /// <summary>
        /// Permet de récupérer les unités sous forme de tableau
        /// </summary>
        /// <returns>Tableau d'Unit</returns>
        public Unit[] ListUnits()
        {
            return units.ToArray();
        }

        /// <summary>
        /// Enlève une unité
        /// </summary>
        /// <param name="u">Prends une unité</param>
        public void RemoveUnit(Unit u)
        {
            units.Remove(u);
        }

        /// <summary>
        /// Ajoute une unité
        /// </summary>
        /// <param name="u">Prends une unité</param>
        public void AddUnit(Unit u)
        {
            foreach (Unit element in units)
            {
                if (element.Name == u.Name)
                {
                    throw new Exception("Le nom existe déjà");
                }
            }
            units.Add(u);
        }

        /// <summary>
        /// Fournit un tableau listant tous les modules existants
        /// </summary>
        /// <returns>Tableau de module</returns>
        public Module[] ListModules()
        {
            List<Module> modules = new List<Module>();
            foreach (Unit unit in units)
            {
                foreach(Module module in unit.ListModules())
                {
                    modules.Add(module);
                }
            }
            return modules.ToArray();
        }

        /// <summary>
        /// Ajoute un examen à la liste
        /// </summary>
        /// <param name="exam">Examen</param>
        public void AddExam(Exam exam)
        {
            exams.Add(exam);    
        }

        public void removeExam(Exam ex)
        {
            exams.Remove(ex);
        }

        public Exam[] ListExams()
        {
            return exams.ToArray();
        }

        /// <summary>
        /// Calcul des moyennes :
        /// Calcul des unités puis des modules
        /// </summary>
        /// <returns>Renvoi un tableau de moyenne, l'UE puis la moyenne de ses modules 
        /// et enfin la moyenne générale</returns>
        public AvgScore[] ComputeScores()
        {
            List<AvgScore> avgRes = new List<AvgScore>();
            float sum = 0;
            float coefsum = 0;
            foreach(Unit u in this.ListUnits())
            {
                AvgScore[] avgUnit = u.ComputeAverages(ListExams());
                if(avgUnit[0] != null)
                {
                    if (avgUnit.Length > 1)
                    {
                        sum += avgUnit[0].Average*u.Coef;
                        coefsum += u.Coef;
                    }
                }

                foreach (AvgScore avg in u.ComputeAverages(ListExams()))
                {
                    avgRes.Add(avg);
                }
            }
            AvgScore general = new AvgScore(sum / coefsum, globalScore);
            avgRes.Insert(0,general);
            return avgRes.ToArray();
        }

        /// <summary>
        /// Fonction qui vérifie si deux objets de type NoteBook sont bien les même
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Vrai si ce sont les même</returns>
        public override bool Equals(object obj)
        {
            bool res = true;
            if(obj is NoteBook n && (units.Count == n.units.Count) && (exams.Count == n.exams.Count))
            {
                for(int i = 0; i<units.Count;i++)
                {
                    if(!units[i].Equals(n.units[i])) {
                        res = false;
                    }
                }

                for (int i = 0; i < exams.Count; i++)
                {
                    if (!exams[i].Equals(n.exams[i]))
                    {
                        res = false;
                    }
                }
                if(!globalScore.Equals(n.globalScore))
                {
                    res = false;
                }
            } else
            {
                res = false;
            }
            return res;
        }
    }
}
