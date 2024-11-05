Console.Clear();
string[] nomePartecipante = new string [8];
Random random = new Random();
int estrai;

nomePartecipante [0] = "Andrea";
nomePartecipante [1] = "Anita";
nomePartecipante [2] = "Diego";
nomePartecipante [3] = "Felipe";
nomePartecipante [4] = "Giorgio";
nomePartecipante [5] = "Ivan";
nomePartecipante [6] = "Sofia";
nomePartecipante [7] = "Tamer";

estrai = random.Next(0,8);

Console.WriteLine($"Il computer ha estratto... {nomePartecipante[estrai]}!");