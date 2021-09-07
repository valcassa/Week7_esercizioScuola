using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7a
{
    public interface IRepositoryStudenti : IRepository<Studente>
    {
        public Studente GetById(int id);
        Studente GetByCode(string codiceStudenteDaModificare);
    }
}
