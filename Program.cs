using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");

            switch (Console.ReadLine())
            {
                case "1":
                    Utente.Login();
                    break;
                case "2":
                    Utente.Logout();
                    break;
                case "3":
                    Utente.VerificaLogin();
                    break;
                case "4":
                    Utente.StampaAccessi();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey();
        }
    }
}

static class Utente
{
    private static string username;
    private static bool autenticato = false;
    private static DateTime ultimoLogin;
    private static List<DateTime> storicoAccessi = new List<DateTime>();

    public static void Login()
    {
        Console.WriteLine("Inserisci username:");
        string usr = Console.ReadLine();
        Console.WriteLine("Inserisci password:");
        string pwd = Console.ReadLine();
        Console.WriteLine("Conferma password:");
        string confPwd = Console.ReadLine();

        if (!string.IsNullOrEmpty(usr) && pwd == confPwd)
        {
            username = usr;
            autenticato = true;
            ultimoLogin = DateTime.Now;
            storicoAccessi.Add(ultimoLogin);
            Console.WriteLine("Login effettuato con successo.");
        }
        else
        {
            Console.WriteLine("Errore di autenticazione.");
        }
    }

    public static void Logout()
    {
        if (autenticato)
        {
            autenticato = false;
            Console.WriteLine("Logout effettuato con successo.");
        }
        else
        {
            Console.WriteLine("Nessun utente autenticato.");
        }
    }

    public static void VerificaLogin()
    {
        if (autenticato)
        {
            Console.WriteLine($"L'ultimo login è stato effettuato il {ultimoLogin}");
        }
        else
        {
            Console.WriteLine("Nessun utente autenticato.");
        }
    }

    public static void StampaAccessi()
    {
        if (storicoAccessi.Count == 0)
        {
            Console.WriteLine("Nessun accesso registrato.");
        }
        else
        {
            Console.WriteLine("Storico accessi:");
            foreach (var accesso in storicoAccessi)
            {
                Console.WriteLine(accesso);
            }
        }
    }
}
