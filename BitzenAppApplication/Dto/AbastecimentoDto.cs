using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class AbastecimentoDto
    {
        public string NCodAbastecimento { get;  set; }
        public string NKmAbastecimento { get;  set; }
        public string NLitroAbastecimento { get;  set; }
        public string VVlrPago { get;  set; }
        public string DAbastecimento { get;  set; }
        public string Posto { get;  set; }
        public string NCodPosto { get;  set; }
        public string UsuarioInc { get;  set; }
        public string NCodUsuarioInc { get;  set; }
        public string TipoCombustivel { get;  set; }
        public string NCodTipoCombustivel { get;  set; }
        public string TipoVeiculo  { get;  set; }
        public string NCodTipoVeiculo  { get;  set; }
        public string CPlaca { get; set; }

        public static explicit operator AbastecimentoDto(Abastecimento a)
        {
            return new AbastecimentoDto
            {
              NCodAbastecimento = a.NCodAbastecimento.ToString(),
              NKmAbastecimento = a.NKmAbastecimento.ToString(),
              NLitroAbastecimento = a.NLitroAbastecimento.ToString(),
              VVlrPago = a.VVlrPago.ToString(),
              DAbastecimento = a.DAbastecimento.ToString(),
              Posto = a.Posto.CDescricao,
              NCodPosto = a.Posto.NCodPosto.ToString(),
              UsuarioInc = a.UsuarioInc.CNome,
              NCodUsuarioInc = a.UsuarioInc.NCodUsuario.ToString(),
              TipoCombustivel = a.TipoCombustivel.CDescricao,
              NCodTipoCombustivel = a.TipoCombustivel.NCodCombustivel.ToString(),
              TipoVeiculo = a.TipoVeiculo.CDescricao,
              NCodTipoVeiculo = a.TipoVeiculo.NCodTipoVeiculo.ToString(),
              CPlaca = a.Veiculo.CPlaca
            };
        }

    }
}
