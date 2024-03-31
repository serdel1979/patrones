// See https://aka.ms/new-console-template for more information
using Singleton.Singleton;

Console.WriteLine("Ingresa algo...");

string txt = Console.ReadLine();

if (txt != null)
{
    Log.Instance.Save(txt);
}
