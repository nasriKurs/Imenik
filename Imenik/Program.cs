using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Imenik
{
    class Program
    {
        static List<Osoba> Imenik = new List<Osoba>();

        static void Main(string[] args)
        {
            bool izlaz = false;
            UcitajIzFajla();
            while (true)
            {
                Console.WriteLine("-------------IMENIK----------------");
                Console.WriteLine("MENI--> 1. Dodaj novi kontakt, 2. Prikazi sve kontakte, 3. Pretrazi kontakte, 4. Izmeni kontakt, 5. Obrisi odredjeni kontakt, 6.Izadji iz aplikacije");
                string izbor = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                switch (izbor)
                {
                    case "1":
                        Dodaj();
                        break;
                    case "2":
                        Prikaz();
                        break;
                    case "3":
                        Pretraga();
                        break;
                    case "4":
                        Izmena();
                        break;
                    case "5":
                        Brisanje();
                        break;
                    case "6":
                        Sacuvaj();
                        izlaz = true;
                        break;
                    default:
                        Console.WriteLine("Pogresna opcija");
                        break;
                }
                if (izlaz)
                    break;
            }
            
           
        }
        static void Dodaj()
        {
            Console.WriteLine("-------DODAVANJE NOVOG KONTAKTA-------");
            string brojT;
            string ime;
            string prezime;
            while (true)
             {
                bool postojiOsoba = false;
                Console.Write("Unesite broj telefona: ");
                brojT = Console.ReadLine();
                foreach (Osoba o in Imenik)
                {
                    if (brojT == o.getBrojT())
                    {
                        Console.WriteLine("Postoji kontakt sa ovim brojem, molimo Vas dodajte neki drugi broj!");
                        postojiOsoba = true;
                        break;
                    }
                }
                if (postojiOsoba)
                    continue;
                break;
             }
            while (true)
            {
                Console.Write("Unesite ime: ");
                ime = Console.ReadLine();
                if (ime.Count() == 0)
                {
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Unesite prezime: ");
                prezime = Console.ReadLine();
                if (prezime.Count() == 0)
                {
                    continue;
                }
                break;
            }
            Imenik.Add(new Osoba(ime,prezime,brojT));
            Console.WriteLine("Kontakt je uspesno dodat!");
            Console.WriteLine("Da li zelite da dodate jos neki kontakt D/N");
            string izbor = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            if ( izbor.ToUpper() == "D")
            {
                Console.WriteLine();
                Dodaj();
            }

        }
        static void Prikaz()
        {
            Console.WriteLine("-------Prikaz imenika-------");
            if(Imenik.Count == 0)
            {
                Console.WriteLine("Trenutno nema dodat niti jedan kontakt");
                return;
            }
            Console.WriteLine("Ime ----- Prezime ----- Broj telefona");
            foreach(Osoba o in Imenik)
            {
                Console.WriteLine($"{o.getIme()}-----{o.getPrezime()}-----{o.getBrojT()}");

            }
        }
        static void Pretraga()
        {
            Console.WriteLine("OPCIJA JE U TOKU IZRADE!!");

        }
       
        static void Izmena()
        {
            Prikaz();
            Console.WriteLine("----------Izmena kontakta-----------");
            bool ima = false;
            int index = -1;
            while (true)
            {
                Console.Write("Unesite broj telefona, kako biste izmenili taj kontakt: ");
                string brojTelefona = Console.ReadLine();
                foreach (Osoba o in Imenik)
                {
                    index++;
                    if (brojTelefona == o.getBrojT())
                    {
                        ima = true;
                        break;
                    }
                }
                if (!ima)
                {
                    Console.WriteLine("Uneti broj se ne poklapa sa nijednim u imeniku!");
                    index = -1;
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (index != -1)
            {
                Console.WriteLine("Da li zelite da promenite ime? D/N ");
                string izbor = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                if (izbor.ToUpper() == "D")
                {
                    Console.Write($"Staro ime je: {Imenik[index].getIme()} Unesite novo ime: ");
                    string ime = Console.ReadLine();
                    Imenik[index].setIme(ime);
                    Console.WriteLine("Ime je uspesno promenjeno!");
                }
                Console.Write("Da li zelite da promenite prezime? D/N ");
                izbor = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                if (izbor.ToUpper() == "D")
                {
                    Console.Write($"Staro prezime je: {Imenik[index].getPrezime()} Unesite novo prezime: ");
                    string prezime = Console.ReadLine();
                    Imenik[index].setPrezime(prezime);
                    Console.WriteLine("Prezime je uspesno promenjeno!");
                }
                
                Console.Write("Da li zelite da promenite broj? D/N ");
                izbor = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                string broj;
                if (izbor.ToUpper() == "D")
                {
                    
                    while (true)
                    {
                        bool provera = false;
                        Console.Write($"Stari broj je: {Imenik[index].getBrojT()} Unesite novi broj: ");
                        broj = Console.ReadLine();
                        foreach (Osoba o in Imenik)
                        {
                            if (o.getBrojT() == broj)
                            {
                                provera = true;
                                break;

                            }
                        }
                        if (provera)
                        {
                            Console.WriteLine("UNETI BROJ VEC POSTOJI!!");
                            continue;
                        }
                        break;
                    }
                    Imenik[index].setBrojT(broj);
                    Console.WriteLine("Broj je uspesno promenjen!");
                }
            }

        }
        
        static void Brisanje()
        {
            Prikaz();
            Console.WriteLine("----------Brisanje kontakta------------");
            bool ima = false;
            int index = -1;
            while (true)
            {
                Console.Write("Unesite broj telefona, kako biste obrisali taj kontakt: ");
                string brojTelefona = Console.ReadLine();
                foreach (Osoba o in Imenik)
                {
                    index++;
                    if (brojTelefona == o.getBrojT())
                    {
                        ima = true;
                        break;
                    }
                }
                if (!ima)
                {
                    Console.WriteLine("Uneti broj se ne poklapa sa nijednim u imeniku!");
                    index = -1;
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (index != -1)
            {
                Console.WriteLine("Da li ste sigurni da zelite da obrisete dati kontakt? D/N");
                string izbor = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                if (izbor.ToUpper() == "D")
                {
                    Imenik.RemoveAt(index);
                    Console.WriteLine("KONTAKT JE USPESNO OBRISAN!");
                }
            }
        }
        static void UcitajIzFajla()
        {
            if (File.Exists("imenik.txt"))
            {
                foreach (string kont in File.ReadLines("imenik.txt"))
                {
                    string[] kontakt = kont.Split(';');
                    Imenik.Add(new Osoba(kontakt[0], kontakt[1], kontakt[2]));
                }

            }
        }
        static void Sacuvaj()
        {
            File.WriteAllText("imenik.txt", "");
            foreach(Osoba o in Imenik)
            {
                File.AppendAllText("imenik.txt", $"{o.getIme()};{o.getPrezime()};{o.getBrojT()}" + Environment.NewLine);
            }
        }
    }
}
