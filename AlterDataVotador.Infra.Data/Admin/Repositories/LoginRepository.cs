using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AlterDataVotador.Infra.Data.Admin.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _configuration;

        public LoginRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public string GetConnectionString()
        {
            string conString = _configuration.GetConnectionString("ConnStringConfig");
            return conString;
        }

        public List<UserInfo> Get(String email, String senha)
        {
            try
            {
                List<UserInfo> lst = null;

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[pr_get_perfil_cliente]", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataReader sqlDataReader = null;

                    cmd.Parameters.AddWithValue("@prmLogin", email);
                    cmd.Parameters.AddWithValue("@prmSenha", senha);

                    con.Open();
                    sqlDataReader = cmd.ExecuteReader();

                    lst = new List<UserInfo>();
                    while (sqlDataReader.Read())
                    {
                        UserInfo item = new UserInfo();
                        if (!sqlDataReader.IsDBNull(0)) item.Cliente = sqlDataReader.GetString(0);
                        if (!sqlDataReader.IsDBNull(1)) item.Login = sqlDataReader.GetString(1);
                        if (!sqlDataReader.IsDBNull(8)) item.Password = sqlDataReader.GetString(8);
                        if (!sqlDataReader.IsDBNull(5)) item.ClientId = sqlDataReader.GetString(5);

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
    }
}