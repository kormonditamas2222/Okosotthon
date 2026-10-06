using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class Termosztat : OkosEszkoz
    {
        double jelenlegiHomerseklet;
        double celHomerseklet;

        public Termosztat(string azonosito, string nev, double celHomerseklet)
        : base(azonosito, nev)
        {
            this.celHomerseklet = celHomerseklet;
            this.jelenlegiHomerseklet = 21.0;
        }

        public double JelenlegiHomerseklet { get => jelenlegiHomerseklet; private set => jelenlegiHomerseklet = value; }
        public double CelHomerseklet { get => celHomerseklet; private set => celHomerseklet = value; }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("BEALLIT_HOMERSEKLET") && parancs.Split(":").Length == 2)
            {
                double ujCelHomerseklet = double.Parse(parancs.Split(":")[1]);
                this.celHomerseklet = ujCelHomerseklet;
            }
        }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {jelenlegiHomerseklet} °C, célhőmérséklet: {celHomerseklet} °C";
        }

        protected override bool OnTesztFuttatasa()
        {
            if (this.celHomerseklet > 5 && this.celHomerseklet < 35)
            {
                return true;
            }
            return false;
        }

    }
}
