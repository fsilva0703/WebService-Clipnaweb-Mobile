using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Infra.Data.Admin.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlterDataVotador.CrossCutting.IoC.Modulo
{
    public static class RepositorioModulo
    {
        public static void Start(IServiceCollection paramServicos, IConfiguration paramConfiguracao)
        {
            //Setor
            paramServicos.AddTransient<ISetorRepository, SetorRepository>();
            //Usuario
            paramServicos.AddTransient<IUsuarioRepository, UsuarioRepository>();
            //Sistema
            paramServicos.AddTransient<ISistemaRepository, SistemaRepository>();
            //Recurso
            paramServicos.AddTransient<IRecursoRepository, RecursoRepository>();
            //Login
            paramServicos.AddTransient<ILoginRepository, LoginRepository>();
            //Materia
            paramServicos.AddTransient<IMateriaRepository, MateriaRepository>();
        }
    }
}