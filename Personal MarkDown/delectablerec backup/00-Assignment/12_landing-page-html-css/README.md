# Landing page
## Obiettivo

Creazione di una landing page con HTML e CSS.
La pagina (landing page resume CV) deve contenere:

- un'intestazione con il nome e il cognome
- un menu con i link alle sezioni della pagina (Home, About me, Skills, Portfolio, Contact)
- le varie sezioni con le informazioni personali, le competenze, il portfolio e i contatti
- un footer con il copyright ed i loghi social

## Specifiche

- La pagina deve avere un design responsive
- La pagina deve avere un file CSS associato
- la pagina deve contenere i google fonts
- la pagina deve contenere qualche icona fontawesome o google o bootstrap icons
- la pagina deve contenere una unica `call to action` (CTA) ben visibile

# Versione 1

```html
<!DOCTYPE html>
<html lang="it">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Landing Page</title>
    <link rel="stylesheet" href="style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
</head>

<body>
    <header>
        <h1>Nome Cognome</h1>
        <nav>
            <ul>
                <li><a href="#home">Home</a></li>
                <li><a href="#about">About me</a></li>
                <li><a href="#skills">Skills</a></li>
                <li><a href="#portfolio">Portfolio</a></li>
                <li><a href="#contact">Contact</a></li>
            </ul>
        </nav>
    </header>

    <main>
        <section id="home">
            <h2>Home</h2>
            <p>Informazioni personali</p>
        </section>

        <section id="about">
            <h2>About me</h2>
            <p>Informazioni personali</p>
        </section>

        <section id="skills">
            <h2>Skills</h2>
            <p>Competenze</p>
        </section>

        <section id="portfolio">
            <h2>Portfolio</h2>
            <p>Progetti</p>
        </section>

        <section id="contact">
            <h2>Contact</h2>
            <p>Contatti</p>
        </section>
    </main>

    <footer>
        <p>&copy; 2024 Nome Cognome</p>
        <div>
            <a href="#"><i class="fab fa-facebook"></i></a>
            <a href="#"><i class="fab fa-twitter"></i></a>
            <a href="#"><i class="fab fa-linkedin"></i></a>
        </div>
    </footer>
</body>
</html>
```

```css
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Roboto', sans-serif;
}

header {
    background-color: #333;
    color: #fff;
    padding: 1rem;
    text-align: center;
}

nav ul {
    list-style: none;
    display: flex;
    justify-content: center;
    gap: 1rem;
}

nav a {
    color: #fff;
    text-decoration: none;
}

main {
    padding: 1rem;
}

section {
    margin: 2rem 0;
}

footer {
    background-color: #333;
    color: #fff;
    text-align: center;
    padding: 1rem;
}

footer div {
    margin-top: 1rem;
}

footer a {
    color: #fff;
    text-decoration: none;
    margin: 0 0.5rem;
}
```