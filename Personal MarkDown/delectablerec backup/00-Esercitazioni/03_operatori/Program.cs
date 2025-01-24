// OPERATORI
/*
i tipi di operatori principali sono:
- aritmetici
- di confronto
- logici
- di assegnazione
- di incremento e decremento
- di concatenazione
*/

// ESEMPIO DI OPERATORI ARITMETICI
// pulisce la console
Console.Clear();
// esempio di operatori aritmetici
int a = 10;
int b = 20;
int c = a + b; // somma
// stampo il risultato
Console.WriteLine(c); // 30
// esempio di modulo
int d = 10 % 3; // 1
Console.WriteLine(d);
// esempio capire se un numero e pari o dispari
int e = 10 % 2; // 0
Console.WriteLine(e); // 0

// ESEMPIO DI OPERATORI DI CONFRONTO
int f = 10;
int g = 20;
bool h = f == g; // false
Console.WriteLine(h);
bool i = f != g; // true
Console.WriteLine(i);
bool l = f > g; // false
Console.WriteLine(l);
bool m = f < g; // true
Console.WriteLine(m);
bool n = f >= g; // false
Console.WriteLine(n);
bool o = f <= g; // true
Console.WriteLine(o);

// ESEMPIO DI OPERATORI LOGICI
bool p = true; // true
bool q = false; // false
bool r = p && q; // false

// && (AND) - restituisce true se entrambe le condizioni sono vere
Console.WriteLine(r);
bool s = p || q; // true
// || (OR) - restituisce true se almeno una delle condizioni è vera
Console.WriteLine(s);
bool t = !p; // false
// ! (NOT) - restituisce il contrario del valore
Console.WriteLine(t);

// ESEMPIO DI OPERATORI DI ASSEGNAZIONE
int u = 10;
u += 5; // u = u + 5
Console.WriteLine(u); // 15
u -= 5; // u = u - 5
Console.WriteLine(u); // 10

// ESEMPIO DI OPERATORI DI INCREMENTO E DECREMENTO
int v = 10;
v++; // v = v + 1
Console.WriteLine(v); // 11
v--; // v = v - 1
Console.WriteLine(v); // 10

// ESEMPIO DI OPERATORI DI CONCATENAZIONE
string w = "ciao";
string x = " mondo";
string y = w + x;
Console.WriteLine(y); // ciao mondo