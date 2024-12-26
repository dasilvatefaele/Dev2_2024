using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

string s = "bbcc";
string t = "ccbc";

string test = t;

if (s.Length == t.Length) // check length
{
    for (int i = 0; i < s.Length; i++)
    {
        string c = s[i].ToString();
        int indexToRemove = test.IndexOf(c);
        if (indexToRemove != -1)
        {
            test = test.Remove(indexToRemove,1);
        }
    }
}
else if (s.Length != t.Length)
{
    Console.WriteLine("False");
    // return false;
}

if (string.IsNullOrEmpty(test))
{
    Console.WriteLine("True");
    // return true;
}

    //Console.WriteLine(test);
    //return false;

/*********************************************************/

