using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_lab2
{
    class Pilkarz
    {
        private string imie;
        private string nazwisko;
        private int wiek;
        private double waga;

        public Pilkarz(Pilkarz p)
        {
            this.imie = p.imie;
            this.nazwisko = p.nazwisko;
            this.wiek = p.wiek;
            this.waga = p.waga;
        }

        public Pilkarz(string imie = "imie", string nazwisko = "nazwisko", int wiek = 18, double waga = 50)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
            this.waga = waga;
        }

        public override string ToString()
        {
            StringBuilder napis = new StringBuilder();
            napis.Append("Imię: ");
            napis.Append(this.imie);
            napis.Append(" ");
            napis.Append(this.nazwisko);
            napis.Append(" Wiek: ");
            napis.Append(this.wiek);
            napis.Append(" Waga: ");
            napis.Append(this.waga);

            return napis.ToString();
        }

        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
            }
        }
        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }
            set
            {
                nazwisko = value;
            }
        }
        public int Wiek
        {
            get
            {
                return wiek;
            }
            set
            {
                wiek = value;
            }
        }
        public double Waga
        {
            get
            {
                return waga;
            }
            set
            {
                waga = value;    
            }
        }
    }
}
