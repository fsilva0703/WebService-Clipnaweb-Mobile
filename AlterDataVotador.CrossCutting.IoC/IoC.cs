using AlterDataVotador.CrossCutting.IoC.Modulo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlterDataVotador.CrossCutting.IoC
{
    public static class IoC
    {
        public static void Start(IServiceCollection paramServicos, IConfiguration paramConfiguracao)
        {
            AplicacaoModulo.Start(paramServicos);
            DominioModulo.Start(paramServicos, paramConfiguracao);
            RepositorioModulo.Start(paramServicos, paramConfiguracao);
        }
    }
}
