using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class RecursoInsertParameter
    {
        /// <summary>
        /// ID do Sistema
        /// </summary>
        [Required(ErrorMessage = "O ID do sistema é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public Int32 IdSistema { get; set; }

        /// <summary>
        /// Nome do Módulo
        /// </summary>
        [Required(ErrorMessage = "O nome do módulo é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public String NomeModulo { get; set; }

        /// <summary>
        /// Descrição do Recurso
        /// </summary>
        [Required(ErrorMessage = "A descrição do recurso é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public String DescricaoRecurso { get; set; }

        /// <summary>
        /// Id do Tipo de Solicitação
        /// </summary>
        [Required(ErrorMessage = "O Id do Tipo de Solicitação é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdTipoSolicitacao { get; set; }

    }
}
