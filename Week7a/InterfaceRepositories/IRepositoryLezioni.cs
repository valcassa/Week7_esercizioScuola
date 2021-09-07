using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7a
{
    public interface IRepositoryLezioni : IRepository<Lezione>
    {
        public Lezione GetById(int id);
        object GetById(string codice);
        void Delete(object lezione);
        void Update(object lezione);
    }
}
