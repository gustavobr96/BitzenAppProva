using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Modelo
    {
        public int NCodModelo { get; private set; }
        public string CDescricao { get; private set; }

        public void setNCodModelo(int nCodModelo)
        {
            NCodModelo = nCodModelo;
        }
        public void setCDescricao(string cDescricao)
        {
            CDescricao = cDescricao;
        }
    }
}
