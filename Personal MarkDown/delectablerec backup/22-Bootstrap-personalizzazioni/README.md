# PERSONALIZZAZIONE BOOTSTRAP   
La personalizzazione avanzata di **Bootstrap** ti consente di creare un design unico senza rinunciare alla potenza del framework. Ecco una guida dettagliata su come personalizzare i colori e ogni aspetto grafico di Bootstrap:

per avere la priorita sugli stili di bootstrap bisogna inserire !important

```css
body {  
  font-family: 'Roboto', sans-serif !important;  
  font-size: 16px !important;  
  line-height: 1.5 !important;  
}
```
---

## **1\. Approccio Generale**

### **a) Metodi di personalizzazione**

1. **Sovrascrivere gli stili con CSS personalizzati**:  
   * Scrivi un file CSS separato che viene caricato dopo il file CSS di Bootstrap.  
   * Modifica solo le classi necessarie.  
2. **Personalizzare con SCSS** *(opzione avanzata e consigliata)*:  
   * Importa i file SCSS di Bootstrap.  
   * Sovrascrivi le variabili prima di importare i componenti.  
3. **Usare strumenti di personalizzazione online**:  
   * Bootstrap offre strumenti come [Bootstrap Customize](https://bootstrap.build/) per creare una versione personalizzata.

---

## **2\. Personalizzazione dei Colori**

### **a) Utilizzo delle variabili CSS**

Bootstrap usa **variabili CSS** per definire i colori principali (--bs-primary, --bs-secondary, ecc.). Puoi ridefinirle nel tuo file CSS:

```css
:root {  
  --bs-primary: #ff5733;   /* Colore principale */  
  --bs-secondary: #33c1ff; /* Colore secondario */  
  --bs-success: #28a745;   /* Colore per il successo */  
  --bs-info: #17a2b8;      /* Colore per informazioni */  
  --bs-warning: #ffc107;   /* Colore di avviso */  
  --bs-danger: #dc3545;    /* Colore per errori */  
  --bs-light: #f8f9fa;     /* Colore chiaro */  
  --bs-dark: #343a40;      /* Colore scuro */  
}

.btn-primary {  
  background-color: var(--bs-primary);  
  border-color: var(--bs-primary);  
  color: white;  
}
```

```html
<button class="btn btn-primary">Pulsante Personalizzato</button>
```

L'elemento :root è un **selettore CSS** che rappresenta l'elemento radice di un documento HTML. È particolarmente utile quando vuoi definire **variabili CSS globali** (anche chiamate "custom properties") accessibili in tutto il documento.

---

### **Differenza tra :root e html**

Sebbene :root abbia un comportamento simile al selettore html, :root ha una **specificità più alta**, il che significa che gli stili definiti con :root sovrascrivono quelli definiti per html in caso di conflitto.

---

### **3\. Supporto a Temi Dinamici**

Con :root, puoi facilmente implementare temi (ad esempio, modalità chiara/scura o colori personalizzati):

```css
:root {  
  --bs-warning: #ffc107; /* Modalità chiara */  
}

.dark-mode {  
  --bs-warning: #ff5722; /* Modalità scura */  
}
```

Con una sola classe (dark-mode), tutti i colori nel tuo tema si adatteranno automaticamente.

### **Consistenza nei Progetti Complessi**

In progetti grandi con molti componenti (pulsanti, alert, navbar, ecc.), le variabili CSS garantiscono che i colori siano sempre consistenti:

* Ad esempio, --bs-warning può essere usato sia per il colore di sfondo che per il bordo o il testo.  
* Eviti errori dove un componente ha un colore differente solo perché hai dimenticato di aggiornarlo.

### **Compatibilità con JavaScript**

Le variabili definite in :root possono essere facilmente modificate tramite JavaScript per creare funzionalità dinamiche.

Esempio di cambio dinamico del colore:

```javascript    
document.documentElement.style.setProperty('--bs-warning', '#ff5722');
```

Senza variabili CSS, dovresti manipolare direttamente le classi o creare nuovi stili.

---

### **b) Sovrascrivere classi specifiche**

Se vuoi personalizzare direttamente alcune classi, come i pulsanti o la navbar:

```css
.navbar {  
  background-color: #1a1a2e; /* Sfondo personalizzato */  
  color: white;  
}

.btn-primary {  
  background-color: #6a0572;  
  border-color: #6a0572;  
  color: white;  
}

.btn-primary:hover {  
  background-color: #44056e;  
  border-color: #44056e;  
}
```

---

### **c) Aggiungere nuovi colori**

Puoi estendere il sistema di colori aggiungendo variabili personalizzate:

```css
:root {  
  --bs-tertiary: #c700ff; /* Nuovo colore */  
}

.text-tertiary {  
  color: var(--bs-tertiary);  
}

.bg-tertiary {  
  background-color: var(--bs-tertiary);  
}
```

---

## **3\. Tipografia**

### **a) Personalizzare i font**

Possiamo usare i fonts di google inserendo il CDN relativo
    
```html
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
```

Bootstrap usa font-family predefiniti. Puoi sovrascrivere il font globale con una regola CSS:

```css
body {  
  font-family: 'Roboto', sans-serif; /* Usa Google Fonts */  
  font-size: 16px; /* Modifica la dimensione base */  
  line-height: 1.5; /* Modifica l'altezza delle righe */  
}
```

### **b) Modifica dei titoli**

Modifica i titoli specifici:

```css
h1, h2, h3, h4, h5, h6 {  
  font-family: 'Montserrat', sans-serif;  
  font-weight: bold;  
  color: #333;  
}
```

---

## **4\. Layout**

### **a) Personalizzare griglia**

Puoi modificare il comportamento della griglia (gutters, larghezze) usando SCSS o CSS:

#### **CSS**

```css
.container {  
  max-width: 1200px; /* Cambia larghezza massima */  
  padding-left: 15px;  
  padding-right: 15px;  
}

.row {  
  gap: 20px; /* Cambia distanza tra colonne */  
}
```

---

### **b) Navbar e header**

Per personalizzare completamente la navbar:

```css
.navbar {  
  background-color: #212529;  
  padding: 1rem;  
}

.navbar-brand {  
  font-size: 1.5rem;  
  font-weight: bold;  
  color: #ff5733;  
}

.nav-link {  
  color: #f8f9fa;  
  /* tolgo la sottolineatura */
  text-decoration: none;
}

.nav-link:hover {  
  color: #ff5733;  
}
```

---

## **5\. Componenti Personalizzati**

### **a) Modificare pulsanti**

Modifica lo stile dei pulsanti globalmente:

```css
.btn {  
  border-radius: 50px; /* Pulsanti arrotondati */  
  padding: 0.5rem 1.5rem;  
  font-size: 1rem;  
  text-transform: uppercase;  
}
```

---

### **b) Personalizzare modali**

Cambia l’aspetto dei modali:

```css
.modal-content {  
  background-color: #333;  
  color: white;  
  border-radius: 10px;  
}

.modal-header {  
  border-bottom: 1px solid #444;  
}

.modal-footer {  
  border-top: 1px solid #444;  
}
```

---

## **6\. Responsive ed Utilizzo di elementi responsivi**

Puoi usare beakpoints predefiniti come sm, md, lg, xl per definire regole specifiche per ogni dimensione dello schermo.

```css
/* Mobile (xs) */
.my-element {
  font-size: 14px;
}

/* Small (sm) */
@media (min-width: 480px) {
  .my-element {
    font-size: 16px;
  }
}

/* Medium (md) */
@media (min-width: 768px) {
  .my-element {
    font-size: 18px;
  }
}

/* Large (lg) */
@media (min-width: 1024px) {
  .my-element {
    font-size: 20px;
  }
}

/* Extra-large (xl) */
@media (min-width: 1440px) {
  .my-element {
    font-size: 22px;
  }
}
```

### **c) Testi responsive di Bootstrap**

Bootstrap fornisce classi di utilità come .fs-1, .fs-2, ecc., che puoi combinare con le classi responsive (.d-sm-block, .d-md-block) per creare font-size specifici per ogni breakpoint:

```html
<p class="fs-4 d-sm-block d-md-none">Testo per schermi piccoli</p>  
<p class="fs-2 d-none d-md-block d-lg-none">Testo per schermi medi</p>  
<p class="fs-1 d-none d-lg-block">Testo per schermi grandi</p>
```

In questo esempio:

* Su schermi **piccoli**, il paragrafo ha la classe fs-4.  
* Su schermi **medi**, il paragrafo usa fs-2.  
* Su schermi **grandi**, il paragrafo usa fs-1.

### **1. Configurare colonne per ogni breakpoint**

Bootstrap offre un sistema di griglia che ti permette di definire layout diversi per ogni breakpoint utilizzando le classi col-{breakpoint}-{numero}.

### **Esempio: Visualizzare colonne diverse a seconda del breakpoint**

```html  
<div class="container">  
  <div class="row">  
    <!-- Colonna che occupa tutta la riga su xs, metà su sm, un terzo su md -->  
    <div class="col-12 col-sm-6 col-md-4">Colonna 1</div>  
      
    <!-- Colonna che occupa metà su xs e sm, un quarto su md -->  
    <div class="col-6 col-sm-6 col-md-3">Colonna 2</div>  
      
    <!-- Colonna che è nascosta su xs, visibile su md e occupa metà della riga -->  
    <div class="d-none d-md-block col-md-6">Colonna 3</div>  
  </div>  
</div>
```

#### **Risultato:**

* **XS:** Colonna 1 e Colonna 2 occupano 100% della riga; Colonna 3 è nascosta.  
* **SM:** Colonna 1 e Colonna 2 occupano 50% della riga; Colonna 3 è nascosta.  
* **MD:** Colonna 1 (33%), Colonna 2 (25%) e Colonna 3 (50%) sono visibili.

---

### **2. Mostrare/Nascondere elementi con classi di visibilità**

Puoi usare le classi d-{breakpoint}-{value} per controllare la visibilità degli elementi in base ai breakpoint.

### **Esempio:**

```html  
<div class="d-block d-sm-none">Visibile solo su XS</div>  
<div class="d-none d-sm-block d-md-none">Visibile solo su SM</div>  
<div class="d-none d-md-block d-lg-none">Visibile solo su MD</div>  
<div class="d-none d-lg-block">Visibile solo su LG e superiori</div>
```

* **d-block:** Mostra l'elemento.  
* **d-none:** Nasconde l'elemento.

---

### **3. Personalizzare layout di colonne dinamiche**

Puoi creare layout fluidi e dinamici definendo il numero di colonne in base al breakpoint.

```html  
  <div class="container">  
  <div class="row">  
    <!-- Colonne dinamiche -->  
    <div class="col-12 col-sm-4 col-md-6 col-lg-4">Colonna 1</div>  
    <div class="col-12 col-sm-4 col-md-6 col-lg-8">Colonna 2</div>  
  </div>  
</div>
```

---

### **4. Controllare il comportamento del contenitore**

Puoi modificare la larghezza del contenitore in base ai breakpoint con classi specifiche.

```html  
<div class="container-sm">Contenitore piccolo</div>  
<div class="container-md">Contenitore medio</div>  
<div class="container-lg">Contenitore grande</div>  
<div class="container-xl">Contenitore extra-grande</div>
```

* **container:** Adatta automaticamente alle dimensioni dello schermo.  
* **container-fluid:** Larghezza 100% su tutti i breakpoint.

---

### **5. Cambiare l'ordine delle colonne per breakpoint**

Usa le classi di ordine per modificare la posizione delle colonne.

### **Esempio:**

```html  
<div class="row">  
  <div class="col-12 col-md-4 order-md-2">Colonna 1 (mostrata seconda su MD e superiori)</div>  
  <div class="col-12 col-md-8 order-md-1">Colonna 2 (mostrata prima su MD e superiori)</div>  
</div>
```

---

### **6. Allineamento e spaziature responsivi**

### **a) Spaziature**

Usa classi di margine e padding responsivi:

```html  
<div class="p-2 p-md-4">Padding diverso per xs (2) e md (4)</div>  
<div class="m-3 m-lg-5">Margine diverso per xs (3) e lg (5)</div>
```

### **b) Allineamento**

Puoi centrare o allineare gli elementi con classi di utilità:

```html  
<div class="text-start text-md-center text-xl-end">  
  Testo allineato a sinistra su xs, centrato su md, a destra su xl  
</div>
```

---

### **7. Griglie nidificate**

Puoi creare griglie nidificate per gestire layout complessi.

### **Esempio:**

```html  
<div class="container">  
  <div class="row">  
    <div class="col-md-6">  
      Prima colonna  
      <div class="row">  
        <div class="col-6">Subcolonna 1</div>  
        <div class="col-6">Subcolonna 2</div>  
      </div>  
    </div>  
    <div class="col-md-6">Seconda colonna</div>  
  </div>  
</div>
```

---

### **8. Controllare il wrapping delle colonne**

Il wrapping delle colonne è il comportamento predefinito di Bootstrap cioe quando non c'è più spazio, le colonne vengono spostate su una nuova riga.

Per prevenire o forzare il wrapping delle colonne, usa le classi flex-nowrap o flex-wrap.

### **Esempio:**

```html  
<div class="row flex-nowrap">  
  <div class="col-4">Colonna 1</div>  
  <div class="col-4">Colonna 2</div>  
  <div class="col-4">Colonna 3</div>  
</div>
```

---

### **Esempio Completo**

```html  
<div class="container">  
  <div class="row">  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3">Colonna 1</div>  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3">Colonna 2</div>  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-none d-md-block">Colonna 3</div>  
    <div class="col-12 col-sm-6 col-md-4 col-lg-3 d-none d-lg-block">Colonna 4</div>  
  </div>  
</div>
```

* **XS:** Tutte le colonne occupano l'intera larghezza.  
* **SM:** Due colonne per riga.  
* **MD:** Tre colonne per riga, la quarta nascosta.  
* **LG:** Quattro colonne per riga.

---

## **7\. Usare Bootstrap Icons**

Per aggiungere icone personalizzate, puoi usare Bootstrap Icons o qualsiasi altra libreria di icone:

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">  
<i class="bi bi-heart-fill"></i>
```

---

## **Personalizzare le icone con il CSS**

### **a) Cambiare dimensioni**

Puoi usare le classi di utilità predefinite di Bootstrap per controllare la dimensione delle icone:

```html
<i class="bi bi-alarm fs-1"></i> <!-- Grande -->  
<i class="bi bi-alarm fs-3"></i> <!-- Medio -->  
<i class="bi bi-alarm fs-5"></i> <!-- Piccolo -->
```

Oppure personalizzare direttamente nel CSS:

```css
.bi {  
  font-size: 24px; /* Personalizza dimensione */  
}

.custom-icon {  
  font-size: 40px; /* Classe personalizzata */  
}
```

Esempio nell'HTML:

```html
<i class="bi bi-alarm custom-icon"></i>  
```

# CHECK DEI REQUISITI

- [ ] Utilizzo delle variabili CSS attraverso il selettore :root
- [ ] Sovrascrittura delle classi di Bootstrap con !important
- [ ] Personalizzazione dei colori principali
- [ ] Supporto a temi dinamici
- [x] Modifica dei font e dei titoli
- [x] Personalizzazione della griglia e dei layout
- [x] Personalizzazione navbar e pulsanti
- [x] Typography con google fonts
- [x] Personalizzazione icone
- [x] Utilizzo dei mixin responsivi
- [x] Creazione di layout complessi con griglie nidificate
- [x] Utilizzo delle classi di visibilita
- [x] Allineamento e spaziature responsivi
- [x] Utilizzo di font responsive
- [x] Personalizzazione dei modali e di altri componenti

# CREAZIONE DELLE PAGINE DI UN ECOMMERCE SUPERMERCATO

- [x] Creazione della homepage con barra di navigazione, carousel e prodotti in evidenza e in offerta

La pagina dovra avere una barra di navigazione con i link alle varie pagine del sito web e un pulsante per effettuare il login. Inoltre, dovra contenere un'intestazione, una sezione di prodotti in evidenza (con un carousel o simili) e una sezione di prodotti in offerta oltre ad una selezione di prodotti generici in vetrina.

La pagina dovra avere i seguenti requisiti:

- [x] Utilizzo delle variabili CSS attraverso il selettore :root
- [x] Sovrascrittura delle classi di Bootstrap con !important
- [x] Personalizzazione dei colori principali
- [x] Supporto a temi dinamici
- [x] Modifica dei font e dei titoli usando i google fonts
- [x] Personalizzazione della griglia e dei layout
- [x] Personalizzazione navbar e pulsanti con inserimento icone di bootstrap in  pulsanti e componenti grafici
- [x] Utilizzo di font responsive
- [x] Personalizzazione dei modali e di altri componenti
- [x] Utilizzo di margin ed padding responsivi

Homepage.html

```html
<!DOCTYPE html>
<html lang="it">

<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Homepage Supermercato</title>
  <!-- collegamento a font roboto di google fonts e bootstrap -->
  <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet" />
  <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;700&display=swap" rel="stylesheet" />
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"
    integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
  <!-- link a css personalizzato -->
  <link rel="stylesheet" href="style.css" />
</head>

<body>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark shadow-sm">
    <div class="container">
      <a class="navbar-brand" href="#">SUPERMERCATO</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <a class="nav-link" href="#">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Prodotti</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Contatti</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Login</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">
              <span class="badge bg-primary" data-bs-toggle="offcanvas" data-bs-target="#staticBackdrop"
                aria-controls="staticBackdrop">3</span>
              <i class="bi bi-cart2"></i>
            </a>
          </li>
        </ul>
      </div>
    </div>
  </nav>
  <!-- offcanvas -->
  <div class="offcanvas offcanvas-start" data-bs-backdrop="static" tabindex="-1" id="staticBackdrop"
    aria-labelledby="staticBackdropLabel">
    <div class="offcanvas-header">
      <h5 class="offcanvas-title" id="staticBackdropLabel">Offcanvas</h5>
      <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body">
      <div>I will not close if you click outside of me.</div>
    </div>
  </div>

  <!-- section carousel -->
  <section class="container my-5">
    <div id="carouselExampleCaptions" class="carousel slide shadow-sm">
      <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active"
          aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1"
          aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2"
          aria-label="Slide 3"></button>
      </div>
      <div class="carousel-inner">
        <div class="carousel-item active">
          <!-- il color dark di bootstrap è #343a40 -->
          <img src="https://dummyimage.com/800x400/343a40/fff" class="d-block w-100" alt="..." />
          <div class="carousel-caption d-none d-md-block">
            <h5>First slide label</h5>
            <p>
              Some representative placeholder content for the first slide.
            </p>
          </div>
        </div>
        <div class="carousel-item">
          <img src="https://dummyimage.com/800x400/343a40/fff" class="d-block w-100" alt="..." />
          <div class="carousel-caption d-none d-md-block">
            <h5>Second slide label</h5>
            <p>
              Some representative placeholder content for the second slide.
            </p>
          </div>
        </div>
        <div class="carousel-item">
          <img src="https://dummyimage.com/800x400/343a40/fff" class="d-block w-100" alt="..." />
          <div class="carousel-caption d-none d-md-block">
            <h5>Third slide label</h5>
            <p>
              Some representative placeholder content for the third slide.
            </p>
          </div>
        </div>
      </div>
      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions"
        data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions"
        data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
  </section>
  <!-- nella versione sotto lg l header è nascosto -->
  <header class="text-center py-0 d-none d-lg-block">
    <div class="container my-5">
      <div class="row text-center">

          <!-- Card 2: Visa -->
          <div class="col-lg-3 col-md-6 mb-4">
              <div class="card h-100 border-1 shadow-sm">
                  <div class="card-body">
                      <i class="bi bi-credit-card-2-back-fill fs-1"></i>
                      <h5 class="card-title mt-3">Visa</h5>
                  </div>
              </div>
          </div>

          <!-- Card 3: MasterCard -->
          <div class="col-lg-3 col-md-6 mb-4">
              <div class="card h-100 border-1 shadow-sm">
                  <div class="card-body">
                      <i class="bi bi-credit-card-fill fs-1"></i>
                      <h5 class="card-title mt-3">MasterCard</h5>
                  </div>
              </div>
          </div>

          <!-- Card 4: American Express -->
          <div class="col-lg-3 col-md-6 mb-4">
              <div class="card h-100 border-1 shadow-sm">
                  <div class="card-body">
                      <i class="bi bi-bank fs-1"></i>
                      <h5 class="card-title mt-3">American Express</h5>
                  </div>
              </div>
          </div>

           <!-- Card 1: PayPal -->
           <div class="col-lg-3 col-md-6 mb-4">
            <div class="card h-100 border-1 shadow-sm">
                <div class="card-body">
                    <i class="bi bi-paypal fs-1"></i>
                    <h5 class="card-title mt-3">PayPal</h5>
                </div>
            </div>
        </div>
      </div>
  </div>
  </header>
  <!-- section card group 4 card per riga -->
  <section class="container my-5">
    <!-- stacco il titolo dalle card successive usando mb-5 -->
    <h2 class="mb-5 fs-1 d-none d-md-block">
      <i class="bi bi-cash-coin"></i> Prodotti in Promozione
    </h2>
    <div class="row row-cols-2 row-cols-md-2 row-cols-lg-4 g-4">
      <div class="col">
        <div class="card shadow-sm">
          <div class="card-header bg-primary text-light">Sconto 60%</div>
          <a href="#">
            <img src="https://dummyimage.com/300x200/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body">
            <h5 class="card-title">Prodotto 1</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text d-none d-md-block">Descrizione prodotto 1</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <div class="card-header bg-primary text-light">Sconto 20%</div>
          <a href="#">
            <img src="https://dummyimage.com/300x200/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body">
            <h5 class="card-title">Prodotto 2</h5>
            <p class="card-text d-none d-md-block">Descrizione prodotto 2</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <div class="card-header bg-primary text-light">Sconto 15%</div>
          <a href="#">
            <img src="https://dummyimage.com/300x200/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body">
            <h5 class="card-title">Prodotto 3</h5>
            <p class="card-text d-none d-md-block">Descrizione prodotto 3</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <div class="card-header bg-primary text-light">Sconto 10%</div>
          <a href="#">
            <img src="https://dummyimage.com/300x200/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body">
            <h5 class="card-title">Prodotto 4</h5>
            <p class="card-text d-none d-md-block">Descrizione prodotto 4</p>
          </div>
        </div>
      </div>
    </div>
  </section>
  <!-- sezione cartd group prodotti in evidenza 6 card per riga -->
  <section class="container my-5">
    <!-- stacco il titolo dalle card successive usando mb-5 -->
    <h2 class="mb-5 fs-4 d-sm-block d-md-none">
      <i class="bi bi-qr-code"></i> Prodotti in Evidenza
    </h2>
    <h2 class="mb-5 fs-2 d-none d-md-block d-lg-none">
      <i class="bi bi-qr-code"></i> Prodotti in Evidenza
    </h2>
    <h2 class="mb-5 fs-1 d-none d-lg-block">
      <i class="bi bi-qr-code"></i> Prodotti in Evidenza
    </h2>
    <div class="row row-cols-3 row-cols-md-3 row-cols-lg-3 row-cols-xl-6 g-4">
      <div class="col">
        <div class="card shadow-sm">
          <a href="#">
            <img src="https://dummyimage.com/150x100/343a40/fff" class="card-img-top position-relative" alt="..." />
            <span class="position-absolute translate-middle badge text-bg-primary"
              style="top: 0px; right: -22px">OFFERTA SPECIALE</span>
          </a>
          <div class="card-body d-none d-md-block">
            <!-- nella versione sotto md il nome è nascosto-->
            <h5 class="card-title">Prodotto 1</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text">Descrizione prodotto 1</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <a href="#">
            <img src="https://dummyimage.com/150x100/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body d-none d-md-block">
            <!-- nella versione sotto md il nome è nascosto-->
            <h5 class="card-title">Prodotto 2</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text">Descrizione prodotto 2</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <a href="#">
            <img src="https://dummyimage.com/150x100/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body d-none d-md-block">
            <!-- nella versione sotto md il nome è nascosto-->
            <h5 class="card-title">Prodotto 3</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text">Descrizione prodotto 3</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <a href="#">
            <img src="https://dummyimage.com/150x100/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body d-none d-md-block">
            <!-- nella versione sotto md il nome è nascosto-->
            <h5 class="card-title">Prodotto 4</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text">Descrizione prodotto 4</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <a href="#">
            <img src="https://dummyimage.com/150x100/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body d-none d-md-block">
            <!-- nella versione sotto md il nome è nascosto-->
            <h5 class="card-title">Prodotto 5</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text">Descrizione prodotto 5</p>
          </div>
        </div>
      </div>
      <div class="col">
        <div class="card shadow-sm">
          <a href="#">
            <img src="https://dummyimage.com/150x100/343a40/fff" class="card-img-top" alt="..." />
          </a>
          <div class="card-body d-none d-md-block">
            <!-- nella versione sotto md il nome è nascosto-->
            <h5 class="card-title">Prodotto 6</h5>
            <!-- nella versione sotto md la descrizione è nascosta-->
            <p class="card-text d-none d-md-block">Descrizione prodotto 6</p>
          </div>
        </div>
      </div>
    </div>
  </section>

<hr />

  <!-- sezione card group 4 card per riga con icone -->
  <!-- esempiuo di uso di Classe h-100 nelle card d-flex e align-items-stretch sulla riga -->

  <div class="container my-5">
    <div class="row text-center d-flex align-items-stretch">
      <!-- Card 1 -->
      <div class="col-lg-3 col-md-6 mb-4">
        <div class="card h-100 border-1 shadow-sm">
          <div class="card-body">
            <i class="bi bi-star-fill fs-1"></i>
            <h5 class="card-title mt-3">Trustpilot</h5>
            <p class="card-text">Vedi le recensioni</p>
          </div>
        </div>
      </div>

      <!-- Card 2 -->
      <div class="col-lg-3 col-md-6 mb-4">
        <div class="card h-100 border-1 shadow-sm">
          <div class="card-body">
            <i class="bi bi-truck fs-1"></i>
            <h5 class="card-title mt-3">Consegna Veloce</h5>
            <p class="card-text">
              Servizio di consegna veloce con corriere espresso in 24h
            </p>
          </div>
        </div>
      </div>

      <!-- Card 3 -->
      <div class="col-lg-3 col-md-6 mb-4">
        <div class="card h-100 border-1 shadow-sm">
          <div class="card-body">
            <i class="bi bi-shield-lock-fill fs-1"></i>
            <h5 class="card-title mt-3">Transazioni Sicure</h5>
            <p class="card-text">
              Acquista grazie ad un sistema di pagamento sicuro
            </p>
          </div>
        </div>
      </div>

      <!-- Card 4 -->
      <div class="col-lg-3 col-md-6 mb-4">
        <div class="card h-100 border-1 shadow-sm">
          <div class="card-body">
            <i class="bi bi-arrow-return-left fs-1"></i>
            <h5 class="card-title mt-3">Reso Sicuro</h5>
            <p class="card-text">
              Procedure semplici e pratiche per le restituzioni
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!-- footer -->

  <footer class="bg-dark text-white pt-5 pb-4">
    <div class="container">
      <div class="row">
        <!-- Colonna Contatti -->
        <div class="col-md-6 d-flex flex-column">
          <h6 class="text-uppercase fw-bold">Contatti</h6>
          <hr class="mb-4 mt-0" />
          <p class="mb-2">
            <i class="bi bi-geo-alt-fill me-2"></i> Milano, Italia
          </p>
          <p class="mb-2">
            <i class="bi bi-envelope-fill me-2"></i> info@example.com
          </p>
          <p><i class="bi bi-telephone-fill me-2"></i> +39 123 456 789</p>
        </div>

        <!-- Colonna Social -->
        <div class="col-md-6 d-flex flex-column">
          <h6 class="text-uppercase fw-bold">Seguici</h6>
          <hr class="mb-4 mt-0" />
          <div class="mb-4">
            <a href="#" class="text-white text-decoration-none me-3"><i class="bi bi-facebook fs-1"></i></a>
            <a href="#" class="text-white text-decoration-none me-3"><i class="bi bi-twitter fs-1"></i></a>
            <a href="#" class="text-white text-decoration-none me-3"><i class="bi bi-instagram fs-1"></i></a>
            <a href="#" class="text-white text-decoration-none"><i class="bi bi-linkedin fs-1"></i></a>
          </div>
        </div>
      </div>
      <hr class="mb-4 mt-0" />
    </div>

    <!-- Copyright -->
    <div class="text-center p-3">
      © 2024 Copyright:
      <a href="#" class="text-white text-decoration-none">TuoSitoWeb.com</a>
    </div>
  </footer>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"
    integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"
    crossorigin="anonymous"></script>
</body>

</html>
```