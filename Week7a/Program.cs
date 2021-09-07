using System;
using System.Collections.Generic;
using System.Linq;
using Week7a.BusinessLayer;

namespace Week7a
{
        class Program
        {
            private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryDocentiMock(), new RepositoryLezioniMock(), new RepositoryStudentiMock());
            static void Main(string[] args)
            {
                bool continua = true;
                while (continua)
                {
                    int scelta = SchermoMenu();
                    continua = AnalizzaScelta(scelta);
                }
            }

            private static int SchermoMenu()
            {
                Console.WriteLine("******************Menu****************");
                //Funzionalità su Corsi
                Console.WriteLine("\nFunzionalità CORSI");
                Console.WriteLine("1. Visualizza Corsi");
                Console.WriteLine("2. Inserisci nuovo Corso");
                Console.WriteLine("3. Modifica Corso");
                Console.WriteLine("4. Elimina Corso");
                //Funzionalità su Docenti
                Console.WriteLine("\nFunzionalità Docenti");
                Console.WriteLine("5. Visualizza Docenti");
                Console.WriteLine("6. Inserisci nuovo Docente");
                Console.WriteLine("7. Modifica Docente");
                Console.WriteLine("8. Elimina Docente");
                //Funzionalità su Lezioni
                Console.WriteLine("\nFunzionalità Lezioni");
                Console.WriteLine("9. Visualizza elenco delle lezioni completo");
                Console.WriteLine("10. Inserimento nuova lezione");
                Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
                Console.WriteLine("12. Elimina lezione");
                Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
                Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");
                //Funzionalità su Studenti
                Console.WriteLine("\nFunzionalità Studenti");
                Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
                Console.WriteLine("16. Inserimento nuovo Studente");
                Console.WriteLine("17. Modifica Studente");//per semplicità solo email
                Console.WriteLine("18. Elimina Studente");
                Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

                //Exit
                Console.WriteLine("\n0. Exit");
                Console.WriteLine("********************************************");


                int scelta;
                Console.Write("Inserisci scelta: ");
                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
                {
                    Console.Write("\nScelta errata. Inserisci scelta corretta: ");
                }
                return scelta;

            }
            private static bool AnalizzaScelta(int scelta)
            {
                switch (scelta)
                {
                    case 1:
                        VisualizzaCorsi();
                        break;
                    case 2:
                        InserisciNuovoCorso();
                      break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminaCorso();
                    break;
                case 5:
                    VisualizzaDocente();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    ElencoLezioni();
                    break;
                case 10:
                    NuovaLezione();
                    break;
                case 11:
                    ModificaLezione();
                    break;
                case 12:
                    EliminaLezione();
                    break;

                case 13:
                    LezioniGetByCode();
                    break;
                case 14:
                    LezioniGetByName();
                    break;
                case 15:
                    StudentiIscritti();
                    break;
                      
                case 16:
                    InserisciNuovoStudente();
                    break;

                case 17:
                    ModificaStudente();
                    break;
                case 18:
                    EliminaStudente();
                    break;

                case 0:
                    return false;
            }
                return true;
            }

        private static void InserisciNuovoStudente()
        {
            Console.WriteLine("Nome del nuovo studente");
            string nome = Console.ReadLine();
            Console.WriteLine("Cognome del nuovo studente");
            string cognome = Console.ReadLine();
            Console.WriteLine("Email");
            string email = Console.ReadLine();
            Console.WriteLine("Data di nascita (gg-mm-aaaa)");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Titolo studio precedente");
            string titoloStudio = Console.ReadLine();
            VisualizzaCorsi();
            Console.WriteLine("Codice corso cui è iscritto");
            string codiceCorso = Console.ReadLine();
             
            Studente nuovoStudente = new Studente();
            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.TitoloStudio = titoloStudio;
            nuovoStudente.CorsoCodice = codiceCorso;
 
            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);

        }

        private static void LezioniGetByName()
        {
            VisualizzaCorsi();

            Console.WriteLine("Quale corso vuoi selezionare? Inserisci il Nome");
            string nome = Console.ReadLine();


            var lezioniGetByName = bl.GetLezioniByCodiceCorso(nome);
            if (lezioniGetByName == null)
            {
                Console.WriteLine("Nome del corso errato");
            } 
            else
            {
                foreach (var item in lezioniGetByName)
                {
                    Console.WriteLine(item);
                }
            }

        }

        private static void LezioniGetByCode()
        {
            VisualizzaCorsi();

            Console.WriteLine("Quale corso vuoi selezionare? Inserisci il codice");
            string codice = Console.ReadLine();


            var lezioniByCode = bl.GetLezioniByCodiceCorso(codice);
            if (lezioniByCode == null)
            {
                Console.WriteLine("Codice del corso errato");
            }
            else
            {
                foreach (var item in lezioniByCode)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void EliminaLezione()
        {
            Console.WriteLine("Elenco delle lezioni presenti:");
            ElencoLezioni();
            Console.WriteLine("Quale lezione vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            string esito = bl.EliminaLezione(codice);
            Console.WriteLine(esito);
        }

        private static void ModificaLezione()
        {
            Console.WriteLine("Elenco lezioni presenti");
            ElencoLezioni();
            Console.WriteLine("Quale lezione vuoi modificare? Inserisci codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il codice della nuova lezione");
            string codiceLezione = Console.ReadLine();
            Console.WriteLine("Inserisci il nome della nuova lezione");
            string nomeLezione = Console.ReadLine();
            Console.WriteLine("Inserisci Data di inizio lezione");
            DateTime dataLezione = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la durata della lezione");
            string durataLezione = Console.ReadLine();
            Console.WriteLine("Inserisci l'aula dove si terrà la lezione");
            string aulaLezione = Console.ReadLine();

            bl.ModificaLezione(codice, codiceLezione, nomeLezione, dataLezione, durataLezione, aulaLezione);

        }

        private static void NuovaLezione()
        {
            Console.WriteLine("Inserisci il codice della nuova lezione");
            string codiceLezione = Console.ReadLine();
            Console.WriteLine("Inserisci il nome della nuova lezione");
            string nomeLezione = Console.ReadLine();
            Console.WriteLine("Inserisci Data di inizio lezione");
            DateTime dataLezione = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la durata della lezione");
            string durataLezione = Console.ReadLine();
            Console.WriteLine("Inserisci l'aula dove si terrà la lezione");
            string aulaLezione  = Console.ReadLine();


            Lezione nuovaLezione = new Lezione();
            nuovaLezione.CorsoCodice  = codiceLezione;
            nuovaLezione.LezioneID = nomeLezione;
            nuovaLezione.DataOraInizio = dataLezione;
            nuovaLezione.Durata = durataLezione;
            nuovaLezione.Aula = aulaLezione;

            string esito = bl.InserisciNuovaLezione(nuovaLezione);
            Console.WriteLine(esito);
        }


        private static void ElencoLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono Lezioni!");
            }
            else
            {
                Console.WriteLine("Le lezioni disponibili sono:");
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti disponibili:");
            VisualizzaDocente();
            Console.WriteLine("Quale docente vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            string esito = bl.EliminaDocente(codice);
            Console.WriteLine(esito);
        }
         
        private static void ModificaDocente()
        {

            Console.WriteLine("Elenco docenti presenti");
            VisualizzaDocente();
            Console.WriteLine("Quale docente vuoi modificare? Inserisci codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome nuovo docente");
            string nuovoNome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del nuovo docente");
            string nuovoCognome = Console.ReadLine();
            Console.WriteLine("Inserisci il telefono del nuovo docente");
            string nuovoTelefono = Console.ReadLine();

            bl.ModificaDocente(codice, nuovoNome, nuovoCognome, nuovoTelefono);
        }

        private static void InserisciNuovoDocente()
        {
            Console.WriteLine("Inserisci il codice del nuovo docente");
            string codiceDocente = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del nuovo docente");
            string nomeDocente = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del nuovo docente");
            string cognomeDocente = Console.ReadLine();
            Console.WriteLine("Inserisci email del nuovo docente");
            string emailDocente = Console.ReadLine();
            Console.WriteLine("Inserisci il telefono del nuovo docente");
            string telefonoDocente = Console.ReadLine();


            Docente nuovoDocente = new Docente();
            nuovoDocente.Nome = nomeDocente;
            nuovoDocente.Cognome = cognomeDocente;
            nuovoDocente.ID = codiceDocente;
            nuovoDocente.Email = emailDocente;
            nuovoDocente.Telefono = telefonoDocente;

            string esito = bl.InserisciNuovoDocente(nuovoDocente);
            Console.WriteLine(esito);

        }

        private static void VisualizzaDocente()
        {
            var docenti = bl.GetAllDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono docenti!");
            }
            else
            {
                Console.WriteLine("I docenti disponibili sono:");
                foreach (var item in docenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void StudentiIscritti()
        {

            var studenti = bl.GetStudents();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono studenti!");
            }
            else
            {
                Console.WriteLine("Gli studenti iscritti al corso sono:");
                foreach (var item in studenti)
                {
                    Console.WriteLine(item);
                }

            }
        }

            private static void EliminaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili:");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            string esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);

        }


        private static void ModificaCorso()
        {
            Console.WriteLine("Elenco corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome nuovo corso");
            string nuovoNome = Console.ReadLine(); 
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string nuovaDesc = Console.ReadLine();

            bl.ModificaCorso(codice, nuovoNome, nuovaDesc);
        }
            private static void InserisciNuovoCorso()
            {
                Console.WriteLine("Inserisci il codice del nuovo corso");
                string codice = Console.ReadLine();
                Console.WriteLine("Inserisci il nome del nuovo corso");
                string nome = Console.ReadLine();
                Console.WriteLine("Inserisci la descrizione del nuovo corso");
                string descrizione = Console.ReadLine();

                Corso nuovoCorso = new Corso();
                nuovoCorso.Nome = nome;
                nuovoCorso.CorsoCodice = codice;
                nuovoCorso.Descrizione = descrizione;

                string esito = bl.InserisciNuovoCorso(nuovoCorso);
                Console.WriteLine(esito);
            }

            private static void VisualizzaCorsi()
            {
                var corsi = bl.GetAllCorsi();
                if (corsi.Count == 0)
                {
                    Console.WriteLine("Lista vuota. Non ci sono corsi!");
                }
                else
                {
                    Console.WriteLine("I Corsi disponibili sono:");
                    foreach (var item in corsi)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }

        private static void ModificaStudente()
        {
            Console.WriteLine("Lista studenti");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi modificare? Inserisci codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome nuovo studente");
            string nuovoNome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome del nuovo studente");
            string nuovoCognome = Console.ReadLine();
            Console.WriteLine("Inserisci Data di nascita del nuovo studente");
            DateTime nuovaDataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci titolo studio del nuovo studente");
            string nuovoTitoloStudio = Console.ReadLine();

            bl.ModificaStudente(codice, nuovoNome, nuovoCognome, nuovaDataNascita, nuovoTitoloStudio);
        }

        private static void VisualizzaStudenti()
        {

            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono studenti!");
            }
            else
            {
                foreach (var item in studenti)
                {
                    Console.WriteLine(item);
                }
            }
        }

         private static void EliminaStudente() {
            Console.WriteLine("Ecco l'elenco degli studenti:");
            VisualizzaStudenti();
        Console.WriteLine("Quale studente vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
        string esito = bl.EliminaStudente(codice);
        Console.WriteLine(esito);

        }

        private static void VisualizzaStudentiPerCorso()
        {

            VisualizzaCorsi(); 

                Console.WriteLine("Quale corso vuoi selezionare? Inserisci codice");
                string codice = Console.ReadLine();

                
                var studentiIscritti = bl.GetStudentiByCodiceCorso(codice);
                if (studentiIscritti == null)
                {
                    Console.WriteLine("Codice corso errato");
                }
                else if (studentiIscritti.Count == 0)
                {
                    Console.WriteLine("Lista vuota. Non ci sono studenti!");
                }
                else
                {
                    foreach (var item in studentiIscritti)
                    {
                        Console.WriteLine(item);
                    }
                }


            }
        }
            }
       
    