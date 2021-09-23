using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AlterDataVotador.Infra.Data.Admin.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly IConfiguration _configuration;

        public MateriaRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("ConnStringConfig");
            return conString;
        }

        public List<MateriaResult> ListMateria(MateriaParameter filtro, string ClientId)
        {
            try
            {
                List<MateriaResult> lst = null;

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

                    if (!String.IsNullOrEmpty(filtro.PesquisaTexto))
                    {
                        palavraImpresso = " AND (mat_titulo like '%" + filtro.PesquisaTexto + "%' OR mat_subtitulo like '%" + filtro.PesquisaTexto + "%' OR mat_resumo like '%" + filtro.PesquisaTexto + "%' )  ";
                        palavraOutrasMidias = " AND (título like '%" + filtro.PesquisaTexto + "%' OR subtitulo like '%" + filtro.PesquisaTexto + "%' OR materia like '%" + filtro.PesquisaTexto + "%' )  ";
                        palavraMSocial = " AND (des_title like '%" + filtro.PesquisaTexto + "%' OR des_text like '%" + filtro.PesquisaTexto + "%')  ";
                    }

                    if (filtro.Midia.ToLower() == "impresso")
                        Clausula += "'Impresso',";

                    if (filtro.Midia.ToLower() == "tv")
                        Clausula += "'tv',";

                    if (filtro.Midia.ToLower() == "rd")
                        Clausula += "'rd',";

                    if (filtro.Midia.ToLower() == "online")
                        Clausula += "'online',";

                    if (filtro.Midia.ToLower() == "inter")
                        Clausula += "'inter',";

                    if (filtro.Midia.ToLower() == "msocial")
                        Clausula += "'msocial',";

                    if (Clausula != "")
                    {
                        Clausula = " and Midia in(" + Clausula + ") ";
                        Midia = Clausula.Replace(",)", ")");
                    }

                    cmd.Parameters.AddWithValue("@prmDtInicio", filtro.DataIni.ToShortDateString());
                    cmd.Parameters.AddWithValue("@prmDtFim", filtro.DataFim.ToShortDateString());
                    cmd.Parameters.AddWithValue("@prmBanco", ClientId);
                    cmd.Parameters.AddWithValue("@prmLikeMatResumo", palavraImpresso);
                    cmd.Parameters.AddWithValue("@prmLikeMateria", palavraOutrasMidias);
                    cmd.Parameters.AddWithValue("@prmLikeMSocial", palavraMSocial);
                    cmd.Parameters.AddWithValue("@prmMidia", Midia);
                    cmd.Parameters.AddWithValue("@prmInnerJoinAssuntoImpresso", InnerJoinAssuntoImpresso);
                    cmd.Parameters.AddWithValue("@prmInnerJoinAssuntoOutrasMidias", InnerJoinAssuntoOutrasMidias);
                    cmd.Parameters.AddWithValue("@prmComplementoAssunto", ComplementoAssunto);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<MateriaResult>();
                    while (sqlDataReader.Read())
                    {
                        MateriaResult item = new MateriaResult();
                        if (!sqlDataReader.IsDBNull(0)) item.MatId = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.Texto = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(3)) item.Titulo = sqlDataReader.GetString(3);
                        if (!sqlDataReader.IsDBNull(4)) item.Subtitulo = sqlDataReader.GetString(4);
                        if (!sqlDataReader.IsDBNull(2)) item.Data = sqlDataReader.GetDateTime(2);
                        if (!sqlDataReader.IsDBNull(7)) item.Veiculo = sqlDataReader.GetString(7);
                        if (!sqlDataReader.IsDBNull(9)) item.Programa = sqlDataReader.GetString(9);
                        if (!sqlDataReader.IsDBNull(6)) item.UrlMateria = sqlDataReader.GetString(6);
                        if (!sqlDataReader.IsDBNull(11)) item.Midia = sqlDataReader.GetString(11);

                        if (item.Midia.ToLower() == "tv" || item.Midia.ToLower() == "rd")
                            item.UrlMateria = "http://www.clipnaweb.com.br/v3/clipping/player.aspx?idNoticia=" + item.MatId + "&tipo=" + item.Midia + "&file=" + item.UrlMateria + "&cliente=br2&login=cdbr2";

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
    }
}