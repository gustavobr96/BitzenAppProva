using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Dto
{
    public class RelatorioDto
    {
        public List<Mes> Meses { get;  set; }
        public int Tipo { get; set; }
        public string usuario { get; set; }

        public static explicit operator RelatorioDto(Relatorio r)
        {
            return new RelatorioDto
            {
                Meses = r.Meses
            };
        }
    }
}
