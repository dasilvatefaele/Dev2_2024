public class ProdottoCarrello
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Prezzo { get; set; }
    public int Quantita {get; set; }
    //public string Categoria { get; set; }
    public Categoria Categoria { get; set; }
    // public Dictionary<int,string> Categoria { get; set; }

//     private int id; // campo privato
//     private string nomeProdotto;  // campo privato
//     public int Id 
//     { 
//         get { return id; } 
//         set
//         {
//             if (value <= 0)
//             {
//                 throw new ArgumentException("Il valore dell'ID deve essere maggiore di zero.");
//             }
//             id = value; 
//         }
//     }
//     public string NomeProdotto 
//     { 
//         get { return nomeProdotto; }
//         set 
//         {
//             if (string.IsNullOrWhiteSpace(value))
//             {
//                 throw new ArgumentException("Il nome del prodotto non può essere vuoto.");
//             }
//             nomeProdotto = value;
//         } 
//     }
    
//     private decimal prezzoProdotto;  // campo privato
//     public decimal PrezzoProdotto 
//     { 
//         get {return prezzoProdotto;}
//         set 
//         {
//             if (value <= 0)
//             {
//                 throw new ArgumentException("Il prezzo deve essere maggiore di zero");
//             }
//             prezzoProdotto = value;
//         }
//     }
//     private int giacenzaProdotto;  // campo privato
//     public int GiacenzaProdotto 
//     { 
//         get { return giacenzaProdotto;}
//         set 
//         { 
//             if (value <= 0)
//             {
//                 throw new ArgumentException("La giacenza non può essere negativa");
//             }
//             giacenzaProdotto = value;
//         }
//     }
// 
}