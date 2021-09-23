using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AlterDataVotador.Infra.Data.Admin.Repositories
{
    public class RecursoRepository : IRecursoRepository
    {

        public string GetConnectionString()
        {
            return "";// Configuration.GetConnectionString("DefaultConnection");
        }
        public List<RecursoResult> ListRecurso(RecursoListParameter paramObj)
        {
            try
            {
                List<RecursoResult> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("List_Recurso", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@paramNomeModulo", paramObj.NomeModulo);
                    cmd.Parameters.AddWithValue("@paramDescricaoRecurso", paramObj.DescricaoRecurso);
                    cmd.Parameters.AddWithValue("@paramIdTipoSolicitacao", paramObj.IdTipoSolicitacao);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<RecursoResult>();
                    while (sqlDataReader.Read())
                    {
                        RecursoResult item = new RecursoResult();
                        if (!sqlDataReader.IsDBNull(0)) item.IdRecurso = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.NomeSistema = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(2)) item.NomeModulo = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) item.DescricaoRecurso = sqlDataReader.GetString(3);
                        if (!sqlDataReader.IsDBNull(4)) item.TipoSolicitacao = sqlDataReader.GetString(4);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos recursos: " + ex.Message);
            }
        }

        public Boolean InsertRecurso(RecursoInsertParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Insert_Recurso", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSistema", paramObj.IdSistema);
                    cmd.Parameters.AddWithValue("@paramNomeModulo", paramObj.NomeModulo);
                    cmd.Parameters.AddWithValue("@paramDescricaoRecurso", paramObj.DescricaoRecurso);
                    cmd.Parameters.AddWithValue("@paramIdTipoSolicitacao", paramObj.IdTipoSolicitacao);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public Boolean UpdateRecurso(RecursoUpdateParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Update_Recurso", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdRecurso", paramObj.IdRecurso);
                    cmd.Parameters.AddWithValue("@paramIdSistema", paramObj.IdSistema);
                    cmd.Parameters.AddWithValue("@paramNomeModulo", paramObj.NomeModulo);
                    cmd.Parameters.AddWithValue("@paramDescricaoRecurso", paramObj.DescricaoRecurso);
                    cmd.Parameters.AddWithValue("@paramIdTipoSolicitacao", paramObj.IdTipoSolicitacao);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public Boolean DeleteRecurso(RecursoDeleteParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Delete_Recurso", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdRecurso", paramObj.IdRecurso);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TipoSolicitacaoResult> ListTipoSolicitacao()
        {
            try
            {
                List<TipoSolicitacaoResult> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("List_TipoSolicitacao", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<TipoSolicitacaoResult>();
                    while (sqlDataReader.Read())
                    {
                        TipoSolicitacaoResult item = new TipoSolicitacaoResult();
                        if (!sqlDataReader.IsDBNull(0)) item.IdTipoSolicitacao = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.TipoSolicitacao = sqlDataReader.GetString(1);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos tipos de solicitação: " + ex.Message);
            }
        }
    }
}
