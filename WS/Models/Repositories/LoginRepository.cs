using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WS.Models.Context;
using WS.Models.Dto;

namespace WS.Models.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        ContextManagerLogin _context;
        private readonly IConfiguration _configuration;

        public LoginRepository(ContextManagerLogin context, IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("ConnStringConfig");
            return conString;
        }      

        public async Task Add(Usuario item)
        {
            await _context.Usuario.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuario.ToListAsync();
        }

        //public bool CheckValidUserKey(string reqkey)
        //{
        //    var userkeyList = new List<string>
        //    {
        //        "28236d8ec201df516d0f6472d516d72d",
        //        "38236d8ec201df516d0f6472d516d72c",
        //        "48236d8ec201df516d0f6472d516d72b"
        //    };

        //    if (userkeyList.Contains(reqkey))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public async Task<Usuario> Find(int key)
        {
            return await _context.Usuario
                .Where(e => e.IdUsuario.Equals(key))
                .SingleOrDefaultAsync();
        }

        public async Task<Usuario> FindLogin(string keyUser, string keyPwd)
        {
            return await _context.Usuario
                .Where(e => e.Login.Equals(keyUser) && e.Senha.Equals(keyPwd))
                .SingleOrDefaultAsync();
        }

        public async Task<Login> FindLoginByProc(string keyUser, string keyPwd)
        {
            return await _context.Login.FromSql("[dbo].[pr_get_perfil_cliente] @p0, @p1", keyUser, keyPwd).FirstOrDefaultAsync();
        }

        //public async Task<List<Login>> FindMidiasPermitidasByProc(string keyUser, string keyPwd)
        //{
        //    List<Login> retorno = new List<Login>();
        //    retorno = await _context.Login.FromSql("[dbo].[pr_get_perfil_cliente] @p0, @p1", keyUser, keyPwd).Distinct().ToListAsync();
        //    return retorno;
        //}

        public async Task<List<Login>> FindMidiasPermitidasByProc(string keyUser, string keyPwd)
        {
            try
            {
                List<Login> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_get_perfil_cliente]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmLogin", keyUser);
                    cmd.Parameters.AddWithValue("@prmSenha", keyPwd);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<Login>();
                    while (sqlDataReader.Read())
                    {
                        Login item = new Login();
                        if (!sqlDataReader.IsDBNull(0)) item.NM_Funcionalidade = sqlDataReader.GetString(2);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos clientes: " + ex.Message);
            }
        }

        public async Task<List<DtoAssunto>> FindAssuntosByProc(String NomeBanco)
        {
            try
            {
                List<DtoAssunto> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_get_assuntos]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@P_BANCO", NomeBanco);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<DtoAssunto>();
                    while (sqlDataReader.Read())
                    {
                        DtoAssunto item = new DtoAssunto();
                        if (!sqlDataReader.IsDBNull(0)) item.BTN_Label = sqlDataReader.GetString(0);
                        if (!sqlDataReader.IsDBNull(1)) item.BTN_Palavra = sqlDataReader.GetString(1);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos clientes: " + ex.Message);
            }
        }

        public async Task<List<DtoMateria>> FindMateriasByProc(DtoFiltro filtro)
        {
            try
            {
                List<DtoMateria> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_get_materiaCNWMobile]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    //@prmDtInicio varchar(100),
                    //@prmDtFim varchar(100),
                    //@prmBanco varchar(100),
                    //@prmLikeMatResumo varchar(1000),
                    //@prmLikeMateria varchar(1000),
                    //@prmLikeMSocial varchar(1000),
                    //@prmMidia varchar(1000)

                    String palavraImpresso = "";
                    String palavraOutrasMidias = "";
                    String palavraMSocial = "";
                    String Clausula = "";
                    String Midia = "";
                    String InnerJoinAssuntoImpresso = "";
                    String ComplementoAssunto = "";
                    String InnerJoinAssuntoOutrasMidias = "";

                    if (filtro.Assunto.ToLower() != "clipping do dia")
                    {
                        InnerJoinAssuntoImpresso = "INNER JOIN dbo.[Materias Palavras] MP ON MP.MAT_Id = ma.MAT_Id " +
                                            "INNER JOIN dbo.Botoes B ON B.BTN_Palavra = MP.PLV_Palavra";

                        InnerJoinAssuntoOutrasMidias = "INNER JOIN dbo.MateriasPalavrasOutrasMidias MP ON MP.MAT_Id = number " +
                                            "INNER JOIN dbo.Botoes B ON B.BTN_Palavra = MP.PLV_Palavra";

                        ComplementoAssunto = " AND B.BTN_Label = '" + filtro.Assunto + "' ";
                    }


                    if (!String.IsNullOrEmpty(filtro.Palavra))
                    {
                        palavraImpresso = " AND (mat_titulo like '%" + filtro.Palavra + "%' OR mat_subtitulo like '%" + filtro.Palavra + "%' OR mat_resumo like '%" + filtro.Palavra + "%' )  ";
                        palavraOutrasMidias = " AND (título like '%" + filtro.Palavra + "%' OR subtitulo like '%" + filtro.Palavra + "%' OR materia like '%" + filtro.Palavra + "%' )  ";
                        palavraMSocial = " AND (des_title like '%" + filtro.Palavra + "%' OR des_text like '%" + filtro.Palavra + "%')  ";
                    }

                    if (filtro.ChkImpresso)
                        Clausula += "'Impresso',";

                    if (filtro.ChkTv)
                        Clausula += "'tv',";

                    if (filtro.ChkRd)
                        Clausula += "'rd',";

                    if (filtro.ChkOnline)
                        Clausula += "'online',";

                    if (filtro.ChkInter)
                        Clausula += "'inter',";

                    if (filtro.ChkMSocial)
                        Clausula += "'msocial',";

                    if (Clausula != "")
                    {
                        Clausula = " and Midia in(" + Clausula + ") ";
                        Midia = Clausula.Replace(",)", ")");
                    }

                    cmd.Parameters.AddWithValue("@prmDtInicio", filtro.DataIni.ToShortDateString());
                    cmd.Parameters.AddWithValue("@prmDtFim", filtro.DataFim.ToShortDateString());
                    cmd.Parameters.AddWithValue("@prmBanco", filtro.NomeBanco);
                    cmd.Parameters.AddWithValue("@prmLikeMatResumo", palavraImpresso);
                    cmd.Parameters.AddWithValue("@prmLikeMateria", palavraOutrasMidias);
                    cmd.Parameters.AddWithValue("@prmLikeMSocial", palavraMSocial);
                    cmd.Parameters.AddWithValue("@prmMidia", Midia);
                    cmd.Parameters.AddWithValue("@prmInnerJoinAssuntoImpresso", InnerJoinAssuntoImpresso);
                    cmd.Parameters.AddWithValue("@prmInnerJoinAssuntoOutrasMidias", InnerJoinAssuntoOutrasMidias);
                    cmd.Parameters.AddWithValue("@prmComplementoAssunto", ComplementoAssunto);


                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<DtoMateria>();
                    while (sqlDataReader.Read())
                    {
                        DtoMateria item = new DtoMateria();
                        if (!sqlDataReader.IsDBNull(0)) item.matId = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(3)) item.titulo = sqlDataReader.GetString(3);
                        if (!sqlDataReader.IsDBNull(4)) item.subtitulo = sqlDataReader.GetString(4);
                        if (!sqlDataReader.IsDBNull(2)) item.data = sqlDataReader.GetDateTime(2);
                        if (!sqlDataReader.IsDBNull(7)) item.veiculo = sqlDataReader.GetString(7);
                        if (!sqlDataReader.IsDBNull(9)) item.programa = sqlDataReader.GetString(9);
                        if (!sqlDataReader.IsDBNull(6)) item.urlMateria = sqlDataReader.GetString(6);
                        if (!sqlDataReader.IsDBNull(11)) item.midia = sqlDataReader.GetString(11);

                        if (sqlDataReader.GetString(11).ToLower() == "impresso")
                        {
                            item.urlFile = "ico_jr.png";
                        }
                        else if (sqlDataReader.GetString(11).ToLower() == "tv")
                        {
                            item.urlFile = "ico_tv.png";
                        }
                        else if (sqlDataReader.GetString(11).ToLower() == "rd")
                        {
                            item.urlFile = "ico_rd.png";
                        }
                        else if (sqlDataReader.GetString(11).ToLower() == "online")
                        {
                            item.urlFile = "ico_online.png";
                        }
                        else if (sqlDataReader.GetString(11).ToLower() == "inter")
                        {
                            item.urlFile = "ico_inter.png";
                        }
                        else if (sqlDataReader.GetString(11).ToLower() == "msocial")
                        {
                            item.urlFile = "ico_msocial.png";
                        }

                        item.urlMateria = "http://www.clipnaweb.com.br/v3/clipping/conteudoNoticia.aspx?cliente="+filtro.Cliente+"&idNoticia="+item.matId+"&arquivo="+item.urlMateria+"&data="+item.data+"&tipo="+item.midia.ToLower()+ "&midia="+item.midia.ToLower()+"&vitrine=1&usu=cd"+filtro.Cliente;

                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos clientes: " + ex.Message);
            }
        }


        public async Task Remove(Int32 Id)
        {
            var itemToRemove = await _context.Usuario.SingleOrDefaultAsync(r => r.IdUsuario == Id);
            if (itemToRemove != null)
            {
                _context.Usuario.Remove(itemToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Usuario item)
        {
            var itemToUpdate = await _context.Usuario.SingleOrDefaultAsync(r => r.IdUsuario == item.IdUsuario);
            if (itemToUpdate != null)
            {
                itemToUpdate.Login = item.Login;
                itemToUpdate.Senha = item.Senha;
                itemToUpdate.Nome = item.Nome;
                await _context.SaveChangesAsync();
            }
        }
    }
}
