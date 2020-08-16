using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities
{
    public class Marca
    {
        public int  NCodMarca { get; private set; }
        public string CDescricao { get; private set; }


        #region setters
        public void setNCodMarca(int nCodMarca)
        {
            NCodMarca = nCodMarca;
        }
        public void setCDescricao(string cDescricao)
        {
            CDescricao = cDescricao;
        }
        #endregion
    }
}
