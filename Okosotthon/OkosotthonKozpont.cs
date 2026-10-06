using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosotthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok = [];
        public void EszkozHozzaadasa(OkosEszkoz eszkoz)
        {
            this.eszkozok.Add(eszkoz);
        }

     
        public void OsszesCsatlakoztatasa()
        {
            foreach (OkosEszkoz eszkoz in eszkozok)
            {
                eszkoz.Csatlakozas();
            }
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            int sikeres = 0;
            foreach (OkosEszkoz eszkoz in eszkozok)
            {
                if (eszkoz.DiagnosztikaFuttatasa() == true)
                {
                    sikeres++;
                }
            }
            return sikeres;
        }

    }
}
