# Struttura Generale della Landing Page

- Header con Hero Section

Un'immagine o illustrazione accattivante del tuo software.
Un titolo forte e un sottotitolo che descrivono brevemente il prodotto.
Un pulsante CTA (Call To Action) per incoraggiare l'utente a saperne di più o a provare il prodotto.

- Sezione delle Funzionalità

Elenca le caratteristiche principali del tuo software.
Usa icone per rappresentare visivamente ogni funzionalità.
Organizza le informazioni in colonne per una migliore leggibilità.

- Tabella di Comparazione con Cards

Crea cards che mettono a confronto diverse versioni o piani del tuo software.
Evidenzia il piano consigliato o più popolare.
Includi un pulsante CTA in ogni card per l'acquisto o l'iscrizione.
Progress Bars

Mostra statistiche o progressi relativi al tuo software (es. percentuale di utenti soddisfatti).
Utilizza le progress bars di Bootstrap per visualizzare questi dati in modo dinamico.
Testimonianze

Includi recensioni o feedback positivi da parte degli utenti.
Usa il componente Carousel di Bootstrap per far scorrere le testimonianze.
Footer

Inserisci informazioni di contatto, link ai social media e termini di servizio.
Esempio di Codice per la Hero Section
```html
<header class="bg-primary text-white text-center py-5">
  <div class="container">
    <h1>Benvenuto al Lancio di [Nome Software]</h1>
    <p class="lead">La soluzione definitiva per [descrizione breve].</p>
    <a href="#funzionalita" class="btn btn-light btn-lg">Scopri di più</a>
  </div>
</header>
```
Esempio di Cards per la Tabella di Comparazione
```html
<section id="piani" class="py-5">
  <div class="container">
    <h2 class="text-center">Scegli il tuo Piano</h2>
    <div class="row">
      <!-- Piano Base -->
      <div class="col-md-4">
        <div class="card mb-4 shadow-sm">
          <div class="card-header">
            <h4 class="my-0 fw-normal">Base</h4>
          </div>
          <div class="card-body">
            <h1 class="card-title pricing-card-title">€0 <small class="text-muted">/ mese</small></h1>
            <ul class="list-unstyled mt-3 mb-4">
              <li>Funzionalità limitate</li>
              <li>1 GB di spazio</li>
              <li>Supporto via email</li>
            </ul>
            <button type="button" class="w-100 btn btn-lg btn-outline-primary">Iscriviti gratis</button>
          </div>
        </div>
      </div>
      <!-- Piano Pro -->
      <!-- Aggiungi altre cards per gli altri piani -->
    </div>
  </div>
</section>
```
Esempio di Progress Bars
```html
<section id="statistiche" class="py-5 bg-light">
  <div class="container">
    <h2 class="text-center">Le Nostre Statistiche</h2>
    <div class="progress my-3">
      <div class="progress-bar" role="progressbar" style="width: 75%;" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100">75% Utenti Soddisfatti</div>
    </div>
    <!-- Aggiungi altre progress bars se necessario -->
  </div>
</section>
```
Responsività e Media Queries
Bootstrap 5 è già responsive per default, grazie al suo sistema di grid flessibile. Tuttavia, per personalizzazioni specifiche, puoi utilizzare le media queries CSS:

```css
@media (max-width: 768px) {
  .custom-class {
    /* Stili per dispositivi mobili */
  }
}
```
Assicurati che:

- Le immagini siano ottimizzate e utilizzino classi come .img-fluid per adattarsi allo schermo.
- I testi siano leggibili su schermi piccoli, eventualmente regolando le dimensioni dei font.
- I pulsanti e i link siano facilmente cliccabili su dispositivi touch.

Consigli Aggiuntivi

- Tipografia: Usa font chiari e moderni. Puoi integrare Google Fonts per una maggiore scelta.
- Colori: Mantieni una palette di colori coerente con il branding del tuo software.
- Animazioni: Utilizza le classi di animazione di Bootstrap o librerie come Animate.css per rendere la pagina più dinamica.
- Accessibilità: Aggiungi attributi aria-* dove necessario e assicurati che la pagina sia navigabile tramite tastiera.
- SEO: Utilizza tag meta per descrivere il tuo software e includi parole chiave rilevanti per il posizionamento sui motori di ricerca.

Aggiungere Bootstrap Icons

- Passo 1: Includere Bootstrap Icons nel tuo progetto

Puoi includere le Bootstrap Icons nel tuo progetto utilizzando un CDN (Content Delivery Network). Aggiungi il seguente link nella sezione `<head>` del tuo file HTML:

```html
<!-- Bootstrap Icons -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
```
Passo 2: Utilizzare le icone nella tua pagina

Per inserire un'icona, utilizza il tag `<i>` o `<span>` con la classe appropriata. Esempio:

```html
<i class="bi bi-star-fill"></i>
```
Puoi trovare l'elenco completo delle icone disponibili su Bootstrap Icons.

Aggiungere il Font Roboto

- Passo 1: Includere il font Roboto dal Google Fonts

Aggiungi il seguente link nella sezione `<head>` del tuo file HTML:

```html
<!-- Google Font Roboto -->
<link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap">
```
Passo 2: Applicare il font Roboto al tuo CSS

Nel tuo file CSS o all'interno dei tag `<style>`, imposta il font-family per l'intero documento o per elementi specifici:

```css
body {
    font-family: 'Roboto', sans-serif;
}
```
Aggiornamento degli Esempi di Codice

Esempio Completo della Hero Section con Icone e Font Roboto

```html
<!DOCTYPE html>
<html lang="it">
<head>
    <!-- Meta Tags -->
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Landing Page del Software</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
    <!-- Google Font Roboto -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap">
    <!-- Custom CSS -->
    <style>
        body {
            font-family: 'Roboto', sans-serif;
        }
        /* Altri stili personalizzati */
    </style>
</head>
<body>

<header class="bg-primary text-white text-center py-5">
    <div class="container">
        <h1><i class="bi bi-rocket-fill me-2"></i>Benvenuto al Lancio di <strong>Nome Software</strong></h1>
        <p class="lead">La soluzione definitiva per <em>descrizione breve</em>.</p>
        <a href="#funzionalita" class="btn btn-light btn-lg"><i class="bi bi-arrow-down-circle me-2"></i>Scopri di più</a>
    </div>
</header>

<!-- Resto del contenuto -->

<!-- Bootstrap JS -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
```
Aggiornamento delle Cards nella Tabella di Comparazione con Icone

```html
<section id="piani" class="py-5">
    <div class="container">
        <h2 class="text-center"><i class="bi bi-tags-fill me-2"></i>Scegli il tuo Piano</h2>
        <div class="row">
            <!-- Piano Base -->
            <div class="col-md-4">
                <div class="card mb-4 shadow-sm border-primary">
                    <div class="card-header text-center">
                        <h4 class="my-0 fw-normal"><i class="bi bi-star me-2"></i>Base</h4>
                    </div>
                    <div class="card-body">
                        <h1 class="card-title pricing-card-title text-center">€0 <small class="text-muted fw-light">/ mese</small></h1>
                        <ul class="list-unstyled mt-3 mb-4">
                            <li><i class="bi bi-check-circle-fill text-success me-2"></i>Funzionalità limitate</li>
                            <li><i class="bi bi-hdd-fill me-2"></i>1 GB di spazio</li>
                            <li><i class="bi bi-envelope-fill me-2"></i>Supporto via email</li>
                        </ul>
                        <button type="button" class="w-100 btn btn-lg btn-outline-primary">Iscriviti gratis</button>
                    </div>
                </div>
            </div>
            <!-- Piano Pro -->
            <div class="col-md-4">
                <div class="card mb-4 shadow-sm border-success">
                    <div class="card-header text-center">
                        <h4 class="my-0 fw-normal"><i class="bi bi-star-fill me-2"></i>Pro</h4>
                    </div>
                    <div class="card-body">
                        <h1 class="card-title pricing-card-title text-center">€29 <small class="text-muted fw-light">/ mese</small></h1>
                        <ul class="list-unstyled mt-3 mb-4">
                            <li><i class="bi bi-check-circle-fill text-success me-2"></i>Tutte le funzionalità base</li>
                            <li><i class="bi bi-hdd-network-fill me-2"></i>100 GB di spazio</li>
                            <li><i class="bi bi-telephone-fill me-2"></i>Supporto telefonico 24/7</li>
                        </ul>
                        <button type="button" class="w-100 btn btn-lg btn-success">Inizia Prova</button>
                    </div>
                </div>
            </div>
            <!-- Piano Enterprise -->
            <div class="col-md-4">
                <div class="card mb-4 shadow-sm border-warning">
                    <div class="card-header text-center">
                        <h4 class="my-0 fw-normal"><i class="bi bi-award-fill me-2"></i>Enterprise</h4>
                    </div>
                    <div class="card-body">
                        <h1 class="card-title pricing-card-title text-center">€99 <small class="text-muted fw-light">/ mese</small></h1>
                        <ul class="list-unstyled mt-3 mb-4">
                            <li><i class="bi bi-check-circle-fill text-success me-2"></i>Tutte le funzionalità Pro</li>
                            <li><i class="bi bi-cloud-fill me-2"></i>Spazio illimitato</li>
                            <li><i class="bi bi-people-fill me-2"></i>Account multiutente</li>
                        </ul>
                        <button type="button" class="w-100 btn btn-lg btn-warning">Contattaci</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
```
Aggiornamento delle Progress Bars con Font Roboto e Icone

```html
<section id="statistiche" class="py-5 bg-light">
    <div class="container">
        <h2 class="text-center"><i class="bi bi-graph-up-arrow me-2"></i>Le Nostre Statistiche</h2>
        <div class="progress my-3">
            <div class="progress-bar progress-bar-striped bg-success" role="progressbar" style="width: 85%;" aria-valuenow="85" aria-valuemin="0" aria-valuemax="100">
                85% Utenti Soddisfatti
            </div>
        </div>
        <div class="progress my-3">
            <div class="progress-bar progress-bar-striped bg-info" role="progressbar" style="width: 70%;" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100">
                70% Tasso di Crescita Annuale
            </div>
        </div>
        <div class="progress my-3">
            <div class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 90%;" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100">
                90% Clienti Raccomandano
            </div>
        </div>
    </div>
</section>
```
Responsività e Media Queries con Font e Icone

```css
@media (max-width: 768px) {
    h1 {
        font-size: 2rem;
    }
    .card-title {
        font-size: 1.5rem;
    }
    /* Altre personalizzazioni per dispositivi mobili */
}
```
Consigli Aggiuntivi

- Coerenza Visiva: Assicurati che le icone utilizzate siano coerenti tra loro e pertinenti al contenuto che rappresentano.
-  delle Prestazioni: Carica solo i pesi del font Roboto che utilizzi realmente (400, 500, 700) per migliorare i tempi di caricamento.
- Accessibilità: Le icone dovrebbero avere attributi aria-hidden="true" se sono puramente decorative, o essere accompagnate da testo alternativo per gli screen reader.

# HERO SECTION

la Hero Section si adatti sempre all'altezza e alla larghezza della finestra del browser, coprendo completamente lo schermo indipendentemente dalle dimensioni, possiamo utilizzare l'unità di misura CSS vh (viewport height). Impostando l'altezza della sezione al 100vh, la sezione occuperà sempre il 100% dell'altezza

Nella sezione style del tuo codice, aggiorna la classe .hero in questo modo:

```css
.hero {
    background: url('https://via.placeholder.com/1920x1080') center center/cover no-repeat;
    color: #fff;
    position: relative;
    height: 100vh; /* Aggiungi questa linea */
}
```