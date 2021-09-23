using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AlterDataVotador.Infra.Data.Admin.Repositories
{
    public class SistemaRepository : ISistemaRepository
    {
        public string GetConnectionString()
        {
            return "";// Configuration.GetConnectionString("DefaultConnection");
        }
        public List<SistemaResult> ListSistema(SistemaListParameter paramObj)
        {
            try
            {
                List<SistemaResult> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("List_Sistema", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@paramNomeSistema", paramObj.NomeSistema);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<SistemaResult>();
                    while (sqlDataReader.Read())
                    {
                        SistemaResult item = new SistemaResult();
                        if (!sqlDataReader.IsDBNull(0)) item.IdSistema = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.NomeSistema = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(2)) item.Url = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) item.QuantidadeAssinatura = sqlDataReader.GetInt32(3);
                        if (!sqlDataReader.IsDBNull(4)) item.NomePlataformnaDesenv = sqlDataReader.GetString(4);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem dos sistemas: " + ex.Message);
            }
        }

        public Boolean InsertSistema(SistemaInsertParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Insert_Sistema", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramNomeSistema", paramObj.NomeSistema);
                    cmd.Parameters.AddWithValue("@paramUrl", paramObj.Url);
                    cmd.Parameters.AddWithValue("@paramNomePlataforma", paramObj.NomePlataformnaDesenv);

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


        public Boolean UpdateSistema(SistemaUpdateParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Update_Sistema", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSistema", paramObj.IdSistema);
                    cmd.Parameters.AddWithValue("@paramNomeSistema", paramObj.NomeSistema);
                    cmd.Parameters.AddWithValue("@paramUrl", paramObj.Url);
                    cmd.Parameters.AddWithValue("@paramNomePlataforma", paramObj.NomePlataformnaDesenv);

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


        public Boolean DeleteSistema(SistemaDeleteParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Delete_Sistema", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSistema", paramObj.IdSistema);

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
