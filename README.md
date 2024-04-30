# Libreria Web API

## Descrizione
Questa web API permette la gestione di un catalogo di una libreria, con le seguenti funzionalità:

## Funzionalità
### Utenti
- Creazione di un utente (anonima senza autenticazione)
- Autenticazione

### Categorie
- Creazione di una categoria (non possono esistere due categorie con lo stesso nome)
- Eliminazione di una categoria (solamente se la categoria non contiene libri)

### Libri
- Caricamento di un libro
- Modifica di un libro
- Eliminazione di un libro
- Ricerca di un libro in base alle seguenti proprietà (obbligatoria almeno un filtro):
  - Categoria
  - Nome del libro
  - Data di Pubblicazione
  - Autore
- La ricerca dovrà paginare i risultati, in base ad un parametro passato nella chiamata

## Modello dei dati
### Utente
- Email
- Nome
- Cognome
- Password

### Libro
- Nome
- Autore
- Data di Pubblicazione
- Editore
- Categorie

### Categoria
- Nome

## Tecnologie utilizzate
- .NET Core
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

## Istruzioni per l'installazione e l'utilizzo
1. Aprire Visual Studio e clonare la repository del progetto
2. Aprire SQL Server Management Studio e creare un nuovo database chiamato "ProgettoEnterprise" (senza virgolette)
3. Una volta creato il DB, si può fare il restore delle tabelle eseguendo il codice fornito al percorso /Paradigmi.Enterprise.Models/Database/dump.sql in una nuova query
4. Sempre in SQL Server, creare un nuovo utente che abbia questo DB come default e che sia owner. L'autenticazione deve essere del tipo "SQL Server Authentication" e va disattivato "Enforce password policy"
5. Username e password dell'utente devono essere entrambi "enterprise"
6. Per avviare il progetto è sufficiente eseguirlo da Visual Studio
