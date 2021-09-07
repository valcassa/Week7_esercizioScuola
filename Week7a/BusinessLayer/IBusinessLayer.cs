using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7a.BusinessLayer
{
    interface IBusinessLayer
    { 
        public List<Corso> GetAllCorsi();

        public List<Studente> GetStudents();

        public string InserisciNuovoCorso(Corso newCorso);

        public string ModificaCorso(string codiceCorsoModificare, string nuovoNome, string nuovaDesc);

         string EliminaCorso(string codiceCorsoDaEliminare);
        void ModificaStudente(string codice, string nuovoNome, string nuovoCognome, DateTime nuovaDataNascita, string nuovoTitoloStudio);
        public List<Studente> GetAllStudenti();
        string EliminaStudente(string codice);
       
        public List<Studente> GetStudentiByCodiceCorso(string codicecorso);
        string InserisciNuovoDocente(Docente nuovoDocente);
        public List<Docente> GetAllDocenti();
        string EliminaDocente(string codice);
        void ModificaDocente(string codice, string nuovoNome, string nuovoCognome, string nuovoTelefono);
        public List<Lezione> GetAllLezioni();
        string InserisciNuovaLezione(Lezione nuovaLezione);
        string ModificaLezione(string codice, string codiceLezione, string nomeLezione, DateTime dataLezione, string durataLezione, string aulaLezione);
        string EliminaLezione(string codice);
        string InserisciNuovoStudente(Studente nuovoStudente);
        string GetLezioniByCodiceCorso(string codice);
     }
} 