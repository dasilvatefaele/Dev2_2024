# HTML CSS

In html i commenti si fanno con <!-- -->
In css i commenti si fanno con /* */

## Cosa sono i TAG HTML

I tag HTML sono i blocchi di costruzione di tutte le pagine web. I browser non visualizzano i tag HTML, ma li usano per interpretare il contenuto della pagina.
Possiamo interpretare i TAG come delle direttive che dicono al browser come visualizzare il contenuto della pagina.

> Un esempio di TAG potrebbe essere il tag <b>testo in grassetto</b> che serve per rendere il testo in grassetto.

I tag vengono aperti e chiusi con le parentesi angolari `<` e `>`. Il tag di chiusura è identico a quello di apertura, ma include un carattere di barra obliqua `/` prima del nome del tag.

I tag sono da mettere in un ordine specifico, in modo che il browser possa interpretare correttamente il contenuto della pagina.
Nello specifico i tag che rappresentano attributi vengono messi all'interno di un tag che rappresenta un elemento.

Quindi seguono questo schema qui:

```html
<b>scritta</p>
<p><b>scritta</b></p>
<div><p><b>scritta</b></p></div>
```

# La struttura di una pagina HTML

Il file html si compone di due parti principali: il tag `<head>` e il tag `<body>`.
Il tag `<head>` contiene le informazioni riguardanti il documento, come il titolo, il collegamento a fogli di stile esterni, ecc.
Il tag `<body>` contiene il contenuto del documento.

```html
<!DOCTYPE html>
<html>

<head>
    <title>Titolo del documento</title>
</head>

<body>
    <h1>Titolo di primo livello</h1>
</body>

</html>
```

# HEAD cosa contiene

Il tag `<head>` potrebbe contenere:

- `<title>`: il titolo della pagina che viene visualizzato nella barra del browser
```html
<title>Titolo del documento</title>
```
- `<link>`: collegamento a un foglio di stile esterno gestito separatamente
```html
<link rel="stylesheet" type="text/css" href="style.css">
```
- `<style>`: foglio di stile interno nel quale definire le regole di stile
```html
<style>
    body {
        background-color: lightblue;
    }
</style>
```
- `<script>`: collegamento a uno script esterno o script interno
```html
<script src="script.js"></script>
```
- `<meta>`: informazioni sul documento, come l'encoding dei caratteri, la descrizione, le parole chiave, ecc.
```html
<meta charset="UTF-8">
```
# CDN e collegamento a font (https://cdnjs.com)

Questo tipo di collegamento prende il nome di CDN (Content Delivery Network) e permette di collegarsi a risorse esterne come.

- collegamento a font specifici come ad esempio quelli di google font
```html
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap" rel="stylesheet">
```

- collegamento a librerie javascript come ad esempio jquery
```html
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
```

- collegamento ad icone come ad esempio quelle di fontawesome
```html
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
```

- collegamento a framework css come ad esempio bootstrap
```html
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
```

# BODY cosa contiene

Il tag `<body>` contiene il contenuto del documento, come testo, immagini, link, ecc. cioe quello che possiamo visualizzare

```html
<body>
    <h1>Titolo di primo livello</h1>
    <p>Questo è un paragrafo.</p>
    <img src="immagine.jpg" alt="Testo alternativo">
    <a href="https://www.google.com">Questo è un link</a>
</body>
```

# TAG HTML SPECIFICI

- `<h1>`, `<h2>`, `<h3>`, `<h4>`, `<h5>`, `<h6>`: titoli di primo, secondo, terzo, quarto, quinto e sesto livello
```html
<h1>Titolo di primo livello</h1>
<h2>Titolo di secondo livello</h2>
<h3>Titolo di terzo livello</h3>
<h4>Titolo di quarto livello</h4>
<h5>Titolo di quinto livello</h5>
<h6>Titolo di sesto livello</h6>
```

- `<p>`: paragrafo
```html
<p>Questo è un paragrafo.</p>
```

- `<br>`: interruzione di riga
```html
<p>Prima riga.<br>Seconda riga.</p>
```

- `<img>`: immagine
```html
<img src="immagine.jpg" alt="Testo alternativo">
```

- `<a>`: link
```html
<a href="https://www.google.com">Questo è un link</a>
```

- `<ul>`, `<ol>`, `<li>`: elenco non ordinato, elenco ordinato, elemento dell'elenco
```html
<ul>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
</ul>
<ol>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
</ol>
```

- `<table>`, `<tr>`, `<th>`, `<td>`: tabella, riga, intestazione di colonna, cella
```html
<table>
    <tr>
        <th>Intestazione 1</th>
        <th>Intestazione 2</th>
        <th>Intestazione 3</th>
    </tr>
    <tr>
        <td>Cella 1</td>
        <td>Cella 2</td>
        <td>Cella 3</td>
    </tr>
</table>
```

- `<div>`, `<span>`: divisione, span
```html
<div>Questo è un blocco di testo.</div>
<span>Questo è un testo in linea.</span>
```

- collegamenti a sezioni specifiche della pagina come in caso di landing page
```html
<a href="#sezione1">Vai alla sezione 1</a>
<a name="sezione1">Sezione 1</a>
```

La differenza tra `<div>` e `<span>` è che `<div>` è un blocco di testo e `<span>` è un testo in linea.

# TAG HTML PER FORM

- `<form>`, `<input>`, `<textarea>`, `<button>`, `<select>`, `<option> : form, input, textarea, button, select, option
```html
<form action="/action_page.php">
    <label for="fname">Nome:</label>
    <input type="text" id="fname" name="fname"><br><br>
    <label for="lname">Cognome:</label>
    <input type="text" id="lname" name="lname"><br><br>
    <input type="submit" value="Invia">
</form>
```

# IMPOSTAZIONE ATTRIBUTI TRAMITE HTML

Gli attributi sono informazioni aggiuntive sui tag HTML che possono modificare il comportamento o l'aspetto del tag.

- `id`: identificatore univoco per un elemento
```html
<p id="paragrafo">Questo è un paragrafo.</p>
```

- `class`: classe di un elemento
```html
<p class="paragrafo">Questo è un paragrafo.</p>
```

- `style`: stile CSS per un elemento
```html
<p style="color: red;">Questo è un paragrafo rosso.</p>
```

- `src`: per immagini, collegamento a un'immagine
```html
<img src="immagine.jpg" alt="Testo alternativo">
```

- `href`: per link, collegamento a un URL
```html
<a href="https://www.google.com">Questo è un link</a>
```

- `alt`: testo alternativo per immagini
```html
<img src="immagine.jpg" alt="Testo alternativo">
```

- `title`: testo che appare quando si passa il mouse sopra un elemento
```html
<p title="Testo di descrizione">Questo è un paragrafo.</p>
```

- `type`: tipo di input per gli elementi `<input>`
```html
<input type="text">
<input type="password">
<input type="submit">
<input type="checkbox">
<input type="radio">
<input type="file">
<input type="hidden">
<input type="reset">
<input type="button">
```

- `value`: valore di input per gli elementi `<input>`
```html
<input type="text" value="Valore di input">
```

- `name`: nome di input per gli elementi `<input>`
```html
<input type="text" name="nome">
```

# CSS

I CSS (Cascading Style Sheets) sono utilizzati per controllare la presentazione di un documento HTML.
Questo include il layout, i colori e i font.

I CSS possono essere applicati in tre modi:

- Inline: applicato direttamente all'elemento
```html
<p style="color: red;">Questo è un paragrafo rosso.</p>
```

- Internal: applicato all'interno del tag `<style>` nel tag `<head>`
```html
<style>
    body {
        background-color: lightblue;
    }
</style>
```

- External: collegato a un file CSS esterno
```html
<link rel="stylesheet" type="text/css" href="style.css">
```

# SELETTORE CSS

I selettori CSS vengono utilizzati per selezionare gli elementi HTML a cui si desidera applicare uno stile.

- Selettore di tipo: seleziona tutti gli elementi di un determinato tipo
```css
p {
    color: red;
}
```
```html
<p>Questo è un paragrafo.</p>
```

- Selettore di elemento: seleziona un elemento con un determinato nome
```css
div {
    color: red;
}
```
```html
<div>Questo è un div.</div>
```

- Selettore di elemento personalizzato: seleziona un elemento con un determinato nome personalizzato
```css
bianco {
    color: red;
}
```
```html
<bianco>Questo è un div.</bianco>
```

- Selettore di classe: seleziona tutti gli elementi con una determinata classe
```css
.paragrafo {
    color: red;
}
```
```html
<p class="paragrafo">Questo è un paragrafo.</p>
```

- Selettore di ID: seleziona un elemento con un determinato ID
```css
#paragrafo {
    color: red;
}
```
```html
<p id="paragrafo">Questo è un paragrafo.</p>
```

- Selettore universale: seleziona tutti gli elementi
```css
* {
    color: red;
    text-decoration: none;
}
```
```html
<p>Questo è un paragrafo.</p>
<div>Questo è un div.</div>
```

- Selettore discendente: seleziona un elemento figlio di un altro elemento 
> il selettore selezionerà tutti i paragrafi figli di un div
```css
div p {
    color: red;
}
```
```html
<div>
    <p>Questo è un paragrafo.</p>
</div>
```

- Selettore figlio: seleziona un elemento figlio di un altro elemento
> il selettore selezionerà tutti i paragrafi figli diretti di un div
```css
div > p {
    color: red;
}
```
```html
<div>
    <p>Questo è un paragrafo.</p>
</div>
```

- Selettore di attributo: seleziona un elemento con un attributo specifico
> il selettore selezionerà tutti i link con l'attributo href
```css
a[href] {
    color: red;
}
```
```html
<a href="https://www.google.com">Questo è un link</a>
```

- Selettore di attributo con valore: seleziona un elemento con un attributo specifico e un valore specifico
> il selettore selezionerà tutti i link con l'attributo href e il valore specifico
```css
a[href="https://www.google.com"] {
    color: red;
}
```
```html
<a href="https://www.google.com">Questo è un link</a>
```

# PROPRIETÀ CSS

Le proprietà CSS vengono utilizzate per definire lo stile di un elemento HTML.

- `color`: colore del testo
```css
p {
    color: red;
}
```

- `background-color`: colore di sfondo
```css
body {
    background-color: lightblue;
}
```

- `font-family`: famiglia di caratteri
```css
p {
    font-family: Arial, sans-serif;
}
```

- `font-size`: dimensione del carattere
```css
p {
    font-size: 16px;
}
```

- `font-weight`: spessore del carattere
```css
p {
    font-weight: bold;
}
```

- `text-align`: allineamento del testo
```css
p {
    text-align: center;
}
```

- `text-decoration`: decorazione del testo
```css
a {
    text-decoration: none;
}
```

- `border`: bordo
```css
div {
    border: 1px solid black;
}
```

- `margin`: margine esterno
```css
div {
    margin: 10px;
}
```

- `padding`: margine interno
```css
div {
    padding: 10px;
}
```

- `width`: larghezza
```css
div {
    width: 100px;
}
```

- `height`: altezza
```css
div {
    height: 100px;
}
```

# Tipi di unità di misura (il viewport e la parte visibile della pagina)

- `px`: pixel
- `%`: percentuale
- `em`: dimensione del carattere (es. 1em = dimensione del carattere radice)
- `rem`: dimensione del carattere
- `vw`: larghezza della viewport
- `vh`: altezza della viewport

# Media Query

Le media query vengono utilizzate per applicare stili diversi in base alle dimensioni del dispositivo.

Le media query piu frequentemente usate sono:

- 576px: dispositivi mobili
- 768px: tablet
- 992px: laptop
- 1400px: desktop
- da 1400px in su: smart tv

```css
@media screen and (max-width: 576px) {
    body {
        background-color: lightblue;
    }
}

@media screen and (min-width: 577px) and (max-width: 768px) {
    body {
        background-color: lightgreen;
    }
}

@media screen and (min-width: 769px) and (max-width: 992px) {
    body {
        background-color: lightyellow;
    }
}

@media screen and (min-width: 993px) and (max-width: 1400px) {
    body {
        background-color: lightcoral;
    }
}

@media screen and (min-width: 1401px) {
    body {
        background-color: lightgray;
    }
}
```

# CSS FLEXBOX

Il CSS Flexbox è un layout model che permette di creare layout complessi e flessibili senza l'utilizzo di float o posizionamenti.

```css
.container {
    display: flex;
    justify-content: center;
    align-items: center;
}
```

Impostando l attributo display:flex rendo disponibile l elemento ad accettare i parametri specifici sulla flessibilita come ad esempio

- `justify-content`: allineamento orizzontale
- `align-items`: allineamento verticale
- `flex-direction`: direzione del layout
- `flex-wrap`: avvolgimento del layout
- `flex-grow`: flessibilità del layout
- `flex-shrink`: ridimensionamento del layout
- `flex-basis`: dimensione base del layout
- `align-self`: allineamento di un elemento specifico

# CSS GRID

Il CSS Grid è un layout model che permette di creare layout complessi e flessibili senza l'utilizzo di float o posizionamenti.

```css
.container {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-rows: 100px 100px;
}
```

Impostando l attributo display:grid rendo disponibile l elemento ad accettare i parametri specifici sulla flessibilita come ad esempio

- `grid-template-columns`: colonne del layout
- `grid-template-rows`: righe del layout
- `grid-column-gap`: spazio tra le colonne
- `grid-row-gap`: spazio tra le righe
- `grid-gap`: spazio tra le colonne e le righe
- `grid-column-start`: inizio della colonna
- `grid-column-end`: fine della colonna
- `grid-row-start`: inizio della riga
- `grid-row-end`: fine della riga
- `grid-area`: area del layout
- `grid-template-areas`: aree del layout

# CSS ANIMAZIONI

Le animazioni CSS vengono utilizzate per creare effetti di animazione su elementi HTML.

```css
@keyframes example {
    0% {
        background-color: red;
    }
    50% {
        background-color: yellow;
    }
    100% {
        background-color: blue;
    }
}
```

Esempio di utilizzo con progress bar:

```css
.progress {
    width: 100%;
    background-color: #f1f1f1;
}

.progress-bar {
    width: 0%;
    height: 30px;
    background-color: #4caf50;
    animation: progress 5s;
}

@keyframes progress {
    0% {
        width: 0%;
    }
    100% {
        width: 100%;
    }
}
```

# CSS TRASFORMAZIONI

Le trasformazioni CSS vengono utilizzate per modificare la posizione, la rotazione e le dimensioni degli elementi HTML.

```css
div {
    transform: rotate(45deg);
}
```

Esempio di utilizzo con bottone:

```css
.button {
    width: 100px;
    height: 50px;
    background-color: #4caf50;
    color: white;
    text-align: center;
    line-height: 50px;
    transition: background-color 0.5s;
}

.button:hover {
    background-color: #45a049;
}
```