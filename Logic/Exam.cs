using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Classe d'un examen
    /// </summary>
    [DataContract]
    public class Exam
    {
        [DataMember] private Module module;
        [DataMember] private String teacher;
        [DataMember] private DateTime dateExam = DateTime.Now;
        [DataMember] private float coef = 1f;
        [DataMember] private Boolean isAbsent = true;
        [DataMember] private float score = 0;
        public Module Module
        {
            get { return module; }
            set { 
                if(value == null) throw new Exception("Le module ne doit pas être vide");
                this.module = value; 
            }
        }
        public String Teacher
        {
            get { return teacher; }
            set { this.teacher = value; }
        }

        public DateTime DateExam
        {
            get { return this.dateExam;  }
            set { this.dateExam = value; }
        }

        public float Coef
        {
            get { return this.coef; }
            set { 
                if(value<=0) throw new Exception("Le coef doit être supérieur à 0");
                this.coef = value; 
            }
        }

        public Boolean IsAbsent
        {
            get { return this.isAbsent; }
            set { this.isAbsent = value; }
        }

        public float Score
        {
            get { return this.score; }
            set { 
                if(value<0 || value>20) throw new Exception("La note doit être entre 0 et 20");
                this.score = value; 
            }
        }

        /// <summary>
        /// Fonction Equals qui compare 2 objets Exam
        /// Si la date est à une seconde pret alors ce sont les même
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   module.Equals(exam.module) &&
                   teacher == exam.teacher &&
                   Math.Abs((dateExam - exam.dateExam).TotalSeconds) <= 1 &&
                   coef == exam.coef &&
                   isAbsent == exam.isAbsent &&
                   score == exam.score &&
                   Module.Equals(exam.Module) &&
                   Teacher == exam.Teacher &&
                   Math.Abs((DateExam - exam.DateExam).TotalSeconds) <= 1 &&
                   Coef == exam.Coef &&
                   IsAbsent == exam.IsAbsent &&
                   Score == exam.Score;
        }
    }
}
