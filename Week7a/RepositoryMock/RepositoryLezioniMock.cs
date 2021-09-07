using System.Collections.Generic;

namespace Week7a
{
    internal class RepositoryLezioniMock : IRepositoryLezioni
    {


        public static List<Lezione> Lezioni = new List<Lezione>();
        
        public RepositoryLezioniMock()
        {
        }

        public Lezione Add(Lezione item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Lezione item)
        {
            throw new System.NotImplementedException();
        }

        public List<Lezione> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Lezione GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Lezione Update(Lezione item)
        {
            throw new System.NotImplementedException();
        }
    }
}