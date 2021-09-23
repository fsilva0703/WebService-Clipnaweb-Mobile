using System;
using System.ComponentModel.DataAnnotations;

namespace AlterDataVotador.Domain.ViewModel
{
    public class UsuarioUpdateParameter : UsuarioInsertParameter
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        [Required(ErrorMessage = "O ID do usuário é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdUsuario { get; set; }

    }
}
