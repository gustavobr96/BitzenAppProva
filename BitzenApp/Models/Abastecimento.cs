using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitzenApp.Models
{
    public class Abastecimento
    {
        public string NCodAbastecimento { get; set; }
        public string NKmAbastecimento { get; set; }
        public string NLitroAbastecimento { get; set; }
        public string VVlrPago { get; set; }
        public string DAbastecimento { get; set; }
        public string Posto { get; set; }
        public string NCodPosto { get; set; }
        public string UsuarioInc { get; set; }
        public string NCodUsuarioInc { get; set; }
        public string TipoCombustivel { get; set; }
        public string NCodTipoCombustivel { get; set; }
        public string TipoVeiculo { get; set; }
        public string CPlaca { get; set; }
        public string NCodTipoVeiculo { get; set; }
    }
}
