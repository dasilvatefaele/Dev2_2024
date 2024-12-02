# INDOVINA NUMERO CON PERSISTENZA .CSV

## Obiettivo:

Implementare la persistenza dei dati in un file .csv unico tra tutti i giocatori chiamato `PartiteSalvate.csv`.

Il file conterrà nome giocatore, punteggio, numero di tentativi 

> struttura .csv
```
giocatore, punteggio,numero di tentativi

```
! NOTA: nel codice c# l'acapo `\n` va alla fine.

---

### Funzione aggiuntiva per la persistenza .csv:

```csharp
void SalvaTentativi(int sommaNumeroDiTentativi, string nomePlayer, int punteggio)
{
    string path = @"PartiteSalvate.csv";
    File.AppendAllText(path, $"{nomePlayer},{punteggio},{sommaNumeroDiTentativi}\n");
}
```