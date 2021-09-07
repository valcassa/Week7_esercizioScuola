using System.Collections.Generic;

namespace Week7a
{
    internal class RepositoryStudentiMock : IRepositoryStudenti
    {

        public static List<Studente> Studenti = new List<Studente>()
        {
            new Studente{},
            new Studente{}
        };
        public RepositoryStudentiMock()
        {
        }

        public Studente Add(Studente item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Studente item)
        {
            throw new System.NotImplementedException();
        }

        public List<Studente> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Studente GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Studente Update(Studente item)
        {
            throw new System.NotImplementedException();
        }
    }
}