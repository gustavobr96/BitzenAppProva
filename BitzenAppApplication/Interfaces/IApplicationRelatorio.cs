using BitzenAppApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Interfaces
{
    public interface IApplicationRelatorio : IDisposable
    {
        RelatorioDto ObterRelatorioPorUsuarioTipos(string user, int tipo);

    }
}
