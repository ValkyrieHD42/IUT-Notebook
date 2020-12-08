using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe mère d'un élément pédagogique
    /// </summary>
    [DataContract]
    public class PedagogicalElement
    {
        [DataMember] private String name;
        public String Name {
            get => name;
            set {
                if (value == "" || value == null) throw new Exception("The name must not be empty");
                name = value;
            }
        }

        [DataMember] private float coef;
        public float Coef
        {
            get => coef;
            set
            {
                if (value <= 0) throw new Exception("The coef must be >0");
                coef = value;
            }
        }
        public override String ToString()
        {
            return this.Name + " (" + this.Coef + ")";
        }

        /// <summary>
        /// Fonction Equal pour les test du storage
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is PedagogicalElement element &&
                   name == element.name &&
                   Name == element.Name &&
                   coef == element.coef &&
                   Coef == element.Coef;
        }
    }
}
