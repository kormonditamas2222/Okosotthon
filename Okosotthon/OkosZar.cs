using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosZar: OkosEszkoz
    {
        private string pinKod;
        bool zartE;

        public OkosZar(string azonosito, string nev, string pinKod)
        : base(azonosito, nev)
        {
            this.pinKod = pinKod;
            this.zartE = true;
        }

        public bool ZartE { get => zartE; private set => zartE = value; }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("NYITAS") && parancs.Split(":").Length == 2)
            {
                string megadottPinKod = parancs.Split(":")[1];
                if (megadottPinKod == this.pinKod)
                {
                    this.zartE = false;
                }
            }
            if (parancs == "ZARAS")
            {
                this.zartE = true;
            }
        }


        public override string AllapotJelentes()
        {
            if (zartE)
            {
                return "ZÁRVA";
            }
            return "NYITVA";
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.pinKod = "0000";
            this.zartE = true;
        }
    }
}
