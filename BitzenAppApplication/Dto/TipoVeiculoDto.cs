using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class TipoVeiculoDto
    {
        public string NCodTipoVeiculo { get; set; }
        public string CDescricao { get; set; }

        public static explicit operator TipoVeiculoDto(TipoVeiculo m)
        {
            return new TipoVeiculoDto
            {
                NCodTipoVeiculo = m.NCodTipoVeiculo.ToString(),
                CDescricao = m.CDescricao

            };
        }
    }
}
