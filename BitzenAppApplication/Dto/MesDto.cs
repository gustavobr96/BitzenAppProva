using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class MesDto
    {
        public string NCodMes { get; set; }
        public string CDescricao { get; set; }
        public string Valor { get; set; }

        public static explicit operator MesDto(Mes m)
        {
            return new MesDto
            {
                NCodMes = m.NCodMes.ToString(),
                CDescricao = m.CDescricao,
                Valor = m.Valor.ToString()
            };
        }

    }
}
