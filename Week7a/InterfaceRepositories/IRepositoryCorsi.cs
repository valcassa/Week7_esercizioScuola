using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7a
{
    public interface IRepositoryCorsi : IRepository<Corso>
    {
        object CorsiRepo { get; }

        public Corso GetByCode(string code);
        void Add(Docente nuovoDocente);
    }
}