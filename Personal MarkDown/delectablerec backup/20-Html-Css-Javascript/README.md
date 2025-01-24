# HTML

HTML è un linguaggio di markup per la strutturazione delle pagine web, pubblicato come W3C Recommendation da ottobre 2014. Il suo sviluppo è stato affidato all'HTML Working Group, un gruppo di lavoro specifico composto da rappresentanti di aziende, produttori di software, esperti di linguaggi di markup e browser.

La differenza principale rispetto alle versioni precedenti di HTML è che HTML è un linguaggio basato su un insieme di regole ben definite, chiamate parsing rules, che permettono di interpretare correttamente il codice HTML anche se non è stato scritto correttamente. Questo permette di scrivere codice HTML più semplice e di correggere gli errori di sintassi più facilmente.

## Struttura di un documento HTML

Un documento HTML è composto da due parti principali: il doctype e il body.
Il doctype è la dichiarazione che indica al browser che il documento è scritto in HTML. Il doctype di HTML è `<!DOCTYPE html>`.
Il body è la parte del documento che contiene il contenuto della pagina web.

## Tag HTML

I tag HTML sono i seguenti:

- `<html>`: indica l'inizio e la fine del documento HTML
- `<head>`: contiene le informazioni sul documento HTML
- `<title>`: contiene il titolo del documento HTML
- `<body>`: contiene il contenuto del documento HTML
- `<h1>`, `<h2>`, `<h3>`, `<h4>`, `<h5>`, `<h6>`: contengono i titoli di primo, secondo, terzo, quarto, quinto e sesto livello
- `<p>`: contiene un paragrafo
- `<br>`: va a capo
- `<hr>`: inserisce una linea orizzontale
- `<a>`: contiene un link
- `<img>`: contiene un'immagine
- `<ul>`: contiene una lista non ordinata
- `<ol>`: contiene una lista ordinata
- `<li>`: contiene un elemento di una lista
- `<div>`: contiene un blocco di contenuto

Alcuni tag necessitano di chiusura esplicita, altri no. Spesso la chiusura è implicita, cioè il tag di chiusura è inserito automaticamente dal browser.

## Attributi HTML

Gli attributi HTML sono i seguenti:

- `id`: identifica un elemento
- `class`: identifica un gruppo di elementi
- `style`: contiene le regole CSS per formattare un elemento
- `href`: contiene l'indirizzo di un link
- `src`: contiene l'indirizzo di un'immagine
- `alt`: contiene il testo alternativo di un'immagine
- `title`: contiene il testo che appare quando si passa il mouse sopra un elemento
- `width`: contiene la larghezza di un elemento
- `height`: contiene l'altezza di un elemento
- `target`: contiene il nome della finestra in cui aprire il link

## Formattazione del testo

Per formattare il testo si possono usare i seguenti tag:

- `<b>`: testo in grassetto
- `<strong>`: testo in grassetto
- `<i>`: testo in corsivo
- `<em>`: testo in corsivo
- `<mark>`: testo evidenziato
- `<small>`: testo piccolo
- `<del>`: testo barrato
- `<ins>`: testo sottolineato
- `<sub>`: testo in pedice
- `<sup>`: testo in apice

## Formattazione del testo con CSS

Per formattare il testo con CSS si possono usare le seguenti proprietà:

- `color`: colore del testo es: `color: red;`
- `font-family`: tipo di carattere es: `font-family: Arial;`
- `font-size`: dimensione del testo es: `font-size: 12px;`
- `font-weight`: spessore del testo es: `font-weight: bold;`
- `font-style`: stile del testo es: `font-style: italic;`
- `text-decoration`: decorazione del testo es: `text-decoration: underline;`
- `text-align`: allineamento del testo es: `text-align: center;`
- `text-indent`: rientro del testo es: `text-indent: 20px;`
- `text-transform`: trasformazione del testo cioè se deve essere tutto maiuscolo, tutto minuscolo o solo la prima lettera maiuscola es: `text-transform: uppercase;`
- `line-height`: altezza della linea di testo es: `line-height: 1.5;`
- `letter-spacing`: spaziatura delle lettere es: `letter-spacing: 2px;`
- `word-spacing`: spaziatura delle parole es: `word-spacing: 5px;`

## Liste

Per creare una lista non ordinata si usa il tag `<ul>` e per creare una lista ordinata si usa il tag `<ol>`. Per creare un elemento di una lista si usa il tag `<li>`.

## Link

Per creare un link si usa il tag `<a>`. L'attributo `href` contiene l'indirizzo del link e l'attributo `target` contiene il nome della finestra in cui aprire il link.

## Immagini

Per inserire un'immagine si usa il tag `<img>`. L'attributo `src` contiene l'indirizzo dell'immagine, l'attributo `alt` contiene il testo alternativo dell'immagine, l'attributo `width` contiene la larghezza dell'immagine e l'attributo `height` contiene l'altezza dell'immagine.

## Div

Per creare un blocco di contenuto si usa il tag `<div>`.

## Tabelle

Per creare una tabella si usa il tag `<table>`. Per creare una riga si usa il tag `<tr>`. Per creare una cella di intestazione si usa il tag `<th>` e per creare una cella si usa il tag `<td>`.

## Form

Per creare un form si usa il tag `<form>`. L'attributo `action` contiene l'indirizzo a cui inviare i dati del form e l'attributo `method` contiene il metodo HTTP da usare per inviare i dati del form.

## Input

Per creare un input si usa il tag `<input>`. L'attributo `type` contiene il tipo di input e l'attributo `name` contiene il nome dell'input.

## Tipi di input

I tipi di input sono i seguenti:

- `text`: input di testo es: `<input type="text" name="nome">`
- `password`: input di testo con i caratteri nascosti es: `<input type="password" name="password">`
- `email`: input di testo per l'email es: `<input type="email" name="email">`
- `number`: input di testo per i numeri es: `<input type="number" name="numero">`
- `date`: input di testo per la data es: `<input type="date" name="data">`
- `time`: input di testo per ora es: `<input type="time" name="ora">`
- `checkbox`: checkbox es: `<input type="checkbox" name="checkbox">`
- `radio`: radio button es: `<input type="radio" name="radio">`
- `file`: file es: `<input type="file" name="file">`
- `submit`: bottone di invio es: `<input type="submit" name="invia">`
- `reset`: bottone di reset es: `<input type="reset" name="reset">`
- `button`: bottone es: `<input type="button" name="bottone">

## Textarea

Per creare un textarea si usa il tag `<textarea>`. L'attributo `name` contiene il nome del textarea. es: `<textarea name="testo"></textarea>`

## Select

Per creare una select si usa il tag `<select>`. Per creare un'opzione si usa il tag `<option>`. L'attributo `name` contiene il nome della select. es: `<select name="opzione"><option value="1">Opzione 1</option><option value="2">Opzione 2</option></select>`

## Media Query
Una Media Query è una funzionalità di CSS3 che fa adattare il layout di una pagina a diverse dimensioni di schermo e diversi tipi di media.

Sintassi
```Css
@media media type and (condition: breakpoint) {
  // CSS rules
}
```
Possiamo creare regole per diversi tipi di media con una varietà di condizioni. Se la condizione o il tipo di media sono quelli, allora le regole dentro la media query saranno applicate, altrimenti non lo saranno.

La sintassi potrebbe essere complicata all'inizio, quindi spieghiamo ogni parte una alla volta in dettaglio...

Regola @media
Iniziamo definendo le media query con la regola @media è poi includiamo le regole CSS all'interno delle parentesi graffe. La regola @media è anche usata per specificare il tipo di media.

```Css
@media () {
  // CSS rules
}
```

Parentesi
Dentro le parentesi, impostiamo la condizione. Per esempio, voglio applicare un font più grande per dispositivi mobili. Per farlo, dobbiamo impostare una massima larghezza che verifica la larghezza del dispositivo:

```Css
.text {
  font-size: 14px;
}

@media (max-width: 480px) {
  .text {
    font-size: 16px;
  }
}
```

In genere, la dimensione del testo sarà 14px, ma visto che abbiamo applicato una media query, cambierà a 16px quando un dispositivo ha una larghezza massima di 480px o meno.

Importante: metti le tue media query sempre alla fine del tup file CSS.

Tipi di media
Se non applichiamo un tipo di media, la regola @media influenza tutti i tipi di dispositivi come default. Altrimenti, i tipi di media vengono dopo la regola @media. Ci sono molti tipi di dispositivi, ma possiamo raggrupparli in quattro categorie:

all — per tutti i tipi di media
print — per le stampanti
screen — per gli schermi di computer, tablet e smartphone
speech — per lettori di schermo che "leggono" la pagina ad alta voce
Per esempio, quando voglio selezionare solo gli schermi, metto la parola chiave screen dopo la regola @media. Devo anche concatenare le regole con la parola chiave "and":

```Css
@media screen and (max-width: 480px) {
  .text {
    font-size: 16px;
  }
}
```

Breakpoint
Breakpoint è forse il termine che sentirai usare e userai più comunemente. Un breakpoint è chiave per determinare quando cambiare layout e usare le nuove regole dentro le media query. Torniamo indietro al nostro esempio all'inizio:

```Css
@media (max-width: 480px) {
  .text {
    font-size: 16px;
  }
}
```

Qui il breakpoint è 480px. Ora la media query sa quando settare o sovrascrivere la nuova classe. In pratica, se la larghezza di un dispositivo è più piccola di 480px, la classe text sarà applicta, altrimenti non lo sarà.

Breakpoint comuni: c'è una risoluzione standard?
Una delle domande più comuni è "Quale breakpoint dovrei usare?". Ci sono un sacco di dispositi sul mercato quindi non possiamo definire breakpoint fissi per ognuno di loro.

Per questo non possiamo dire che ci sono delle risoluzioni standard per i dispositivi, ma ci sono dei breakpoint comunemente usati. Se stai usando un framework CSS (tipo Bootstrap, Bulma, ecc) puoi anche usare i loro breakpoint.

Ora vediamo alcuni breakpoint comuni per le larghezze dei dispositivi:

**320px — 480px:** dispositivi mobili
**481px — 768px:** iPad, Tablet
**769px — 1024px:** schermi piccoli, laptop
**1025px — 1200px:** computer desktop, schermi grandi
**1201px and more —**  schermi extra large, TV
Come ho detto sopra questi breakpoint possono essere diversi e non c'è uno standard esattamente definito, ma questi sono alcuni comunemente usati

## Object-fit
Per avere più controllo sulle immagini, il CSS ha a disposizione un'altra proprietà chiamata object-fit. Usiamola e assegniamole un valore in modo che abbia un aspetto migliore:

```Css
img {
  width: 100%;
  height: 300px;
  object-fit: cover;
  object-position: bottom;
}
```

# Esercizi

## bCreazione di una landing page con sezioni ed ancoraggi.

```Html
<!DOCTYPE html>
<html>
<head>
    <title>Landing Page</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <header>
        <h1>Header</h1>
    </header>

    <nav>
        <a href="#section1">Sezione 1</a>
        <a href="#section2">Sezione 2</a>
        <a href="#section3">Sezione 3</a>
    </nav>

    <section id="section1">
        <h2>Sezione 1</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunccursus
            eros, a tincidunt mauris neque eget urna. Nullam euismod, nisl eget aliquam ultricies, nunc
            cursus eros, a tincidunt mauris neque eget urna.</p>
    </section>

    <section id="section2">
        <h2>Sezione 2</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunccursus
            eros, a tincidunt mauris neque eget urna. Nullam euismod, nisl eget aliquam ultricies, nunc
            cursus eros, a tincidunt mauris neque eget urna.</p>
    </section>

    <section id="section3">
        <h2>Sezione 3</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam euismod, nisl eget aliquam ultricies, nunccursus
            eros, a tincidunt mauris neque eget urna. Nullam euismod, nisl eget aliquam ultricies, nunc
            cursus eros, a tincidunt mauris neque eget urna.</p>
    </section>

    <footer>
        <h3>Footer</h3>
    </footer>
</body>
</html>
```

style.css

```Css
body {
    margin: 0;
    padding: 0;
    font-family: Arial;
}

header {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}

nav {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}

nav a {
    color: #fff;
    text-decoration: none;
    padding: 20px;
}

nav a:hover {
    background-color: #555;
}

section {
    padding: 20px;
}

footer {
    background-color: #333;
    color: #fff;
    padding: 20px;
    text-align: center;
}
```

## Aggiunta placeholders per immagini

```Html
<img src="https://via.placeholder.com/300x200" alt="Immagine 1">
oppure immagini random:
<img src="https://source.unsplash.com/random/300x200" alt="Immagine 1">
dimensioni:
<img src="https://source.unsplash.com/random/300x200?sig=1&nature" alt="Immagine 1">
```

Aggiunta css per centrare le immagini

```Css
img {
    display: block;
    margin: 0 auto;
}
```

## Aggiunta attributi per la gestione dei paragrafi e dei titoli

```Css
p {
    text-align: justify;
    text-indent: 20px;
    line-height: 1.5;
}

h1 {
    text-align: center;
}
```

## Aggiunta attributi per la gestione delle liste

```Css
ul {
    list-style-type: none;
    padding: 0;
}

ul li {
    padding: 10px;
}

ol {
    list-style-type: decimal;
    padding: 0;
}

ol li {
    padding: 10px;
}
```

```Html
<ul>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
    <li>Elemento 3</li>
</ul>

<ol>
    <li>Elemento 1</li>
    <li>Elemento 2</li>
    <li>Elemento 3</li>
</ol>
```

## Aggiunta attributi per la gestione dei link

```Css
a {
    text-decoration: none;
    color: blue;
}

a:hover {
    text-decoration: underline;
}
```

```Html
<a href="#">Link</a>
```

## Aggiunta attributi per la gestione delle tabelle

```Css
table {
    border-collapse: collapse;
    width: 100%;
}

th, td {
    border: 1px solid #000;
    padding: 10px;
    text-align: center;
}
```

```Html
<table>
    <tr>
        <th>Intestazione 1</th>
        <th>Intestazione 2</th>
    </tr>
    <tr>
        <td>Cella 1</td>
        <td>Cella 2</td>
    </tr>
</table>
```
th = table header
td = table data

## Aggiunta attributi per la gestione dei form

```Css
form {
    text-align: center;
}

input, textarea, select {
    padding: 10px;
    margin: 10px;
    width: 300px;
    display: block;
}
```

```Html
<form action="#" method="post">
    <input type="text" name="nome" placeholder="Nome">
    <input type="email" name="email" placeholder="Email">
    <textarea name="testo" placeholder="Testo"></textarea>
    <select name="opzione">
        <option value="1">Opzione 1</option>
        <option value="2">Opzione 2</option>
    </select>
    <input type="submit" name="invia" value="Invia">
</form>
```

## Aggiunta attributi per la gestione dei pulsanti

```Css
button {
    padding: 10px;
    margin: 10px;
    display: block;
}
```

```Html
<button type="menu">Bottone</button>
```

## Aggiunta elementi divisori

```Css
hr {
    border-color: #333;
}
```

```Html
<hr>
```

## Aggiunta attributi per la gestione dei div

```Css
div {
    padding: 20px;
    margin: 20px;
    border: 1px solid #000;
}
```

```Html
<div>
    <p>Testo</p>
</div>
```

## Aggiunta CSS personalizzati

```css
.colorea {
    background-color: chartreuse;
}

.coloreb {
    background-color:hotpink;
}
```
```html
<div>
            <div class="colorea">
                <p>Testo</p>
            </div>
        </div>
        <div>
            <div class="coloreb">
                <p>Testo</p>
            </div>
        </div>
```
# IMPLEMENTAZIONI GRAFICHE E FUNZIONALI
## Layout responsivo
Il Layout responsivo è un layout che si adatta automaticamente alle dimensioni del dispositivo su cui viene visualizzato.
Quando la finestra del browser è più piccola di 768px, il layout cambia e si adatta alle dimensioni del dispositivo.
Si chiama media query.
```Css
@media (max-width: 768px) {
    header {
        background-color: #555;
    }

    nav {
        background-color: #555;
    }

    section {
        padding: 10px;
    }

    footer {
        background-color: #555;
    }
}
```
## Grid layout
Il Grid layout è un layout basato su una griglia.
In questo caso il layout è diviso in due colonne di larghezza uguale utilizzando la proprietà grid-template-columns ed è separato da uno spazio di 20px utilizzando la proprietà grid-gap.
1 fr = 1 parte della griglia cioè 1/2
```Css
section {
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-gap: 20px;
}
```
Se vogliamo dividere la griglia in tre colonne di larghezza uguale possiamo usare la seguente proprietà:
```Css
section {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-gap: 20px;
}
```
Se vogliamo che le parti della griglia siano di larghezza diversa possiamo usare la seguente proprietà:
```Css
section {
    display: grid;
    grid-template-columns: 1fr 2fr 1fr;
    grid-gap: 20px;
}
```
## Flexbox layout
Il Flexbox layout è un layout basato su un contenitore e su elementi flessibili.
In questo caso il layout è diviso in due colonne di larghezza uguale utilizzando la proprietà flex e è separato da uno spazio di 20px utilizzando la proprietà margin.
```Css
section {
    display: flex;
}

section div {
    flex: 1;
    margin: 20px;
}
```
Flex è una proprietà che indica la flessibilità di un elemento cioè quanto può espandersi o restringersi. ed 1 indica che l'elemento può espandersi o restringersi in base allo spazio disponibile.
Se invece vogliamo che un elemento sia più flessibile di un altro possiamo usare la seguente proprietà:
```Css
section div {
    flex: 2;
    margin: 20px;
}
```
Flex 2 indica che l'elemento può espandersi o restringersi il doppio rispetto agli altri elementi.


## Esercizio
```css
.container {
    display: flex;
    justify-content: center; /* Centra gli elementi orizzontalmente */
    align-items: center; /* Centra gli elementi verticalmente */
    height: 100vh; /* Imposta l'altezza del container al 100% dell'altezza della viewport */
    padding: 20px; /* Aggiunge spazio intorno agli elementi all'interno del container */
}

.box {
    height: 100px; /* Altezza di ogni box */
    background-color: lightblue; /* Colore di sfondo dei box */
    margin: 10px; /* Spazio tra i box */
    display: flex;
    justify-content: center; /* Allinea il testo orizzontalmente */
    align-items: center; /* Allinea il testo verticalmente */
    font-size: 16px; /* Dimensione del testo */
    font-family: Arial, sans-serif; /* Tipo di font */
    /* immagine di sfondo */
    background-image: url('https://via.placeholder.com/300x200');
    background-size: cover;
    background-position: center;
}

.box:nth-child(1) {
    flex: 2; /* Imposta il box 1 a doppio della dimensione base */
    background-color: lightcoral; /* Colore differente per distinguere */
}

.box:nth-child(2) {
    flex: 3; /* Imposta il box 2 a triplo della dimensione base */
    background-color: lightgreen; /* Colore differente per distinguere */
}

.box:nth-child(3) {
    flex: 1; /* Dimensione base per il box 3 */
    background-color: lightblue; /* Colore come gli altri per coerenza */
}

```

Spiegazione del CSS modificato:

- .container: Lo stile rimane simile, con l'aggiunta di un padding per migliorare l'aspetto visivo.
- .box: Ogni box ha una altezza specificata e altre proprietà per l'allineamento e la visualizzazione.
- .box:nth-child(1), .box:nth-child(2), .box:nth-child(3): Questi selezionatori targettizzano il primo, secondo e terzo box, rispettivamente. Utilizzano la proprietà flex per assegnare una "frazione" dello spazio disponibile ad ogni box, in modo che il primo sia doppio del terzo e il secondo sia triplo del terzo. Ogni box ha anche un colore di sfondo distinto per una facile distinzione visiva

-La pseudo-classe CSS :nth-child() è utilizzata per selezionare uno o più elementi basandosi sulla loro posizione all'interno di un contenitore padre. Essa permette di applicare stili specifici agli elementi in base alla loro posizione in una sequenza di elementi fratelli.

La sintassi di base è :nth-child(an+b), dove:

- a e b sono numeri interi.
- n è un contatore che parte da 0.
Ecco alcune espressioni di esempio e cosa rappresentano:

- :nth-child(1): seleziona il primo elemento figlio.
- :nth-child(2n): seleziona tutti gli elementi figli che sono in posizioni pari (2, 4, 6, ...).
- :nth-child(2n+1): seleziona tutti gli elementi figli che sono in posizioni dispari (1, 3, 5, ...), equivalente a :nth-child(odd).
- :nth-child(3n+1): seleziona gli elementi figli che sono il primo, il quarto, il settimo, e così via.
La pseudo-classe :nth-child() è molto utile per applicare stili diversi a elementi che sono regolarmente spaziati o per evidenziare particolari elementi all'interno di una lista o di una griglia senza dover aggiungere classi o ID aggiuntivi agli elementi HTML

> è possibile provare i tipi di flexbox tramite un gioco qui:

> http://www.flexboxfroggy.com

## Font Google
Il Font Google è un font che viene scaricato da Google e utilizzato nel sito web.
```Html
<link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" >
```
```Css
body {
    font-family: 'Roboto', sans-serif;
}
```
## Icone Font Awesome
L'Icona Font Awesome è un'icona che viene scaricata da Font Awesome e utilizzata nel sito web.
```Html
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" >
```
```Html
<i class="fas fa-home"></i>
```

Si possono formattare le icone di Font Awesome in vari modi:
```Css
i {
    color: red;
    font-size: 24px;
}
```

Oppure si possono usare attributi in linea:
```Html
<i class="fas fa-home" style="color: red; font-size: 24px;"></i>
```
> in questo modo possiamo avere le icone di un colore specifico tramite css esterno ed una icona di un colore diverso attraverso i css in linea
Gli attributi specifici di Font Awesome sono i seguenti:
- `fas`: icona solida
- `far`: icona regolare
- `fal`: icona leggera
- `fab`: icona brand
- `fa-2x`: doppia grandezza
- `fa-3x`: tripla grandezza
- `fa-4x`: quadrupla grandezza
- `fa-5x`: quintupla grandezza
- `fa-fw`: larghezza fissa
- `fa-ul`: lista non ordinata
- `fa-li`: elemento di una lista non ordinata
- `fa-border`: bordo
- `fa-pull-left`: allineamento a sinistra
- `fa-pull-right`: allineamento a destra
- `fa-spin`: rotazione
- `fa-pulse`: pulsazione
- `fa-rotate-90`: rotazione di 90 gradi
- `fa-rotate-180`: rotazione di 180 gradi
- `fa-rotate-270`: rotazione di 270 gradi
- `fa-flip-horizontal`: ribaltamento orizzontale
- `fa-flip-vertical`: ribaltamento verticale
- `fa-stack`: pila
- `fa-stack-1x`: grandezza della pila
- `fa-stack-2x`: grandezza della pila
- `fa-inverse`: colore invertito
- `fa-layers`: livelli
- `fa-layers-text`: testo del livello
- `fa-layers-counter`: contatore del livello
- `fa-layers-bottom`: fondo del livello

## AGGIUNTA DI ANIMAZIONI CSS

È possibile aggiungere animazioni CSS a un sito web utilizzando la proprietà transform.
```Css
div {
    transition: transform 0.5s;
}

div:hover {
    transform: scale(1.1);
}
```
```Css
nav ul li a:before{
    content: "";
    position: absolute;
    bottom: -5px;
    height: 2px;
    width: 100%;
    background: white;
    border-radius: 50px;
    transition: transform 0.2s linear;
    transform: scaleX(0);
}

nav ul li a:hover:before{
    transform: scaleX(1);
}
```
È possibile aggiungere animazioni CSS a un sito web utilizzando la proprietà animation.

```Css
@keyframes esempio {
    0% {
        background-color: red;
    }
    50% {
        background-color: yellow;
    }
    100% {
        background-color: green;
    }
}

div {
    animation: esempio 2s infinite;
}
```

# ESERCIZIO LANDING PAGE
> crea una landing page per un progetto full-stack utilizzando le funzionalità che hai imparato
```html
<!DOCTYPE html>
<html lang="it">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Progetto Full-Stack in C#</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="#progetto">Il Progetto</a></li>
                <li><a href="#funzionalita">Funzionalità</a></li>
                <li><a href="#tecnologie">Tecnologie</a></li>
                <li><a href="#team">Il Team</a></li>
                <li><a href="#contatti">Contatti</a></li>
            </ul>
        </nav>
    </header>
    <section id="progetto">
        <h1>Benvenuti al nostro progetto Full-Stack in C#</h1>
        <p>Descrizione generale del progetto, inclusi gli obiettivi e la visione.</p>
    </section>
    <section id="funzionalita">
        <h2>Funzionalità principali</h2>
        <p>Dettagli sulle funzionalità chiave del progetto.</p>
    </section>
    <section id="tecnologie">
        <h2>Tecnologie Utilizzate</h2>
        <p>Elenco delle tecnologie e degli strumenti utilizzati nel progetto, inclusi C#, .NET, JavaScript, ecc.</p>
    </section>
    <section id="team">
        <h2>Conosci il Team</h2>
        <p>Informazioni sui membri del team, le loro competenze e ruoli nel progetto.</p>
    </section>
    <section id="contatti">
        <h2>Contatti</h2>
        <p>Dettagli su come contattare il team per ulteriori informazioni o collaborazioni.</p>
    </section>
    <footer>
        <p>&copy; 2024 Nome del Progetto. Tutti i diritti riservati.</p>
    </footer>
</body>
</html>
```
```css
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

header {
    background-color: #007bff;
    color: white;
    padding: 20px;
    text-align: center;
}

nav ul {
    list-style-type: none;
    padding: 0;
}

nav ul li {
    display: inline;
    margin: 0 10px;
}

nav ul li a {
    color: white;
    text-decoration: none;
}

section {
    padding: 20px;
    margin: 20px 0;
}

footer {
    background-color: #333;
    color: white;
    text-align: center;
    padding: 10px;
    position: fixed;
    bottom: 0;
    width: 100%;
}
```
# IMPLEMENTAZIONI
## Carosello
Il Carosello è un insieme di immagini che scorrono automaticamente.
```Html
<script src="script.js"></script>
<div id="carosello">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 1">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 2">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 3">
</div>
```
```Css
#carosello {
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-gap: 20px;
    overflow: hidden;
}

#carosello img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
```
```Javascript
let carosello = document.getElementById('carosello'); // prende l'elemento con id carosello
let immagini = carosello.getElementsByTagName('img'); // prende tutte le immagini all'interno di carosello
let indice = 0; // indice dell'immagine attuale

function avanti() {
    indice++; // incrementa l'indice

    if (indice >= immagini.length) {
        indice = 0; // se l'indice è maggiore o uguale al numero di immagini, l'indice diventa 0
    }

    carosello.style.transform = 'translateX(' + (-indice * 100) + '%)'; // trasla carosello
}

function indietro() {
    indice--; // decrementa l'indice

    if (indice < 0) {
        indice = immagini.length - 1; // se l'indice è minore di 0, l'indice diventa il numero di immagini - 1
    }

    carosello.style.transform = 'translateX(' + (-indice * 100) + '%)'; // trasla carosello
}

setInterval(avanti, 3000); // chiama la funzione avanti ogni 3000 millisecondi
```

## Menu a tendina
Il Menu a tendina è un menu che si apre e si chiude cliccando su un pulsante.
```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```
```Css
#menu {
    display: none;
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
    background-color: #fff;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```
```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}
```

## Lightbox
Il Lightbox è un'immagine che si apre in una finestra modale.
```Html
<div id="lightbox">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 1" onclick="apriLightbox(this)">
</div>
<div id="finestra">
    <img src="https://via.placeholder.com/300x200" alt="Immagine 1">
    <button onclick="chiudiLightbox()">Chiudi</button>
</div>
```
```Css
#lightbox img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
#finestra {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    text-align: center;
}
#finestra img {
    width: 80%;
    height: 80%;
    object-fit: cover;
    margin: 10% auto;
}
#finestra button {
    padding: 10px;
    margin: 10px;
}
```
```Javascript
function apriLightbox(elemento) {
    let finestra = document.getElementById('finestra'); // prende l'elemento con id finestra
    let immagine = finestra.getElementsByTagName('img')[0]; // prende l'immagine all'interno di finestra
    immagine.src = elemento.src; // imposta la sorgente dell'immagine
    finestra.style.display = 'block'; // mostra finestra
}

function chiudiLightbox() {
    let finestra = document.getElementById('finestra'); // prende l'elemento con id finestra
    finestra.style.display = 'none'; // nasconde finestra
}
```

## Modale
La Modale è una finestra modale che si apre e si chiude cliccando su un pulsante.
```Html
<button onclick="apriModale()">Apri</button>
<div id="modale">
    <div id="contenuto">
        <h2>Titolo</h2>
        <p>Testo</p>
        <button onclick="chiudiModale()">Chiudi</button>
    </div>
</div>
```
```Css
#modale {
    display: none;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    text-align: center;
}

#contenuto {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    background-color: #fff;
    padding: 20px;
}
```
```Javascript
function apriModale() {
    let modale = document.getElementById('modale'); // prende l'elemento con id modale
    modale.style.display = 'block'; // mostra modale
}

function chiudiModale() {
    let modale = document.getElementById('modale'); // prende l'elemento con id modale
    modale.style.display = 'none'; // nasconde modale
}
```

## Tooltip
Il Tooltip è un testo che appare quando si passa il mouse sopra un elemento.
```Html
<div id="tooltip" onmouseover="mostraTooltip()" onmouseout="nascondiTooltip()">Testo</div>
<div id="finestra-tooltip">Tooltip</div>
```
```Css
#finestra-tooltip {
    display: none;
    position: absolute;
    top: 0;
    left: 0;
    background-color: #000;
    color: #fff;
    padding: 10px;
}
```
```Javascript
function mostraTooltip() {
    let finestra = document.getElementById('finestra-tooltip'); // prende l'elemento con id finestra-tooltip
    finestra.style.display = 'block'; // mostra finestra
}

function nascondiTooltip() {
    let finestra = document.getElementById('finestra-tooltip'); // prende l'elemento con id finestra-tooltip
    finestra.style.display = 'none'; // nasconde finestra
}
```

## Scroll to top
Lo Scroll to top è un pulsante che appare quando si scorre la pagina verso il basso e scompare quando si scorre la pagina verso l'alto.
```Html
<button onclick="scrollToTop()">Top</button>
```
```Css
button {
    display: none;
    position: fixed;
    bottom: 20px;
    right: 20px;
    padding: 10px;
}
```
```Javascript
window.onscroll = function() {scrollFunction()};
function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementsByTagName('button')[0].style.display = 'block';
    } else {
        document.getElementsByTagName('button')[0].style.display = 'none';
    }
}

function scrollToTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}
```

## Menu a scomparsa
Il Menu a scomparsa è un menu che si apre e si chiude cliccando su un pulsante.
```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```
```Css
#menu {
    display: none;
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
    background-color: #fff;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```
```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}
```

## Menu a scomparsa con animazione
Il Menu a scomparsa con animazione è un menu che si apre e si chiude cliccando su un pulsante con un'animazione.
```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```
```Css
#menu {
    display: none;
    position: absolute;
    top: 50px;
    right: 0;
    background-color: #fff;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    animation: apri 0.5s;
}

@keyframes apri {
    from {
        transform: translateX(100%);
    }
    to {
        transform: translateX(0);
    }
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```
```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}
```

## Menu a scomparsa con animazione e chiusura
Il Menu a scomparsa con animazione e chiusura è un menu che si apre e si chiude cliccando su un pulsante con un'animazione e si chiude cliccando su un pulsante.
```Html
<button onclick="mostraMenu()">Menu</button>
<div id="menu">
    <button onclick="chiudiMenu()">Chiudi</button>
    <a href="#">Link 1</a>
    <a href="#">Link 2</a>
    <a href="#">Link 3</a>
</div>
```
```Css
#menu {
    display: none;
    position: absolute;
    top: 50px;
    right: 0;
    background-color: #fff;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
    animation: apri 0.5s;
}

@keyframes apri {
    from {
        transform: translateX(100%);
    }
    to {
        transform: translateX(0);
    }
}

#menu a {
    display: block;
    padding: 10px;
    text-decoration: none;
    color: #000;
}

#menu a:hover {
    background-color: #f0f0f0;
}
```
```Javascript

function mostraMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu

    if (menu.style.display == 'none') { // se il menu è nascosto
        menu.style.display = 'block'; // mostra il menu
    } else { // altrimenti
        menu.style.display = 'none'; // nasconde il menu
    }
}

function chiudiMenu() {
    let menu = document.getElementById('menu'); // prende l'elemento con id menu
    menu.style.display = 'none'; // nasconde il menu
}
```







