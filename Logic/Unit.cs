using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe d'une unité, contient différents modules
    /// </summary>
    [DataContract]
    public class Unit : PedagogicalElement
    {
        [DataMember] private List<Module> modules = new List<Module>();

        /// <summary>
        /// Liste des modules
        /// </summary>
        /// <returns>Renvoi un tableau des modules de l'unité</returns>
        public Module[] ListModules()
        {
            return modules.ToArray();
        }

        /// <summary>
        /// Ajoute un module à l'unité
        /// </summary>
        /// <param name="m">Prends un module</param>
        public void Add(Module m)
        {
            this.modules.Add(m);
        }

        /// <summary>
        /// Supprime un module
        /// </summary>
        /// <param name="m">Prends un module</param>
        public void Remove(Module m)
        {
            this.modules.Remove(m);
        }

        /// <summary>
        /// Calcul de moyenne d'une Unité :
        /// Chaque module de l'unité est calculé, puis la moyenne de l'unité.
        /// </summary>
        /// <param name="exams">Liste d'examen</param>
        /// <returns>Renvoi un tableau, en première place la moyenne de l'unité puis les modules</returns>
        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            List<AvgScore> moduleAvgList = new List<AvgScore>();
            float moduleSum = 0;
            float moduleCoef = 0;
            foreach (Module m in this.modules)
            {
                AvgScore moyModule = m.ComputeAverage(exams);
                if (moyModule != null)
                {
                    moduleAvgList.Add(moyModule);
                    moduleSum += (float) moyModule.Average * m.Coef;
                    moduleCoef += (float) m.Coef;
                }
            }
            AvgScore averageUnits = new AvgScore(moduleSum / moduleCoef, this);
            moduleAvgList.Insert(0, averageUnits);
            return moduleAvgList.ToArray();
        }

        /// <summary>
        /// Fonction qui vérifie si deux objets de type Unit sont bien les même
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Vrais si ce sont les même</returns>
        public override bool Equals(object obj)
        {
            bool res = true;
            if(obj is Unit u && modules.Count == u.modules.Count)
            {
                    for (int i = 0; i < modules.Count; i++)
                    {
                        if (!modules[i].Equals(u.modules[i]))
                        {
                            res = false;
                        }
                    }
                    res = res && Name == u.Name && Coef == u.Coef;
            } else
            {
                res = false;
            }

            return res;
        }
    }
}
