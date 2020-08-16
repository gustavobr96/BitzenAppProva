using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class MarcaDto
    {
        public string NCodMarca { get; set; }
        public string CDescricao { get; set; }

        public static explicit operator MarcaDto(Marca m)
        {
            return new MarcaDto
            {
               NCodMarca = m.NCodMarca.ToString(),
               CDescricao = m.CDescricao

            };
        }
    }
}
