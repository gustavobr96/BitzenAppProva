using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Posto
    {
        public int NCodPosto{ get; private set; }
        public string CDescricao { get; private set; }


        public void setNCodPosto(int nCodPosto)
        {
            NCodPosto = nCodPosto;
        }

        public void setCDescricao(string cDescricao)
        {
            CDescricao = cDescricao;
        }
    }
}
