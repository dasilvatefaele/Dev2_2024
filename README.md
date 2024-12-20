# Dev2_2024

#### APPUNTI AL VOLO

## Classi

Modello che rende disponibile all'applicazione una serie di attributi (es. prezzo, nome, codice). 

#### STRUTTURA:
- Classe:
    - attributo1
    - attributo2
    - attributo3
    - metodo1 (funzione incapsulata)
    - metodo2 (funzione incapsulata)

#### ESEMPI:

- Prodotto:
    - nomeProdotto
    - prezzoUnitario
    - giacenzaMagazzino 
    - StampaProdotto(); (funzione incapsulata)
    - ModificaProdotto(); (funzione incapsulata)

- Cliente:
    - nome
    - cognome
    - indirizzo
    - email
    - telefono

---
Uno dei vantaggi del modello classe è la modularità. 

**NOTA:** 

Se inseriamo le classi nel nostro Program.cs il codice principale necessita di un `entry point`.

Una volta creata la classe, per utilizzarne i metodi serve istanziarne un oggetto.

> Esempio: 

```c#
class Program
{
    static void Main (string[] args)  // <--- Entry Point
    {
        Pokemon pokemon = new Pokemon(); // <--- Creazione dell'oggetto pokemon

        Console.WriteLine($"{pokemon.nome} usa {pokemon.attacco}");
    }
}

public class Pokemon // <--- Definizione Classe di un oggetto
{
    public string nome = "Pikachu";
    public string attacco = "Elettroshock!";
}
```

