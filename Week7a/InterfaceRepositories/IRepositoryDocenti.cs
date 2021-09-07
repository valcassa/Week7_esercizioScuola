using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7a

   {
    public interface IRepositoryDocenti : IRepository<Docente>
    {
        public Docente GetById(int id);
        Docente GetByCode(object docenteID);
        object GetById(object idDocenteDaEliminare);
        void Delete(object docente);
        //public Docente GetByEmail(string email);
    }
}
