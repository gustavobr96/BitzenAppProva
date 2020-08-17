using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class PostoDto
    {
        public string NCodPosto { get; set; }
        public string CDescricao { get; set; }

        public static explicit operator PostoDto(Posto p)
        {
            return new PostoDto
            {
                NCodPosto = p.NCodPosto.ToString(),
                CDescricao = p.CDescricao

            };
        }
    }
}
