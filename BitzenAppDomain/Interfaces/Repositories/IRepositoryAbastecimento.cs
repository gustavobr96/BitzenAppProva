using BitzenAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Repositories
{
    public interface IRepositoryAbastecimento :IRepository<Abastecimento>
    {
        IEnumerable<Abastecimento> ObterTodosPorUsuario(string user);
        IEnumerable<Posto> ObterTodosPosto();
    }
}
