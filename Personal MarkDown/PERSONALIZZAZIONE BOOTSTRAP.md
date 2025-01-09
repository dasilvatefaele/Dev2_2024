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

## **6\. Responsive ed Utilizzo dei mixin responsivi**

Con i mixin di Bootstrap, puoi definire regole personalizzate per breakpoint specifici:

```css
h1 {  
  font-size: 24px;

  @include media-breakpoint-up(sm) {  
    font-size: 28px;  
  }

  @include media-breakpoint-up(md) {  
    font-size: 32px;  
  }

  @include media-breakpoint-up(lg) {  
    font-size: 36px;  
  }  
}
```

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
    <div class="col-12 col-sm-8 col-md-6 col-lg-4">Colonna 1</div>  
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
