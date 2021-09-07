using System;
using System.Collections.Generic;
using System.Linq;
using Week7a.BusinessLayer;

namespace Week7a
{
    internal class MainBusinessLayer : IBusinessLayer
    {
        public MainBusinessLayer(RepositoryCorsiMock repositoryCorsiMock, RepositoryDocentiMock repositoryDocentiMock, RepositoryLezioniMock repositoryLezioniMock, RepositoryStudentiMock repositoryStudentiMock)
        {
            RepositoryCorsiMock = repositoryCorsiMock;
            RepositoryDocentiMock = repositoryDocentiMock;
            RepositoryLezioniMock = repositoryLezioniMock;
            RepositoryStudentiMock = repositoryStudentiMock;
        }

        public RepositoryCorsiMock RepositoryCorsiMock { get; }
        public RepositoryDocentiMock RepositoryDocentiMock { get; }
        public RepositoryLezioniMock RepositoryLezioniMock { get; }
        public RepositoryStudentiMock RepositoryStudentiMock { get; }
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryDocenti docentiRepo;
        private readonly IRepositoryLezioni lezioniRepo;
        private readonly IRepositoryStudenti studentiRepo;

        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryDocenti docenti, IRepositoryLezioni lezioni, IRepositoryStudenti studenti)
        {

            corsiRepo = corsi;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            studentiRepo = studenti;
        }

        public List<Corso> GetAllCorsi()
        { return corsiRepo.GetAll(); }


        public string InserisciNuovoCorso(Corso newCorso)
        {
            Corso corsoEsistente = corsiRepo.GetByCode(newCorso.CorsoCodice);
            if (corsoEsistente != null) { return "Errore: Codice già presente"; }
            corsiRepo.Add(newCorso);
            return "Corso aggiunto";
        }
        public string EliminaCorso(string codiceCorsoDaEliminare)
        {
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaEliminare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            corsiRepo.Delete(corsoEsistente);
            return "Corso eliminato correttamente";

        }
        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {
            //controllo i dati
            Corso corsoEsistente = corsiRepo.GetByCode(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore: Codice errato.";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizione = nuovaDescrizione;
            corsiRepo.Update(corsoEsistente);
            return "Il corso è stato modificato con successo";
        }
         
        public List<Studente> GetStudents()
        {
            return studentiRepo.GetAll();
        }

        public List<Docente> GetDocents()
        {
            return docentiRepo.GetAll();
        }

        public string ModificaStudente(int NewIdStudente, string newMail)
        {
            var studente = studentiRepo.GetById(NewIdStudente);
            if (studente == null)
            {
                return "Id Studente errato o inesistente";
            }
            studentiRepo.Update(studente);
            return "Email Studente aggiornata correttamente";
        }


        public string EliminaStudente(string codiceStudenteDaEliminare)
        {
            Studente studenteEsistente = studentiRepo.GetByCode(codiceStudenteDaEliminare);
            if (studenteEsistente == null)
            {
                return "Errore: Codice errato.";
            }
             

            studentiRepo.Delete(studenteEsistente);
            return "Studente eliminato correttamente";

        }
         
        public object GetAllStudenti()
        {

            return studentiRepo.GetAll();
        }
         

        public List<Studente> GetStudentiByCodiceCorso(string codicecorso)
        {
            var corso = corsiRepo.GetByCode(codicecorso); 
            if(corso == null)
            {
                return null;
            }
            else
            {
                return studentiRepo.GetAll().Where(s => s.CorsoCodice == corso.CorsoCodice).ToList();

            }
        }

        public string InserisciNuovoDocente(Docente nuovoDocente)
        {

            Docente docenteEsistente = docentiRepo.GetAll().FirstOrDefault(d => d.Cognome == nuovoDocente.Cognome && d.Nome = nuovoDocente.Nome && d.Email = nuovoDocente.Email);
            docentiRepo.GetByCode(nuovoDocente.ID);
            if (docenteEsistente != null)
            {
                return "Errore: Codice docente già presente";
            }
            corsiRepo.Add(nuovoDocente);
            return "Docente aggiunto correttamente";
        }
         

        List<Studente> IBusinessLayer.GetAllStudenti()
        {
            throw new NotImplementedException();
        }

        public List<Docente> GetAllDocenti()
        {
            throw new NotImplementedException();
        }

        public string EliminaDocente(string codice)
        {

            var docente = docentiRepo.GetById(codice);
            if (docente == null)
            {
                return "Id Studente errato o inesistente";
            }
            docentiRepo.Delete(docente);
            return "Studente eliminato correttamente";
        }
   

    
        public string ModificaLezione(string codice, string codiceLezione, string nomeLezione, DateTime dataLezione, string durataLezione, string aulaLezione)
        {
            var lezione = lezioniRepo.GetById(codice);
            if (lezione == null)
            {
                return "La lezione non esiste";
            }
            lezioniRepo.Update(lezione);
            
        }

        public string EliminaLezione(string codice)
        {

        var lezione = lezioniRepo.GetById(codice);
        if (lezione == null)
        {
            return "Id Lezione errato o inesistente";
        }
        lezioniRepo.Delete(lezione);
        return "Lezione eliminata correttamente";
    }

    public string InserisciNuovoStudente(Studente nuovoStudente)
        {
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return "Codice corso errato";
            }
            studentiRepo.Add(nuovoStudente);
            return "Studente inserito";
        }

        string IBusinessLayer.InserisciNuovoStudente(Studente nuovoStudente)
        {
            throw new NotImplementedException();
        }

        public string GetLezioniByCodiceCorso(string codice)
        {
            var corso = corsiRepo.GetByCode(codice);
            if (corso == null)
            {
                return null;
            }
            return lezioniRepo.GetAll().Where(l => l.CorsoCodice == corso.CorsoCodice).ToList();
        }
    }
    }
}