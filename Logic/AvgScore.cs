using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe d'une moyenne
    /// </summary>
    public class AvgScore
    {
        private float average;
        private String elementName;

        public float Average
        {
            get { return this.average; }
            set { this.average = value; }
        }

        public String ElementName
        {
            get { return this.elementName; }
        }

        public AvgScore(float av, PedagogicalElement pe)
        {
            this.average = av;
            this.elementName = pe.Name;
        }

        public String ToString()
        {
            return this.ElementName + " Moyenne : " + this.Average;
        }
    }
}
