using BitzenAppDomain.Entities;
using BitzenAppDomain.Interfaces.Repositories;
using BitzenAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Services
{
    public class ServiceRelatorio : IServiceRelatorio
    {

        private readonly IRepositoryRelatorio _repoRelatorio;

        public ServiceRelatorio(IRepositoryRelatorio repoRelatorio)
        {
            _repoRelatorio = repoRelatorio;
        }
      


        public void Dispose()
        {
            _repoRelatorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public Relatorio ObterRelatorioPorUsuarioTipos(string user, int tipo)
        {
            if(int.Parse(user) > 0 && tipo >0)
                return _repoRelatorio.ObterRelatorioPorUsuarioTipos(user,tipo);

            return null;
        }
    }
}
