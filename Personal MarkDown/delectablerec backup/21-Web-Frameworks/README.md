# WEB FRAMEWORKS

# BOOTSTRAP

https://getbootstrap.com/

## Bootstrap 5

### Bootstrap 5 - Introduzione
Bootstrap 5 è un framework front-end open source che consente di creare siti web e applicazioni web con facilità. È un insieme di strumenti di progettazione e sviluppo HTML, CSS e JavaScript. È il framework front-end più popolare al mondo.

### Bootstrap 5 - Installazione
Per installare Bootstrap 5, è possibile utilizzare npm o scaricare i file direttamente dal sito web di Bootstrap.
In alternativa è possibile importare Bootstrap 5 da un CDN

CDN:
```bash
CSS	https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css
JS	https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js
```

Si può importare Bootstrap 5 da un CDN:
```html
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link href="https:xxxxx.xxxxxxxx.xxxxxxxxxxxxxxxxx@x.x.xxxxxxxxxxxxxxxxxxxx.xxx.xxx" rel="stylesheet">
  <title>Document</title>
</head>
<body>

</body>
</html>
```

### Bootstrap 5 - utilizzo
Per utilizzare Bootstrap 5, è possibile utilizzare le classi predefinite o i componenti predefiniti.

Esempio di utilizzo di una classe predefinita:
```html
<button class="btn btn-primary">Primary</button>
```

Esempio di utilizzo di un componente predefinito:
```html
<div class="alert alert-primary" role="alert">
  A simple primary alert—check it out!
</div>
```

### Bootstrap 5 - grid system
Il sistema di griglie di Bootstrap 5 è basato su 12 colonne. È possibile utilizzare le classi predefinite per creare layout flessibili e reattivi.

Esempio di utilizzo del sistema di griglie:
```html
<div class="container">
  <div class="row">
    <div class="col">
      1 of 2
    </div>
    <div class="col">
      2 of 2
    </div>
  </div>
</div>
```

## Bootstrap 5 - componenti
Bootstrap 5 offre una vasta gamma di componenti predefiniti che possono essere utilizzati per creare interfacce utente reattive e moderne.

I componenti disponibili sono:

- Alerts (Avvisi e notifiche servono a comunicare all'utente informazioni importanti)
- Badge (Badge sono utilizzati per mostrare informazioni aggiuntive)
- Breadcrumb (Breadcrumb sono utilizzati per mostrare la posizione dell'utente all'interno di un sito web)
- Buttons (I pulsanti sono utilizzati per eseguire azioni)
- Button group (I gruppi di pulsanti sono utilizzati per eseguire azioni correlate)
- Card (Le card sono utilizzate per mostrare informazioni)
- Carousel (Il carosello è utilizzato per mostrare immagini o altri contenuti in modo dinamico)
- Collapse (Il collapse è utilizzato per nascondere e mostrare contenuti)
- Dropdowns (I dropdown sono utilizzati per mostrare un elenco di opzioni)
- Forms (I form sono utilizzati per raccogliere informazioni dall'utente)
- Input group (Gli input group sono utilizzati per mostrare un input con un addon)
- List group (I list group sono utilizzati per mostrare un elenco di elementi)
- Modal (I modal sono utilizzati per mostrare un contenuto in sovraimpressione)
- Navs (I navs sono utilizzati per mostrare un elenco di link)
- Navbar (La navbar è utilizzata per mostrare un menu di navigazione)
- Pagination (La pagination è utilizzata per mostrare un elenco di pagine)
- Popovers (I popovers sono utilizzati per mostrare un contenuto in sovraimpressione)
- Progress (Il progress è utilizzato per mostrare un progresso)
- Scrollspy (Lo scrollspy è utilizzato per mostrare un elenco di link in base alla posizione dello scroll)
- Spinners (Gli spinner sono utilizzati per mostrare un caricamento)
- Toasts (I toasts sono utilizzati per mostrare un messaggio temporaneo)
- Tooltips (I tooltips sono utilizzati per mostrare un messaggio in sovraimpressione)

### Alerts
```html
<div class="alert alert-primary" role="alert">
  A simple primary alert—check it out!
</div>
```

### Badge
```html
<span class="badge bg-primary">Primary</span>
```

### Breadcrumb
```html
<nav aria-label="breadcrumb">
  <ol class="breadcrumb">
    <li class="breadcrumb
    -item"><a href="#">Home</a></li>
    <li class="breadcrumb-item"><a href="#">Library</a></li>
    <li class="breadcrumb-item active" aria-current="page">Data</li>
    </ol>
</nav>
```

### Buttons
```html
<button type="button" class="btn btn-primary">Primary</button>
```

### Button group
```html
<div class="btn-group" role="group" aria-label="Basic example">
  <button type="button" class="btn btn-secondary">Left</button>
  <button type="button" class="btn btn-secondary">Middle</button>
  <button type="button" class="btn btn-secondary">Right</button>
</div>
```

### Card
```html
<div class="card" style="width: 18rem;">
  <img src="..." class="card-img-top" alt="...">
  <div class="card-body">
    <h5 class="card-title">Card title</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
```

### Carousel
```html
<div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="..." class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="..." class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="..." class="d-block w-100" alt="...">
    </div>
  </div>
  <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Previous</span>
  </button>
  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="visually-hidden">Next</span>
  </button>
</div>
```

### Collapse
```html
<button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
  Link with href
</button>
<div class="collapse" id="collapseExample">
  <div class="card card-body">
    Some placeholder content for the collapse component. This panel is hidden by default but revealed when the user activates the relevant trigger.
  </div>
</div>
```

### Dropdowns
```html
<div class="dropdown">
  <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
    Dropdown button
  </button>
  <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <li><a class="dropdown-item" href="#">Action</a></li>
    <li><a class="dropdown-item" href="#">Another action</a></li>
    <li><a class="dropdown-item" href="#">Something else here</a></li>
  </ul>
</div>
```

### Forms
```html
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label
    ">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>
    <div class="mb-3">

    <label for="exampleInputPassword1" class="form-label
    ">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
    </div>
    <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

### Input group
```html
<div class="input-group mb-3">
  <span class="input-group-text" id="basic-addon1">@</span>
  <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1">
</div>
```

### List group
```html
<ul class="list-group">
  <li class="list-group-item">Cras justo odio</li>
  <li class="list-group-item">Dapibus ac facilisis in</li>
    <li class="list-group-item">Morbi leo risus</li>
    <li class="list-group-item">Porta ac consectetur ac</li>
    <li class="list-group-item">Vestibulum at eros</li>
</ul>
```

### Modal
```html
<!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
        </div>
        <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
        </div>
    </div>
    </div>
</div>
```

### Navs
```html
<nav>
  <div class="nav nav-tabs" id="nav-tab" role="tablist">
    <button class="nav-link active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Home</button>
    <button class="nav-link" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Profile</button>
    <button class="nav-link" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Contact</button>
  </div>
</nav>
<div class="tab-content" id="nav-tabContent">
  <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">...</div>
  <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">...</div>
  <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">...</div>
</div>
```

### Navbar
```html
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">Navbar</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Features</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Pricing</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled">Disabled</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
```

### Pagination
```html
<nav aria-label="Page navigation example">
  <ul class="pagination">
        <li class="page-item"><a class="page-link" href="#">Previous</a></li>
        <li class="page-item"><a class="page-link" href="#">1</a></li>
        <li class="page-item"><a class="page-link" href="#">2</a></li>
        <li class="page-item"><a class="page-link" href="#">3</a></li>
        <li class="page-item"><a class="page-link" href="#">Next</a></li>
    </ul>
</nav>

```

### Popovers
```html
<button type="button" class="btn btn-lg btn-danger" data-bs-toggle="popover" title="Popover title" data-bs-content="And here's some amazing content. It's very engaging. Right?">Click to toggle popover</button>
```

### Progress
```html
<div class="progress">
  <div class="progress-bar" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
</div>
```

### Scrollspy
```html
<body data-bs-spy="scroll" data-bs-target="#navbar-example2" data-bs-offset="0">
  <div id="navbar-example2">
    <nav class="navbar navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Navbar</a>
        <ul class="nav nav-pills">
          <li class="nav-item">
            <a class="nav-link" href="#scrollspyHeading1">First</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#scrollspyHeading2">Second</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#scrollspyHeading3">Third</a>
          </li>
        </ul>
      </div>
    </nav>
  </div>
  <div data-bs-spy="scroll" data-bs-target="#navbar-example2" data-bs-offset="0" tabindex="0">
    <h4 id="scrollspyHeading1">First heading</h4>
    <p>...</p>
    <h4 id="scrollspyHeading2">Second heading</h4>
    <p>...</p>
    <h4 id="scrollspyHeading3">Third heading</h4>
    <p>...</p>
  </div>
</body>
```

### Spinners
```html
<div class="spinner-border text-primary" role="status">
  <span class="visually-hidden">Loading...</span>
</div>
```

### Toasts
```html
<div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
  <div class="toast-header">
    <img src="..." class="rounded me-2" alt="...">
    <strong class="me-auto">Bootstrap</strong>
    <small>11 mins ago</small>
    <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
  </div>
  <div class="toast-body">
    Hello, world! This is a toast message.
  </div>
</div>
```

### Tooltips
```html
<button type="button" class="btn btn-secondary" data-bs-toggle="tooltip" data-bs-placement="top" title="Tooltip on top">
  Tooltip on top
</button>
```
## Bootstrap 5 - utilities
Bootstrap 5 offre una vasta gamma di utility classes che possono essere utilizzate per creare interfacce utente reattive e moderne.

Le utility classes disponibili sono:

- Borders (I bordi sono utilizzati per aggiungere bordi a un elemento)
- Clearfix (Il clearfix è utilizzato per pulire il float)
- Close icon (L'icona di chiusura è utilizzata per chiudere un elemento)
- Colors (I colori sono utilizzati per aggiungere colore a un elemento)
- Display (Il display è utilizzato per modificare il comportamento di visualizzazione di un elemento)
- Embed (L'embed è utilizzato per incorporare contenuti multimediali)
- Flex (Il flex è utilizzato per modificare il comportamento di layout di un elemento)
- Float (Il float è utilizzato per modificare il comportamento di posizionamento di un elemento)
- Image replacement (La sostituzione dell'immagine è utilizzata per sostituire un'immagine con un testo)
- Position (La posizione è utilizzata per modificare il comportamento di posizionamento di un elemento)
- Screenreaders (I lettori di schermo sono utilizzati per modificare il comportamento di visualizzazione di un elemento per i lettori di schermo)
- Shadows (Le ombre sono utilizzate per aggiungere ombre a un elemento)
- Sizing (Le dimensioni sono utilizzate per modificare le dimensioni di un elemento)
- Spacing (Lo spazio è utilizzato per aggiungere spazio a un elemento)
- Text (Il testo è utilizzato per modificare il comportamento di visualizzazione del testo)
- Vertical align (L'allineamento verticale è utilizzato per modificare il comportamento di allineamento verticale di un elemento)
- Visibility (La visibilità è utilizzata per modificare il comportamento di visualizzazione di un elemento)

### Borders
```html
<div class="border border-primary"></div>
```

### Clearfix
```html
<div class="clearfix"></div>
```

### Close icon
```html
<button type="button" class="btn-close" aria-label="Close"></button>
```

### Colors
```html
<div class="bg-primary"></div>
```

### Display
```html
<div class="d-flex"></div>
```

### Embed
```html
<iframe src="..." title="..."></iframe>
```

### Flex
```html
<div class="d-flex"></div>
```

### Float
```html
<div class="float-start"></div>
```

### Image replacement
```html
<h1 class="text-indent">Image replacement</h1>
```

### Position
```html
<div class="position-absolute"></div>
```

### Screenreaders
```html
<span class="visually-hidden">Hidden text</span>
```

### Shadows
```html
<div class="shadow"></div>
```

### Sizing
```html
<div class="w-100"></div>
```

### Spacing
```html
<div class="m-3"></div>
```

### Text
```html
<div class="text-center"></div>
```

### Vertical align
```html
<div class="align-items-center"></div>
```

### Visibility
```html
<div class="invisible"></div>
```

## Bootstrap 5 - unità di misura

rem (root em) - unità di misura relativa alla grandezza del carattere del root element es: 1rem = 16px
em - unità di misura relativa alla grandezza del carattere del parent element
% - unità di misura relativa alla grandezza del parent element
vw (viewport width) - unità di misura relativa alla larghezza del viewport
vh (viewport height) - unità di misura relativa all'altezza del viewport
px (pixel) - unità di misura assoluta
pt (point) - unità di misura assoluta
cm (centimeter
fr - unità di misura relativa alla grandezza del container es: 1fr = 1/3 del container
ch - unità di misura relativa alla grandezza del carattere "0" del font del root element

## Bootstrap 5 - colori

I colori di Bootstrap 5 sono definiti da una serie di classi predefinite che possono essere utilizzate per aggiungere colore a un elemento.

I colori disponibili sono:

- Primary (blu)
- Secondary (grigio)
- Success (verde)
- Danger (rosso)
- Warning (giallo)
- Info (azzurro)
- Light (grigio chiaro)
- Dark (grigio scuro)
- White (bianco)
- Muted (grigio chiaro)

Esempio di utilizzo di un colore:
```html
<div class="bg-primary"></div>
```

## Bootstrap 5 - tipografia

La tipografia di Bootstrap 5 è definita da una serie di classi predefinite che possono essere utilizzate per modificare il comportamento di visualizzazione del testo.

Le classi disponibili sono:

- Text color (Il colore del testo è utilizzato per modificare il colore del testo) `text-primary` `text-secondary` `text-success` `text-danger` `text-warning` `text-info` `text-light` `text-dark` `text-white` `text-muted`
- Text size (La dimensione del testo è utilizzata per modificare la dimensione del testo) `text-small` `text-normal` `text-large` `text-xl` `text-xxl` `text-xxxl`
- Text alignment (L'allineamento del testo è utilizzato per modificare l'allineamento del testo) `text-start` `text-center` `text-end` `text-justify`
- Text transformation (La trasformazione del testo è utilizzata per modificare la trasformazione del testo) `text-lowercase` `text-uppercase` `text-capitalize` `text-none`
- Text weight (Il peso del testo è utilizzato per modificare il peso del testo) `text-light` `text-normal` `text-bold` `text-bolder` `text-lighter`
- Text decoration (La decorazione del testo è utilizzata per modificare la decorazione del testo) `text-underline` `text-overline` `text-line-through` `text-none`
- Text wrapping (Il wrapping del testo è utilizzato per modificare il wrapping del testo) `text-wrap` `text-nowrap` `text-truncate`
- Text break (Il break del testo è utilizzato per modificare il break del testo) `text-break` `text-nowrap` `text-truncate`
- Text monospace (Il monospace del testo è utilizzato per modificare il monospace del testo) `text-monospace` `text-proportional`
- Text reset (Il reset del testo è utilizzato per ripristinare il comportamento predefinito del testo) `text-reset`

Esempio di utilizzo di una classe di tipografia:
```html
<div class="text-center"></div>
```

## Bootstrap 5 - immagini

Le immagini di Bootstrap 5 sono definite da una serie di classi predefinite che possono essere utilizzate per modificare il comportamento di visualizzazione delle immagini.

Le classi disponibili sono:

- Image shape (La forma dell'immagine è utilizzata per modificare la forma dell'immagine) `rounded` `circle` `thumbnail`
- Image size (La dimensione dell'immagine è utilizzata per modificare la dimensione dell'immagine) `img-fluid` `img-thumbnail`
- Image float (Il float dell'immagine è utilizzato per modificare il float dell'immagine) `float-start` `float-end` `float-none`
- Image thumbnail (Il thumbnail dell'immagine è utilizzato per mostrare un'immagine in formato thumbnail) `img-thumbnail`
- Image responsive (L'immagine responsive è utilizzata per rendere un'immagine reattiva) `img-fluid`
- Image rounded (L'immagine arrotondata è utilizzata per mostrare un'immagine con i bordi arrotondati) `rounded`

Esempio di utilizzo di una classe di immagine:
```html
<img src="..." class="img-fluid" alt="...">
```

## Bootstrap 5 - tabelle

Le tabelle di Bootstrap 5 sono definite da una serie di classi predefinite che possono essere utilizzate per modificare il comportamento di visualizzazione delle tabelle.

Le classi disponibili sono:

- Table color (Il colore della tabella è utilizzato per modificare il colore della tabella) `table-primary` `table-secondary` `table-success` `table-danger` `table-warning` `table-info` `table-light` `table-dark` `table-white`
- Table size (La dimensione della tabella è utilizzata per modificare la dimensione della tabella) `table-sm` `table-md` `table-lg`
- Table border (Il bordo della tabella è utilizzato per mostrare un bordo intorno alla tabella)
- Table striped (La tabella a righe alternate è utilizzata per mostrare le righe della tabella in modo alternato) `table-striped`
- Table hover (La tabella con hover è utilizzata per mostrare un effetto hover sulle righe della tabella) `table-hover`
- Table responsive (La tabella reattiva è utilizzata per rendere la tabella reattiva) `table-responsive`

Esempio di utilizzo di una classe di tabella:
```html
<table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">First</th>
      <th scope="col">Last</th>
      <th scope="col">Handle</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Mark</td>
      <td>Otto</td>
      <td>@mdo</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>Jacob</td>
      <td>Thornton</td>
      <td>@fat</td>
    </tr>
    <tr>
      <th scope="row">3</th>
      <td>Larry</td>
      <td>the Bird</td>
      <td>@twitter</td>
    </tr>
  </tbody>
</table>
```

## Bootstrap 5 - form

Le classi disponibili sono:

- Form color (Il colore del form è utilizzato per modificare il colore del form) `form-primary` `form-secondary` `form-success` `form-danger` `form-warning` `form-info` `form-light` `form-dark` `form-white`
- Form size (La dimensione del form è utilizzata per modificare la dimensione del form) `form-sm` `form-md` `form-lg`
- Form control (Il controllo del form è utilizzato per modificare il comportamento del controllo del form) `form-control`
- Form label (L'etichetta del form è utilizzata per modificare il comportamento dell'etichetta del form) `form-label`
- Form input (L'input del form è utilizzato per modificare il comportamento dell'input del form) `form-input`
- Form select (Il select del form è utilizzato per modificare il comportamento del select del form) `form-select`
- Form textarea (Il textarea del form è utilizzato per modificare il comportamento del textarea del form) `form-textarea`
- Form checkbox (Il checkbox del form è utilizzato per modificare il comportamento del checkbox del form) `form-checkbox`
- Form radio (Il radio del form è utilizzato per modificare il comportamento del radio del form) `form-radio`
- Form switch (Lo switch del form è utilizzato per modificare il comportamento dello switch del form) `form-switch`
- Form file (Il file del form è utilizzato per modificare il comportamento del file del form) `form-file`
- Form range (Il range del form è utilizzato per modificare il comportamento del range del form) `form-range`
- Form input group (Il gruppo di input del form è utilizzato per modificare il comportamento del gruppo di input del form) `form-input-group`
- Form floating label (L'etichetta fluttuante del form è utilizzata per modificare il comportamento dell'etichetta fluttuante del form) `form-floating-label`
- Form validation (La validazione del form è utilizzata per modificare il comportamento della validazione del form) `form-validation`
- Form layout (Il layout del form è utilizzato per modificare il comportamento del layout del form) `form-layout`
- Form grid (La griglia del form è utilizzata per modificare il comportamento della griglia del form) `form-grid`
- Form text (Il testo del form è utilizzato per modificare il comportamento del testo del form) `form-text`
- Form reset (Il reset del form è utilizzato per ripristinare il comportamento predefinito del form) `form-reset`

Esempio di utilizzo di una classe di form:
```html
<form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label ">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>
    <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label
    ">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1">
    </div>
    <div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```