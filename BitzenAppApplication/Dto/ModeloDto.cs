using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class ModeloDto
    {
        public string NCodModelo { get; set; }
        public string CDescricao { get; set; }

        public static explicit operator ModeloDto(Modelo m)
        {
            return new ModeloDto
            {
                NCodModelo = m.NCodModelo.ToString(),
                CDescricao = m.CDescricao

            };
        }
    }
}
