using System.Collections.Generic;

namespace Week7a
{
    public class RepositoryCorsiMock : IRepositoryCorsi 
    {
        //Dati finti
        public static List<Corso> Corsi = new List<Corso>()
        {
            new Corso{CorsoCodice="C-01", Nome="Pre-Academy I", Descrizione="Corso base c# livello1"},
            new Corso{CorsoCodice="C-02", Nome="Academy I", Descrizione="Corso base c# livello2"}
        };

        object IRepositoryCorsi.CorsiRepo => throw new System.NotImplementedException();

        public Corso Add(Corso item)
        {
            Corsi.Add(item);
            return item;
        }

        public void Add(Docente nuovoDocente)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Corso item)
        {
            throw new System.NotImplementedException();
        }

        public List<Corso> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Corso GetByCode(string code)
            { return Corsi.Find(c => c.CorsoCodice == code); }

        public Corso Update(Corso item)
        {
            throw new System.NotImplementedException();
        }

        Corso IRepository<Corso>.Add(Corso item)
        {
            throw new System.NotImplementedException();
        }

        bool IRepository<Corso>.Delete(Corso item)
        {
            throw new System.NotImplementedException();
        }

        List<Corso> IRepository<Corso>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        Corso IRepositoryCorsi.GetByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        Corso IRepository<Corso>.Update(Corso item)
        {
            throw new System.NotImplementedException();
        }
    }
}