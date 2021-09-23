using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlterDataVotador.CrossCutting.IoC.Modulo
{
    public static class DominioModulo
    {
        public static void Start(IServiceCollection paramServicos, IConfiguration paramConfiguracao)
        {
            //Setor
            paramServicos.AddTransient<ISetorService, SetorService>();
            //Usuario
            paramServicos.AddTransient<IUsuarioService, UsuarioService>();
            //Sistema
            paramServicos.AddTransient<ISistemaService, SistemaService>();
            //Recurso
            paramServicos.AddTransient<IRecursoService, RecursoService>();
            //Login
            paramServicos.AddTransient<ILoginService, LoginService>();
            //Materia
            paramServicos.AddTransient<IMateriaService, MateriaService>();
        }
    }
}