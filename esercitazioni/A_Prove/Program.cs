
Console.Clear();

//! MAIN
var provaDizionario = new Dictionary<string, int>
{
    {"default", 0},
};
bool provaBooleana = false;

Console.WriteLine("***************************");
Console.WriteLine("PRE Funzioni:");
foreach(var elementi in provaDizionario)
{
    Console.WriteLine(elementi);
}
Console.WriteLine(provaBooleana);

ModificaDizionario(provaDizionario);
ModificaBooleana(provaBooleana);

Console.WriteLine("***************************");
Console.WriteLine("POST Funzioni:");
foreach(var elementi in provaDizionario)
{
    Console.WriteLine(elementi);
}
Console.WriteLine(provaBooleana);


//! FUNZIONI

void ModificaDizionario (Dictionary<string, int> b)
{
    b["aggiunta"] = 1;
    //Console.WriteLine(b["default"]);
}

void ModificaBooleana (bool c)
{
    c = true;
}