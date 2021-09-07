using System.Collections.Generic;

namespace Week7a
{
    internal class RepositoryDocentiMock : IRepositoryDocenti 
    {

        public static List<Docente> Docenti = new List<Docente>()
        {
            new Docente{},
            new Docente{}
        };
        public RepositoryDocentiMock()
        {
        }

        public Docente Add(Docente item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Docente item)
        {
            throw new System.NotImplementedException();
        }

        public List<Docente> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Docente GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Docente Update(Docente item)
        {
            throw new System.NotImplementedException();
        }
    }
}