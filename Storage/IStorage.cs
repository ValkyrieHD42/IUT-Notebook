using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Interface permettant d'implémenter différents type de storage
    /// </summary>
    public interface IStorage
    {
        NoteBook Load();

        void Save(NoteBook n);
    }
}
