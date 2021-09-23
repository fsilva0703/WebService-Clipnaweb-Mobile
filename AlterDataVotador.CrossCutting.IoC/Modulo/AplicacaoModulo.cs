using AlterdataVotador.Application.Admin.Interfaces;
using AlterdataVotador.Application.Admin.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AlterDataVotador.CrossCutting.IoC.Modulo
{
    public static class AplicacaoModulo
    {
        public static void Start(IServiceCollection paramServicos)
        {
            //Setor
            paramServicos.AddTransient<ISetorAppService, SetorAppService>();
            //Usuario
            paramServicos.AddTransient<IUsuarioAppService, UsuarioAppService>();
            //Sistema
            paramServicos.AddTransient<ISistemaAppService, SistemaAppService>();
            //Recurso
            paramServicos.AddTransient<IRecursoAppService, RecursoAppService>();
            //Login
            paramServicos.AddTransient<ILoginAppService, LoginAppService>();
            //Materia
            paramServicos.AddTransient<IMateriaAppService, MateriaAppService>();
        }
    }
}