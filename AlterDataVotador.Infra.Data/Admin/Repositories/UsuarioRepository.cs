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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuration;

        public UsuarioRepository(IConfiguration config)
        {
            _configuration = config;
        }
        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("AlterDataVotador");
            return conString;
        }
        public List<UsuarioResult> ListUsuario(UsuarioListParameter paramObj)
        {
            try
            {
                List<UsuarioResult> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Select_Usuario", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@paramNome", paramObj.Nome);
                    cmd.Parameters.AddWithValue("@paramEmail", paramObj.Email);
                    cmd.Parameters.AddWithValue("@paramIdSetor", paramObj.IdSetor);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<UsuarioResult>();
                    while (sqlDataReader.Read())
                    {
                        UsuarioResult item = new UsuarioResult();
                        if (!sqlDataReader.IsDBNull(0)) item.IdSetor = sqlDataReader.GetInt32(0);
                        if (!sqlDataReader.IsDBNull(1)) item.IdUsuario = sqlDataReader.GetInt32(1);
                        if (!sqlDataReader.IsDBNull(2)) item.NomeSetor = sqlDataReader.GetString(2);
                        if (!sqlDataReader.IsDBNull(3)) item.Nome = sqlDataReader.GetString(3);
                        if (!sqlDataReader.IsDBNull(4)) item.Email = sqlDataReader.GetString(4);
                        lst.Add(item);
                    }

                    con.Close();
                }

                return lst;

            }
            catch (Exception ex)
            {
                throw new Exception("Ops... Ocorreu um erro na listagem de usuários: " + ex.Message);
            }
        }

        public Boolean InsertUsuario(UsuarioInsertParameter paramObj)
        {
            try
            {

                Boolean IsEmailExists = false;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Insert_Usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSetor", paramObj.IdSetor);
                    cmd.Parameters.AddWithValue("@paramNome", paramObj.Nome);
                    cmd.Parameters.AddWithValue("@paramEmail", paramObj.Email);
                    cmd.Parameters.AddWithValue("@paramSenha", paramObj.Senha);

                    con.Open();
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        IsEmailExists = reader.GetBoolean(0);
                    }

                    con.Close();
                }

                if (IsEmailExists)
                    return false;
                else
                    return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public Boolean UpdateUsuario(UsuarioUpdateParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Update_Usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdSetor", paramObj.IdSetor);
                    cmd.Parameters.AddWithValue("@paramIdUsuario", paramObj.IdUsuario);
                    cmd.Parameters.AddWithValue("@paramNome", paramObj.Nome);
                    cmd.Parameters.AddWithValue("@paramEmail", paramObj.Email);
                    cmd.Parameters.AddWithValue("@paramSenha", paramObj.Senha);

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


        public Boolean DeleteUsuario(UsuarioDeleteParameter paramObj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("Delete_Usuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@paramIdUsuario", paramObj.IdUsuario);

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
