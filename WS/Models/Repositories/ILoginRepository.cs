using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WS.Models.Dto;

namespace WS.Models.Repositories
{
    public interface ILoginRepository
    {
        Task Add(Usuario item);
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> Find(int id);
        Task<Usuario> FindLogin(string keyUser, string keyPwd);
        Task<Login> FindLoginByProc(string keyUser, string keyPwd);
        Task Remove(int Id);
        Task Update(Usuario item);
        Task<List<Login>> FindMidiasPermitidasByProc(string keyUser, string keyPwd);
        Task<List<DtoAssunto>> FindAssuntosByProc(String NomeBanco);
        Task<List<DtoMateria>> FindMateriasByProc(DtoFiltro filtro);

        //bool CheckValidUserKey(string reqkey);
    }
}
