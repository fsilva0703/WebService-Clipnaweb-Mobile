using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Entity;
using AlterDataVotador.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
//using DesafioAlterData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AlterDataVotador.Infra.Data.Admin.Repositories
{
    public class SetorRepository : ISetorRepository
    {

        private readonly IConfiguration _configuration;

        public SetorRepository(IConfiguration config)
        {
            _configuration = config;
        }
        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("AlterDataVotador");
            return conString;
        }
        public List<SetorResult> ListSetor(SetorListParameter paramObj)
        {
            try
            {
                List<SetorResult> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("List_Setor", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@paramNomeSetor", paramObj.NomeSetor);
                    cmd.Parameters.AddWithValue("@paramNomeGerenteSetor", paramObj.NomeGerenteSetor);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<SetorResult>();
                    while (sqlDataReader.Read())
                    {
                        SetorResult item = new SetorResult();
                        if (!sqlDataReader.IsDBNull(0)) item.IdSetor = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(0)) item.NomeSetor = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(1)) item.NomeGerenteSetor = sqlDataReader.GetString(2);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos setores: " + ex.Message);
            }
        }

        public Task<Setor> InsertSetor(SetorInsertParameter paramObj)
        {
            return Task.Run(() =>
            {

                Setor setor = null;

                setor = new Setor();
                setor.Nome = paramObj.NomeSetor;
                setor.NomeGerente = paramObj.NomeGerenteSetor;

                AlterDataContext contexto = new AlterDataContext();
                contexto.Tb_Setor.Add(setor);
                contexto.SaveChanges();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    //SqlCommand cmd = new SqlCommand("Insert_Setor", con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@paramNomeSetor", paramObj.NomeSetor);
                    //cmd.Parameters.AddWithValue("@paramNomeGerenteSetor", paramObj.NomeGerenteSetor);

                    //con.Open();
                    //Int32 retorno = Convert.ToInt32(cmd.ExecuteScalar());

                    //setor = new SetorResult();
                    //setor.IdSetor = retorno;
                    //setor.NomeSetor = paramObj.NomeSetor;
                    //setor.NomeGerenteSetor = paramObj.NomeGerenteSetor;

                    con.Close();
                }


                return setor;
            });

        }


        public Boolean UpdateSetor(SetorUpdateParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Update_Setor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSetor", paramObj.IdSetor);
                    cmd.Parameters.AddWithValue("@paramNomeSetor", paramObj.NomeSetor);
                    cmd.Parameters.AddWithValue("@paramNomeGerenteSetor", paramObj.NomeGerenteSetor);

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


        public Boolean DeleteSetor(SetorDeleteParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Delete_Setor", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSetor", paramObj.IdSetor);

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
    }
}
