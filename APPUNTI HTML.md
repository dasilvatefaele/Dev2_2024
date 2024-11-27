# HTML 5

L'HTML 5 è dinamico, a differenza dell'HTML normale.

Incorpora componenti aggiuntivi come:
- Il canvas permette di inserire delle grafiche vettoriali (.svg)
- base di dati (.txt, .json)

W3C è un organismo che da direttive/standard che i produttori dei browser vanno a rispettare.
(https://www.w3schools.com/html/default.asp)

> Il nostro obiettivo 2024 è il `mobile-first`, dal momento che la maggior parte degli utenti usano siti da dispositivi mobile.

Dev'essere tutto relativo e non assoluto, come riferimento l'elemento che lo contiene.


## APPUNTI FLEXBOX FROGGY:
 
`justify-content`

- `flex-start`: Allinea gli elementi alla sinistra del contenitore.
- `flex-end`: Allinea gli elementi alla destra del contenitore.
- `center`: Allinea gli elementi al centro del contenitore.
- `space-between`: Separa gli elementi con uguale spazio tra di loro.
- `space-around`: Separa gli elementi con uguale spazio attorno ad essi.
---

`align-items`

- `flex-start`: Allinea gli elementi all'inizio del loro contenitore.
- `flex-end`: Allinea gli elementi alla fine del loro contenitore.
- `center`: Centra gli elementi verticalmente.
- `baseline`: Gli elementi vengono disposti in modo da allineare le loro linee di base.
- `stretch`: Gli elementi sono allungati per occupare tutto il contenitore.
---

`flex-direction`

- `row`: Gli elementi sono posizionati nella stessa direzione del testo.
- `row-reverse`: Gli elementi sono posizionati nella direzione opposta al testo.
- `column`: Gli elementi sono posizionati dall'alto verso il basso.
- `column-reverse`: Gli elementi sono posizionati dal basso verso l'alto.

---


# Media Query più utilizzate

- 576px: dispositivi mobili (max-width)
- 768px: tablet (min-width: 577px) and (max-width: 768px)
- 992px
- 1400px
- da 1400px (min-width: 1401px;)

---
# Best practice CSS

```css
* {
    margin: 0;
    padding:0;
    box-sizing: border-box;
}
```

# DIVISIONE DEL BODY

```html
<body>
    <header>
        <nav>
            <ul>
                <li><a href="#">esempio<a></li>
                <li><a href="#">esempio<a></li>
                <li><a href="#">esempio<a></li>
                <li><a href="#">esempio<a></li>
            </ul>
        </nav>
    </header>

    <main>
        <!-- HERO PAGE - <section> con CALL TO ACTION - 100% viewport -->
        <!-- DIV INTERNI-->
        <!-- DIV INTERNI-->
        <!-- DIV INTERNI-->
        <!-- DIV INTERNI-->
    </main>

    <footer>
        <!-- DIV INTERNI-->
    </footer>
</body>
```
---
# ATTRIBUTI PERSONALIZZATI CSS

`:nth-child(n)` - selettore dove `n` è l'indice dell'oggetto box (1 è il primo, 2 è il secondo, 3 è il terzo e così via)

```css

.box{
    display: flex;
}

.box:nth-child(1){
    flex: 1;
}

.box:nth-child(2){
    flex: 1.5;
}

.box:nth-child(3){
    flex: 2;
}
```