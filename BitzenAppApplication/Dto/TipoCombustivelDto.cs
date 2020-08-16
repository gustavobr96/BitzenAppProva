using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class TipoCombustivelDto
    {
        public string NCodCombustivel { get; set; }
        public string CDescricao { get; set; }

        public static explicit operator TipoCombustivelDto(TipoCombustivel m)
        {
            return new TipoCombustivelDto
            {
                NCodCombustivel = m.NCodCombustivel.ToString(),
                CDescricao = m.CDescricao

            };
        }
    }
}
