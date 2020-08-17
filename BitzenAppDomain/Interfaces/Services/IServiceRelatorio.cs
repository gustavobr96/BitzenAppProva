using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Services
{
    public interface IServiceRelatorio : IDisposable
    {
        Relatorio ObterRelatorioPorUsuarioTipos(string user, int tipo);
    }
}
