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
1. 
