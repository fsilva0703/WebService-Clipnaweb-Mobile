using System;
using System.ComponentModel.DataAnnotations;

namespace AlterDataVotador.Domain.ViewModel
{
    public class UsuarioInsertParameter
    {
        /// <summary>
        /// Id do Setor
        /// </summary>
        [Required(ErrorMessage = "O ID do setor é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdSetor { get; set; }

        /// <summary>
        /// Nome do Usuario
        /// </summary>
        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(30)]
        public String Nome { get; set; }

        /// <summary>
        /// Email do Usuario
        /// </summary>
        [Required(ErrorMessage = "O e-mail é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100)]
        public String Email { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatória.", AllowEmptyStrings = false)]
        [StringLength(100)]
        public String Senha { get; set; }
    }
}
