// See https://aka.ms/new-console-template for more information

using Lzw = Lzw.Lzw;

var lzv = new global::Lzw.Lzw();

var zodis = "Geri vyrai geroj girioj gera gira gere ir gerdami gyre: geriems vyrams geroj girioj gera gira gera gert.";

var ats = lzv.Kompresuoti(zodis);

var dekoduotas = lzv.Atkompresuoti(ats);

if(zodis == dekoduotas)
    Console.WriteLine("\n Zodziai sutampa");
