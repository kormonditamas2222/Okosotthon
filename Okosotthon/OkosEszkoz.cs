using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;


        public OkosEszkoz(string azonosito, string nev)
        {
            this.azonosito = azonosito;
            this.nev = nev;
            OnlineE = false;
            UtolsoFrissites = DateTime.Now;
        }

        public string Azonosito { get => azonosito; private set => azonosito = value; }
        public string Nev { get => nev; private set => nev = value; }
        public bool OnlineE { get => onlineE; private set => onlineE = value; }
        public DateTime UtolsoFrissites { get => utolsoFrissites; protected set => utolsoFrissites = value; }

        public void Csatlakozas()
        {
            this.onlineE = true;
        }


        public void KapcsolatBontasa()
        {
            this.onlineE = false;
        }
        public bool DiagnosztikaFuttatasa()
        {
            if (this.onlineE)
            {
                return this.OnTesztFuttatasa();
            }
            return false;
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            Console.WriteLine($"{azonosito} - {nev} eszközön alapértelmezett beállítások visszaállítása.");
        }


        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();
    }
}
