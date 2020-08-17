using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Repositories
{
    public interface IRepositoryRelatorio : IRepository<Relatorio>
    {
        Relatorio ObterRelatorioPorUsuarioTipos(string user, int tipo);
    }
}
