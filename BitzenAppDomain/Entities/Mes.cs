using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Mes
    {
        public int NCodMes { get; private set; }
        public string CDescricao { get; private set; }
        public double Valor { get; private set; }

        public Mes()
        {
            NCodMes = 0;
            CDescricao = "";
            Valor = 0;
        }
        public void setNCodMes(int nCodMes)
        {
            NCodMes = nCodMes;
        }
        public void setCDescricao(string cDescricao)
        {
            CDescricao = cDescricao;
        }
        public void setValor(double valor)
        {
            Valor = valor;
        }
    }
}
