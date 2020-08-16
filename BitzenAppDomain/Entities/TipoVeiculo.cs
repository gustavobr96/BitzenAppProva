using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class TipoVeiculo
    {
        public int NCodTipoVeiculo { get; private set; }
        public string CDescricao { get; private set; }

        public void setNCodTipoVeiculo(int nCodTipoVeiculo)
        {
            NCodTipoVeiculo = nCodTipoVeiculo;
        }
        public void setCDescricao(string cDescricao)
        {
            CDescricao = cDescricao;
        }
    }
}
