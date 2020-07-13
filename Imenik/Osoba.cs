using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik
{
    class Osoba
    {
        private string Ime;
        private string Prezime;
        private string brojT;
        public Osoba(string i, string p, string brT)
        {
            Ime = i;
            Prezime = p;
            brojT = brT;
        }
        public void setIme(string i) {
            Ime = i;
        }
        public string getIme()
        {
            return Ime;
        }
        public void setPrezime(string p)
        {
            Prezime = p;

        }
        public string getPrezime()
        {
            return Prezime;
        }
        public void setBrojT(string brT)
        {
            brojT = brT;
        }
        public string getBrojT()
        {
            return brojT;
        }
    }
}
