using System.Runtime.InteropServices.JavaScript;
using HilosParaTodos;

namespace psp_fuerza_bruta;

public class Ladron
{
    Thread hilo;
    private String nombre;
    string passwordHash;
    private List<String> palabras;
    Wrapper<Action> finishEvent;
    HashPassword hash = new HashPassword();
    
    public Ladron(String nombre, string passwordHash, Wrapper<Action> finishEvent, List<String> palabras)
    {
        this.passwordHash = passwordHash;
        this.nombre = nombre;
        //Con global crea una copia !
        this.finishEvent = finishEvent;
        this.palabras = palabras;
        hilo = new Thread(_process);
    }

    public void Start()
    {
        hilo.Start();
    }

    void _process()
    {
        foreach (var palabra in palabras)
        {
            if (passwordHash == hash.getHash(palabra) )
            {
                Console.WriteLine("Ladron: " + nombre + " ha solucionado la contraseña."+"La password era : " + palabra);
                break;
            }
            else
            {
                Console.WriteLine("Error: Password.");
            }
        }
    }
}