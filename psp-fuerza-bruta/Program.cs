using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using HilosParaTodos;
using psp_fuerza_bruta;

class Program
{
    static void Main()
    {
        Fichero fichero = new Fichero();
        var hashPassword = new HashPassword();
        var listPassword = fichero.GetText().Where(p => !string.IsNullOrEmpty(p)).ToList();
        Random random = new Random();
        int randomNumber = random.Next(listPassword.Count);
        var password = hashPassword.getHash(listPassword.ElementAt(randomNumber));
        int numHilos = 1;
        try
        {
            Console.Write("Cuantos hilos quieres: ");
            numHilos = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Ha introducido un número o carácter no válido, se realizará la prueba con 1 hilo.");
            throw;
        }
        
        
        bool encontrada = false;
        Wrapper<Action> wrapper = new Wrapper<Action>(() => {encontrada = true;});
        
        List<Ladron> ladrones = new List<Ladron>();
        
        
        for (int i = 0; i < numHilos; i++)
        {
            var partesPasswords = listPassword.GetRange(randomNumber, numHilos);
            ladrones.Add(new Ladron($"Ladron_{i + 1}", password, wrapper, partesPasswords));
        }
        Stopwatch stopwatch = Stopwatch.StartNew();
        foreach (var ladron in ladrones)
        {
            ladron.Start();
        }
        
        while (!encontrada) { } 

        stopwatch.Stop();
        Console.WriteLine($"Tiempo total: {stopwatch.ElapsedMilliseconds} ms");
    }
    
}