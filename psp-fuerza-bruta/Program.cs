// See https://aka.ms/new-console-template for more information


//SHA-N , buscar libreria

using psp_fuerza_bruta;
using System;
using HilosParaTodos;

Fichero fichero = new Fichero();
Wrapper<Action> wrapper = new Wrapper<Action>((() => {}));

var hashPassword = new HashPassword();

var listPassword = fichero.GetText();

Random random = new Random();

int randomNumber = random.Next(listPassword.Count);

var password = hashPassword.getHash(listPassword.ElementAt(randomNumber));

Ladron ladron1 = new Ladron("Fran", password, wrapper, listPassword);

ladron1.Start();






