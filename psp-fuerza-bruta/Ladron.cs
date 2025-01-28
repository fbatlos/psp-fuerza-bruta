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
    bool finished = false;
    
    public Ladron(String nombre, string passwordHash, Wrapper<Action> finishEvent, List<String> palabras)
    {
        this.passwordHash = passwordHash;
        this.nombre = nombre;
        //Con global crea una copia !
        this.finishEvent = finishEvent;
        finishEvent.Value += () => { finished = true;};
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
            if (finished)
            {
             break;       
            }
            
            if (passwordHash == hash.getHash(palabra))
            {
                finishEvent.Value.Invoke();
                Console.WriteLine("Ladron: " + nombre + " ha solucionado la contraseña: "+passwordHash+". "+"La password era: " + hash.getHash(palabra));
                break;
            }
        }
    }
}