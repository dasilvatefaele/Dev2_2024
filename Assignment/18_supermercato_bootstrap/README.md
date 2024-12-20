# Supermercato completo - Bootstrap

## Obiettivo

Realizzare dei layout HTML di varie pagine generiche di un sito web di un supermercato utilizzando il framework Bootstrap.

## Dettagli

- Creare un layout per la homepage del supermercato. La homepage deve contenere una barra di navigazione, un'intestazione, una sezione di prodotti in evidenza (con un carousel o simili) e una sezione di prodotti in offerta oltre ad una selezione di prodotti generici in vetrina.

- Creare un layout per la pagina di dettaglio di un prodotto. La pagina deve contenere una barra di navigazione, un'intestazione, una sezione con le informazioni del prodotto, alcune immagini e una sezione con i prodotti correlati.

- Creare un layout per la pagina di contatti del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione, un modulo di contatto (potrebbe essere il form dove gli utenti richiedono).

- Creare un layout per la pagina di registrazione del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione, un modulo di registrazione nel quale l'utente possa inserire i propri dati personali con la possibilità di selezionare il suo ruolo (cliente, dipendente, amministratore).

- Creare un layout per la pagina di login del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione e un modulo di login nel quale l'utente possa inserire le proprie credenziali.

- Creare un layout per la pagina del carrello del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione, una tabella con i prodotti selezionati dall'utente e un pulsante per procedere all'acquisto e i pulsanti per modificare la quantita e rimuovere i prodotti.

- Creare un layout per la pagina riservata agli amministratori del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione, una tabella con i prodotti in vendita e un pulsante per aggiungere eliminare o modificare un prodotto o un utente.

- Creare un layout per la pagina riservata ai dipendenti del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione, una tabella con i prodotti in vendita e le azioni che il dipendente può compiere su di essi.

- Creare un layout per la pagina riservata ai clienti del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione, una sezione con lo storico degli acquisti e una sezione dove puo controllore lo stato dei suoi ordini e dove puo modificare i propri dati personali.

- Creare un layout per la pagina di errore 404 del supermercato. La pagina deve contenere una barra di navigazione, un'intestazione e un messaggio di errore.

- La barra di navigazione deve contenere i link alle varie pagine del sito web e un pulsante per effettuare il login ed un anteprima del carrello con il numero dei prodotti selezionati.

- Ogni pagina deve avere un footer con le informazioni di contatto del supermercato e le icone dei social network.

## Note

- Utilizzare il framework Bootstrap per realizzare i layout delle pagine scegliendo fra flexbox o grid system per la realizzazione dei layout.

- Utilizzare immagini e testi generici (placeholders) per riempire i layout usando dummyimage.com

"https://dummyimage.com/800x120/ff5733/ffffff&text=header+800x200+supermercato+completo" per l'immagine dell'intestazione.

- Utilizzare il sito https://getbootstrap.com per prendere spunto e ispirazione per la realizzazione dei layout e l inserimento dei componenti (navbar, cards, carousel, bars, forms, etc).

- Il layout deve essere completamente responsive e adattarsi a tutti i dispositivi (attraverso l uso delle media queries) usando le classi di Bootstrap relative al responsive design (col-xx-xx, row, container, etc).

- Utilizzare i fonts di Google Fonts per la scelta dei font da utilizzare nel sito web. (https://fonts.google.com/)

- Utilizzare icone di Bootstrap o FontAwesome per la realizzazione dei pulsanti e dei componenti grafici. (https://fontawesome.com/ o https://icons.getbootstrap.com/)

- Utilizzare il sito colorhunt o coolors per la scelta dei colori da utilizzare nel sito web. (https://coolors.co/ o https://colorhunt.co/)

- Utilizzare il piu possibile le impostazioni aria relative all accessibilita.

---

## Checkbox Requisiti:

- [x] Utilizzo delle variabili CSS attraverso il selettore :root
- [x] Sovrascrittura delle classi di Bootstrap con !importanti
- [x] Personalizzazione dei colori principali
- [ ] Supporto a temi dinamici (Dark-mode / Light-Mode)
- [x] Modifica dei font e dei titoli
- [x] Personalzzazione della griglia e dei layout
- [x] Personalizzazione navbar e pulsanti
- [x] Typography con google fonts
- [x] Personalizzazione icone
- [ ] Utilizzo dei mixin responsivi
- [x] Creazione di layout complessi con griglie nidificate
- [x] utilizzo delle classi di visibilità
- [x] Allineamento e spaziature responsivi
- [ ] Personalizzazione dei modali e di altre componenti (?)
- [x] Utilizzo di font responsive
      https://getbootstrap.com/docs/5.0/content/typography/#responsive-font-sizes

```
Tentato l'uso delle classi dei font class="fs-6 fs-md-4" per un comportamento
responsive senza successo. Trovata in seguito documentazione che conferma
la responsività automatica dei font. Lascio temporaneamente questa implementazione
```

# Pagine mancanti

- [x] index.html
- [x] login.html
- [x] prodotto.html
- [x] sign in.html
- [x] area admin.html

- [x] area magazzino.html

  - [x] aggiungi prodotto.html
  - [x] visualizza prodotti.html
  - [x] aggiorna prodotto.html
  - [x] elimina prodotto.html

- [ ] area amministratore.html

  - [ ] aggiungi dipendente.html
  - [ ] aggiorna dipendente.html
  - [ ] rlimina dipendente.html

- [ ] area cassa.html

  - [ ] crea scontrino

- [ ] checkout.html
- [ ] modale per cateogorie
- [ ] crea dipendente.html

> Appunto:
Adattare l'altezza delle card a quella più alta.

```html
<div class="row text-center d-flex align item stretch">
    <div class="col-lg-3 col-md-6 mb-4">
        <div class="card h-100 border-1 shadow-sm">
        </div>
    </div>
</div>
```
