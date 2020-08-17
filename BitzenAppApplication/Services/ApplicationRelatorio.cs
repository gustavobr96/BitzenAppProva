using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using BitzenAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppApplication.Services
{
    public class ApplicationRelatorio : IApplicationRelatorio
    {
        private readonly IServiceRelatorio _serviceRelatorio;

        public ApplicationRelatorio(IServiceRelatorio serviceRelatorio)
        {
            _serviceRelatorio = serviceRelatorio;
        }


        public void Dispose()
        {
            _serviceRelatorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public RelatorioDto ObterRelatorioPorUsuarioTipos(string user, int tipo)
        {
            return (RelatorioDto)_serviceRelatorio.ObterRelatorioPorUsuarioTipos(user,tipo);
        }
    }
}
