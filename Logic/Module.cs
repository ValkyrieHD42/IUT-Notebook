using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe d'un module
    /// </summary>
    public class Module : PedagogicalElement
    {
        /// <summary>
        /// Calcul de la moyenne du module
        /// </summary>
        /// <param name="exams">Prends une liste d'examen et prends en compte seulement les 
        /// examens ayant eu lieu dans le module actuel</param>
        /// <returns>Renvoi une moyenne</returns>
        public AvgScore ComputeAverage(Exam[] exams)
        {
            if (exams.Length>0)
            {
                float somme = 0;
                float total = 0;
                foreach(Exam e in exams)
                {
                    if(e.Module.Equals(this))
                    {
                        somme += e.Score * e.Coef;
                        total += e.Coef;
                    }
                }
                float average = 0f;
                if (somme == 0 && total == 0)
                {
                    return null;
                } else
                {
                    average = somme / total;
                }
                AvgScore avgScore = new AvgScore(average, this);
                return avgScore;
            }
            return null;
        }
    }
}
