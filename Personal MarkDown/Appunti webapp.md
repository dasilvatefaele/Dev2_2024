
# APPUNTI WebApp per le assenza 

```
using Microsoft.AspNetCore.Mvc;
```

NEL MODELLO
CAMPO DEL MODELLO
[TempData] <--- temp data (DECORATOR)
public string Message {get; set}

NELLA VISTA:
<p> @TempData["Message"]</p>

NEL LAYOUT HTML:
<form> method="post" asp-page="pagina-di-arrivo"</form>

si può usare anche nel partial (anzi l)

vantaggio: [TempData]
- Non è necessario un redirect per caricare un'altra pagina, redirectopage() 
rimanendo nella stessa pagina con il dato aggiornato, senza per forza andare in una seconda pagina e stampando un messaggio di conferma. 
- OnGet viene caricato automaticamente 
- il form passa dati temporaneamente per essere cancellati in automatico in automatico
- evitare il refresh, aggiornando i dati

[TempData].Keep["Message"] - mantienilo in memoria
[TempData].Peek["Message"] - utilizzalo e lo cancelli

```
Casi di utilizzo
Un utente deve compilare dieci campi
per non darglieli tutti insieme
gliene si fa tre alla volta
e i dati vengono mantenuti di pagina in pagina
e mantenuti attraverso il metodo keep.
```

## COMPRESO IN TEORIA - DA TESTARE NELLA PRATICA 
- [x] usare decorator TempData per stampare un messaggio di conferma senza per forza andare in una seconda pagina.

---
#### 10/02/2025

Obiettivo
- [x] Leggere da un file Json le categorie e permettere la selezione da menu a tendina 


# da vedere:
- [x] SQL (creare tabelle, operazioni CRUD, JOIN, Paginazione, 
      OFFSET, parametri, Seeding, evitare le Injection) (rendere le query più sicure)
- [x] data-notation / o decorator (tecniche di validazioni degli inserimenti)
- [x] classi utilities per il front-end (active-class)
- [x] integrazione partial views (front-end modulare)
- [x] classe utilities per il database
- [x] classe degli errori
- [x] razor - webapp
- [x] global using
- [x] try-catch
- [x] viewbag
- [x] culture
