using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class TipoCombustivel
    {
        public int NCodCombustivel { get; private set; }
        public string CDescricao { get; private set; }

        public void setNCodCombustivel(int nCodCombustivel)
        {
            NCodCombustivel = nCodCombustivel;
        }
        public void setCDescricao(string cDescricao)
        {
            CDescricao = cDescricao;
        }
    }
}
