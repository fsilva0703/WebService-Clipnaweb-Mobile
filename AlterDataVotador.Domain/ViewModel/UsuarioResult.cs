using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class UsuarioResult
    {

        /// <summary>
        /// Id do usuário
        /// </summary>
        public Int32 IdUsuario { get; set; }

        /// <summary>
        /// Id do Setor
        /// </summary>
        public Int32 IdSetor { get; set; }

        /// <summary>
        /// Nome do Setor
        /// </summary>
        public String NomeSetor { get; set; }

        /// <summary>
        /// Nome do Usuário
        /// </summary>
        public String Nome { get; set; }

        /// <summary>
        /// Email do Usuário
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Senha do Usuário
        /// </summary>
        [JsonIgnore]
        public String Senha { get; set; }

        /// <summary>
        /// Diretoria
        /// </summary>
        [JsonIgnore]
        public String IsDiretoria { get; set; }
    }
}
