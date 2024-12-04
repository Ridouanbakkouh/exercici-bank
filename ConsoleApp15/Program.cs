namespace ConsoleApp15;
using System;
using System.Collections.Generic;

public class Client
{
    public string nom { get; private set; }
    public double Saldo { get; private set; }

    public Client(string nom, double saldoInicial = 0)
    {
        nom= nom;
        Saldo = saldoInicial;
    }

    
    public void Ingressar(double quantitat)
    {
        if (quantitat > 0)
        {
            Saldo += quantitat;
            Console.WriteLine($"S'ha ingressat {quantitat} al compte de {nom}. Saldo actual: {Saldo}");
        }
        else
        {
            Console.WriteLine("La quantitat  positiva.");
        }
    }

    
    public void Retirar(double quantitat)
    {
        double comissio = quantitat * 0.01;
        double quantitatTotal = quantitat + comissio;  

        if (quantitatTotal <= Saldo)
        {
            Saldo -= quantitatTotal;
            Console.WriteLine($"S'ha retirat {quantitat} (més una comissió de {comissio:F2}) del compte de {Nom}. Saldo actual: {Saldo}");
        }
        else
        {
            Console.WriteLine($"Operació denegada. No tens prou saldo per retirar {quantitat}. Saldo actual: {Saldo}");
        }
    }

    // Mètode per mostrar el saldo actual
    public void MostrarSaldo()
    {
        Console.WriteLine($"Saldo del compte de {Nom}: {Saldo}");
    }
}

public class Banc
{
    private Dictionary<string, Client> clients;

    public Banc()
    {
        clients = new Dictionary<string, Client>();
    }

    // Afegeix un client al banc
    public void AfegirClient(Client client)
    {
        if (!clients.ContainsKey(client.Nom))
        {
            clients.Add(client.Nom, client);
            Console.WriteLine($"Client {client.Nom} afegit al banc.");
        }
        else
        {
            Console.WriteLine($"El client {client.Nom} ja existeix.");
        }
    }

    // Obté un client pel seu nom
    public Client ObtenirClient(string nom)
    {
        if (clients.ContainsKey(nom))
        {
            return clients[nom];
        }
        else
        {
            Console.WriteLine($"El client {nom} no existeix.");
            return null;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Crear el banc
        Banc banc = new Banc();

        // Crear clients
        Client client1 = new Client("Joan", 1000);
        Client client2 = new Client("Anna", 500);

        // Afegir clients al banc
        banc.AfegirClient(client1);
        banc.AfegirClient(client2);

        // Mostrar saldo inicial
        client1.MostrarSaldo();
        client2.MostrarSaldo();

        // Ingressar diners
        client1.Ingressar(200);

        // Intentar retirar diners
        client1.Retirar(300);  // Correcte, amb comissió
        client2.Retirar(600);  // Error, saldo insuficient

        // Mostrar saldo final
        client1.MostrarSaldo();
        client2.MostrarSaldo();
    }
}

    