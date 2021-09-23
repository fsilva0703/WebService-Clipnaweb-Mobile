using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class UsuarioDeleteParameter
    {
        /// <summary>
        /// Id do usuário.
        /// </summary>
        [Required(ErrorMessage = "O ID do usuário é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdUsuario { get; set; }
    }
}
