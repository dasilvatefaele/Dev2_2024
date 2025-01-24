# UTILIZZO MD

il  linguaggio di markup (in inglese, markup language) è un insieme di regole che descrivono i meccanismi di rappresentazione di un testo che, utilizzando convenzioni standardizzate, sono utilizzabili su più supporti.

Il linguaggio di markup è un linguaggio formale che utilizza convenzioni standardizzate per la marcatura di un testo in modo da associare significato semantico a porzioni di esso. È spesso utilizzato per la formattazione di documenti testuali in modo da renderli più espressivi e facilmente interpretabili, ma può anche essere utilizzato, come nel caso dell'HTML, per definire la struttura logica di un documento e la sua formattazione.

> Installare estensione GitHub Markdown Preview

# Titolo principale
## Sottotitolo 1
### Titolo paragrafo
#### Sottotitolo paragrafo
---

> esempio di quote (citazione)

esempio di __grassetto__ o **bold**

esempio di _italic_

# esempio di elenco puntato
---
- primo
    - sottoelenco
- secondo
    - sottoelenco
- terzo
- quarto
- quinto

# esempio di elenco numerato
---
1. primo
2. secondo
3. terzo
    1. quarto
    2. quinto
        1. sesto
        2. settimo
        3. ottavo
            1. nono
            2. decimo
            3. Undicesimo

## esempio di check
- [x] sddsfsdsf
- [ ] primo
- [ ] secondo
- [x] terzo

# Esempio di codice
```
git status
git add
git commit
```


```c# 
class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("Hello World!");
    }
}

/*
note per i collaboratori
*/
```

```sql
CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                    CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT,
                    prezzo REAL, quantita INTEGER CHECK (quantita >= 0), id_categoria INTEGER,
                    FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                    INSERT INTO categorie (nome) VALUES ('categoria1'), ('categoria2'), ('categoria3');
                    INSERT INTO prodotti (nome, prezzo, quantita, id_categoria) VALUES ('prodotto1', 1, 10, 1), ('prodotto2', 2, 20, 2), ('prodotto3', 3, 30, 3);
```

**esempio di link relativo**

[link a pagina 2](02_link.md)

[link a pagina web](https://www.google.com)

[link a pagina 3 dentro la sub](/Esercitazioni/02_md/subfolder/03_link.md)

[link ad una section del documento](#esempio-di-elenco-puntato)

<!-- Commento che non compare nel render markdown -->

| Syntax | Description |
| ----------- | ----------- |
| Header | Title |
| Paragraph | ![esempio di SVG di svg repo]|



<font color="red">Testo scritto in rosso!</font>

### Sezioni

<details>

<summary>Tips for collapsed sections</summary>

### You can add a header

You can add text within a collapsed section. 

You can add an image or a code block, too.

```ruby
   puts "Hello World"
```

</details>
Here is a simple flow chart:

` esempio di mark con i backtick `

<mark>gedfgdfg</mark>

<mark style=" background:red">gedfgdfg</mark>

## GRAFICI MERMAID

https://mermaid.js.org/
https://jojozhuang.github.io/tutorial/mermaid-cheat-sheet/

## FLOWCHART BASIC

```mermaid
graph TD;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
```

## FLOWCHART BASIC

```mermaid
graph LR
    A[Square Rect] -- Link text --> B((Circle))
    A --> C(Round Rect)
    B --> D{Rhombus}
    C --> D
```

## FLOWCHART WITH DECISION

```mermaid
graph TD
    A[Christmas] -->|Get money| B(Go shopping)
    B --> C{Let me think}
    C -->|One| D[Laptop]
    C -->|Two| E[iPhone]
    C -->|Three| F[fa:fa-car Car]
```

# FLOWCHART DATA

```mermaid
erDiagram
    CUSTOMER ||--o{ ORDER : places
    CUSTOMER {
        string name
        string custNumber
        string sector
    }
    ORDER ||--|{ LINE-ITEM : contains
    ORDER {
        int orderNumber
        string deliveryAddress
    }
    LINE-ITEM {
        string productCode
        int quantity
        float pricePerUnit
    }
```

## GRAFICI GANTT

```mermaid

gantt
    title A Gantt Diagram
    dateFormat  YYYY-MM-DD
    section Section
    First Task       :a1, 2018-07-01, 30d
    Another Task     :after a1, 20d
    section Another
    Second Task      :2018-07-12, 12d
    Third Task       : 24d

```

```mermaid

gantt
       dateFormat  YYYY-MM-DD
       title Adding GANTT diagram functionality to mermaid

       section A section
       Completed task            :done,    des1, 2018-01-06,2018-01-08
       Active task               :active,  des2, 2018-01-09, 3d
       Future task               :         des3, after des2, 5d
       Future task2              :         des4, after des3, 5d

       section Critical tasks
       Completed task in the critical line :crit, done, 2018-01-06,24h
       Implement parser and jison          :crit, done, after des1, 2d
       Create tests for parser             :crit, active, 3d
       Future task in critical line        :crit, 5d
       Create tests for renderer           :2d
       Add to mermaid                      :1d

       section Documentation
       Describe gantt syntax               :active, a1, after des1, 3d
       Add gantt diagram to demo page      :after a1  , 20h
       Add another diagram to demo page    :doc1, after a1  , 48h

       section Last section
       Describe gantt syntax               :after doc1, 3d
       Add gantt diagram to demo page      :20h
       Add another diagram to demo page    :48h

```