// See https://aka.ms/new-console-template for more information


//SHA-N , buscar libreria

using psp_fuerza_bruta;
using System;
using HilosParaTodos;

List<List<String>> Mitad(List<String> listPassword,int hilos)
{
    var paswordsForTh = listPassword.Count/hilos;
    
    var partsPasword = new List<List<String>>();

    for (int i = 0; i < hilos; i++)
    {
        partsPasword.Add(new List<String>());
        
        for (int j = 0; i < paswordsForTh; i++)
        {
            partsPasword[i].Add(listPassword.ElementAt(j));
        }
    }
    
    return partsPasword;
} 

Fichero fichero = new Fichero();
Wrapper<Action> wrapper = new Wrapper<Action>((() => {}));

var hashPassword = new HashPassword();

var listPassword = fichero.GetText();

Random random = new Random();

var paswords = Mitad(listPassword:listPassword,hilos: 2);

int randomNumber = random.Next(listPassword.Count);

var password = hashPassword.getHash(listPassword.ElementAt(randomNumber));

Ladron ladron1 = new Ladron("Fran", password, wrapper, paswords[0]);

Ladron ladron2 = new Ladron("Pepe", password, wrapper, paswords[1]);

ladron1.Start();
ladron2.Start();


