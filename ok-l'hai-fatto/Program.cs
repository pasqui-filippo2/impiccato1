// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;

bool verifica = false;
bool ricomincia = false;
int tentativi = 5;
int cercaL = 0, conta = 0, partite = 0;
char[] lettere = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'z' };
string Psecret = "", lettereUsate = "", paroleErrate = "", paroleGiuste = "";
Random rnd = new Random();






while (ricomincia == false)
{
    partite++;

    string filePath = "1st-level.txt.txt"; // Nome del file CSV 

    string[] lines = File.ReadAllLines(filePath); // Legge tutte le righe e le mette in un vettore
    int random = rnd.Next(1, lines.Length - 1);
    Psecret = lines[random];
    char[] secret = new char[Psecret.Length];
    lettereUsate = "";

    Console.WriteLine("| SE VUOI USCIRE DAL GIOCO DIGITA 'esci' | SE VUOI GIOCARE DIGITA 'gioca");
    string risposta = Console.ReadLine();
    if (risposta == "esci")
    {
        ricomincia = true;
    }
    if(risposta =="gioca")
    {
        Console.WriteLine("E' stata generata una nuova parola");
    }
    

    Console.WriteLine("A quale difficoltà vuoi giocare?");
    Console.WriteLine("1 - Modalità Facile");
    Console.WriteLine("2 - Modalità Intermedia");
    Console.WriteLine("3 - Modalità Difficile ");
    int scelta1 = Int32.Parse(Console.ReadLine());
    if (scelta1 == 1)
    {
        Console.WriteLine("Modalità facile:");
        Console.WriteLine("Due lettere visibili");
        Console.WriteLine("7 tentativi a disposizione");
        tentativi = 7;


    }
    if (scelta1 == 2)
    {
        Console.WriteLine("Modalità intermedia:");
        Console.WriteLine("Una lettere visibili");
        Console.WriteLine("6 tentativi a disposizione");
        tentativi = 6;

    }
    if (scelta1 == 3)
    {
        Console.WriteLine("Modalità facile:");
        Console.WriteLine("Zero lettere visibili");
        Console.WriteLine("5 tentativi a disposizione");
        tentativi = 5;
    }
    Console.WriteLine(trasforma_parola(Psecret, lettere, scelta1,secret));




    while (tentativi > 0)
    {
        
        Console.WriteLine("Vuoi indovinare la parola(1) o scegliere una lettere(2)");

        int scelta = Int32.Parse(Console.ReadLine());
        if (scelta == 2)
        {
            Console.WriteLine("Dammi la lettera");
            char lett = Console.ReadLine()[0];
            if (Psecret.Contains(lett))
            {
                for (int i = 0; i < Psecret.Length; i++)
                {
                    if (Psecret[i] == lett)
                    {
                        secret[i] = lett;


                    }

                }

            }
            else
            {
                tentativi--;
                lettereUsate += lett + ", ";

                Console.WriteLine("Hai sbagliato");
                Console.WriteLine("Tentativi a disposizione: " + tentativi);
                Console.WriteLine("Lettere usate usate: " + lettereUsate);
                if (tentativi == 0)
                {
                    Console.WriteLine("La parola era " + Psecret);
                    paroleErrate += Psecret + " ";
                }

            }

            Console.WriteLine(secret);
            cercaL = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                for (int j = 0; j < lettere.Length; j++)
                {
                    if (secret[i] == lettere[j])
                    {
                        cercaL++;
                    }
                }
            }
            if (cercaL == secret.Length)
            {
                verifica = true;
            }
            if (verifica == true)
            {
                Console.WriteLine("//Hai indovinato la parola//");
                paroleGiuste += Psecret + " ";
                tentativi = 0;
            }

        }



        if (scelta == 1)
        {
            Console.WriteLine("Dammi la parola");
            string parola = Console.ReadLine();
            if (Psecret.Contains(parola))
            {
                Console.WriteLine("Hai indovinato la parola");
                verifica = true;
            }
            else
            {
                Console.WriteLine("Hai sbagliato");
            }
            if (verifica == true)
            {
                tentativi = 0;
                paroleGiuste += Psecret + " ";
            }
        }

    }
}
Console.WriteLine("- PARTITE GIOCATE ----> " + partite);
Console.WriteLine("- PAROLE INDOVINATE ----> " + paroleGiuste);
Console.WriteLine("- PAROLE ERRATE ----> " + paroleErrate);
Console.WriteLine("- PUNTEGGIO OTTENUTO ---->");

char[] trasforma_parola(string parola, char[] lett, int scelta, char[] secret)
{
    Random rnd = new Random();
    int month = rnd.Next(1, Psecret.Length - 1);
    if (scelta == 1)
    {
        for (int i = 0; i < parola.Length; i++)
        {
            for (int j = 0; j < lettere.Length; j++)
            {

                if (Psecret[i] == lettere[j])
                {
                    if (i == 0)
                    {
                        secret[i] = lettere[j];

                    }
                    else if (i == month)
                    {
                        secret[i] = lettere[j];
                    }
                    else
                    {
                        secret[i] = '_';
                    }

                }


            }
        }
        return secret;
    }
    if (scelta == 2)
    {
        for (int i = 0; i < Psecret.Length; i++)
        {
            for (int j = 0; j < lett.Length; j++)
            {

                if (Psecret[i] == lettere[j])
                {
                    if (i == month)
                    {
                        secret[i] = lettere[j];
                    }
                    else
                    {
                        secret[i] = '_';
                    }

                }


            }
        }
        return secret;
    }
    if (scelta == 3)
    {
        for (int i = 0; i < Psecret.Length; i++)
        {
            for (int j = 0; j < lett.Length; j++)
            {

                if (Psecret[i] == lett[j])
                {
                    secret[i] = '_';
                }
            }
        }
        return secret;
    }
    return secret;
}