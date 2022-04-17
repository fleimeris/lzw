using System;
using System.Collections.Generic;
using System.Text;

// Benas Mykolaitis PRIFS19/4

namespace Lzw
{
    public class Lzw
    {
        public Lzw()
        {
        }
        
        public List<int> Kompresuoti(string nekompresuotas)
        {
            var zodynas = new Dictionary<string, int>();
            var uzkompresuotas = new List<int>();
            var dabartinisSimbolis = "";
    
            // sudaromas zodynas su visais ASCII simboliais, deja bet CP775 koduote nepalaikoma ant dotnet 6
            for (var i = 0; i < 256; i++)
            {
                zodynas.Add(((char)i).ToString(), i);
            }
    
            // ciklas, kuris paima nesukompresuota string po viena simboli
            foreach (var sekantisSimbolis in nekompresuotas)
            {
                var simboliuJungtis = dabartinisSimbolis + sekantisSimbolis;
    
                // tikrinama ar simboliu jungtis yra zodyne, jei yra tai dabartiniam simboliui yra priskiriama
                // simboliu jungtis
                if (zodynas.ContainsKey(simboliuJungtis))
                {
                    dabartinisSimbolis = simboliuJungtis;
                }
                else // jei nera, tai prie uzkompresuoto saraso pridedamas dabartinis simbolis
                     // taip pat prie zodyno yra pridedama simboliu jungtis
                {
                    uzkompresuotas.Add(zodynas[dabartinisSimbolis]);
                    zodynas.Add(simboliuJungtis, zodynas.Count);
                    dabartinisSimbolis = sekantisSimbolis.ToString();
                }
            }
    
            if (dabartinisSimbolis != null || dabartinisSimbolis != "")
                uzkompresuotas.Add(zodynas[dabartinisSimbolis]);
    
            Console.WriteLine("Uzkompresuota simboliu seka");
            foreach (var simbolis in uzkompresuotas)
            {
                Console.Write(simbolis < 256 ? $"{(char)simbolis} " : $"{simbolis} ");
            }
            
            Console.WriteLine("\nZodynas");
            foreach (var zodynoValue in zodynas)
            {
                Console.WriteLine($"{zodynoValue.Value} -> {zodynoValue.Key}");
            }
            
            return uzkompresuotas;
        }

        public string Atkompresuoti(List<int> kompresuotiDuomenys)
        {
            var zodynas = new Dictionary<int, string>();
            var dabartinisSimbolis = "";

            // sudaromas zodynas su visais ASCII simboliais, deja bet CP775 koduote nepalaikoma ant dotnet 6
            for (var i = 0; i < 256; i++)
            {
                zodynas.Add(i, ((char)i).ToString());
            }
            
            dabartinisSimbolis = zodynas[kompresuotiDuomenys[0]];
            kompresuotiDuomenys.RemoveAt(0);

            var atkoduotiDuomenys = dabartinisSimbolis;

            // ciklas, kuris paima sukompresuota string po viena simboli
            foreach (var sekantisSimbolis in kompresuotiDuomenys)
            {
                var simbolis = "";

                // tikrinama ar sekantis simbolis yra zodyne, jei taip simboliui yra priskiriamas sekantis simbolis
                if (zodynas.ContainsKey(sekantisSimbolis))
                    simbolis = zodynas[sekantisSimbolis];
                else if (sekantisSimbolis == zodynas.Count)
                    simbolis = dabartinisSimbolis + dabartinisSimbolis[0];

                // simbolis yra pridedamas prie atkoduotu duomenu sekos
                atkoduotiDuomenys += simbolis;
                
                // prie zodyno pridedamas dabartinis simbolis ir simbolis
                zodynas.Add(zodynas.Count, dabartinisSimbolis + simbolis[0]);

                dabartinisSimbolis = simbolis;
            }

            Console.WriteLine(atkoduotiDuomenys);

            Console.WriteLine("\nZodynas");
            foreach (var zodynoValue in zodynas)
            {
                Console.WriteLine($"{zodynoValue.Key} -> {zodynoValue.Value}");
            }

            return atkoduotiDuomenys;
        }
    }
}