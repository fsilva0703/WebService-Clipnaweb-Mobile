using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class UsuarioListParameter
    {
        /// <summary>
        /// Id do Setor
        /// </summary>
        public Int32 IdSetor { get; set; }

        /// <summary>
        /// Id do Usuário
        /// </summary>
        public Int32 IdUsuario { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public String Nome { get; set; }

        /// <summary>
        /// E-mail do usuário
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// Senha do Usuário
        /// </summary>
        public String Senha { get; set; }
    }
}
