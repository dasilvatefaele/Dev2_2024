/*

OPERATORI:

- aritmetici
- di confronto
- logici
- di assegnazione
- di incremento e decremento

*/ 

//pulisce la console
Console.Clear();    

/*******************************************************/
//      OPERATORI ARITMETICI
/*******************************************************/
int a = 10;
int b = 20;
int c = a + b; // + , - , * , /

Console.WriteLine(c); // 30

//  modulo - restituisce il resto di una divisione
//  (esempio se var%2 = 0, allora var è pari)

c = b % a;

Console.WriteLine(c);
/*******************************************************/
//      OPERATORI DI CONFRONTO : Restituisce un bool
/*******************************************************/

int f = 10;
int g = 20;
bool h = f == g;
Console.WriteLine(h);

bool i = f != g;
Console.WriteLine(i);

// > , >= , <, <=. ==, !=
/*******************************************************/
//      OPERATORI LOGICI : Restituisce un bool
/*******************************************************/

bool p = true;
bool q = false;

// AND - True se ENTRAMBE una è True  
bool r = p && q; 
Console.WriteLine(r);

// OR - True se ALMENO una è True  
r = p || q;
Console.WriteLine(r);


//NOT - Opposto
r = !r;
Console.WriteLine(r);

// && , || , !

/*******************************************************/
//      OPERATORI DI ASSEGNAZIONE
/*******************************************************/

int u = 10;
u += 1;
Console.WriteLine(u);

// += , -=, *= , /=

/*******************************************************/
//      OPERATORI DI INCREMENTO/DECREMENTO
/*******************************************************/

int v = 10;
v++;

// ++, --
Console.WriteLine(v);

/*******************************************************/
//      OPERATORI DI CONCATENAZIONE : stringhe 
/*******************************************************/

string w = "ciao ";
string x = "mondo";
string y = w + x;

Console.WriteLine(y);

