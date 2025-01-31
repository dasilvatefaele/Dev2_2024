public class Solution 
{
    // Metodo per raggruppare gli anagrammi in sottoliste
    public List<List<string>> GroupAnagrams(string[] strs) 
    {
        // Dizionario per memorizzare gli anagrammi. La chiave è la versione ordinata della stringa,
        // il valore è una lista di stringhe che sono anagrammi.
        var res = new Dictionary<string, List<string>>();

        // Itera su ogni parola nell'array di input
        foreach (var word in strs)
        {
            // Converte la parola in un array di caratteri
            char[] sortedChar = word.ToCharArray();

            // Ordina i caratteri in ordine alfabetico
            Array.Sort(sortedChar);

            // Crea una stringa dai caratteri ordinati
            var sortedString = new string(sortedChar);

            // Se la chiave (stringa ordinata) non esiste nel dizionario, la aggiunge con una nuova lista vuota
            if (!res.ContainsKey(sortedString))
            {
                res[sortedString] = new List<string>();
            }

            // Aggiunge la parola originale (non ordinata) alla lista corrispondente alla chiave
            res[sortedString].Add(word);
        }

        // Converte i valori del dizionario (che sono liste di stringhe) in una lista di liste e la restituisce
        return res.Values.ToList<List<string>>();
    }
}
