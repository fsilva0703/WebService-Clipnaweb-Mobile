using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class RecursoDeleteParameter
    {
        /// <summary>
        /// ID do Recurso
        /// </summary>
        [Required(ErrorMessage = "O ID do recurso é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdRecurso { get; set; }
    }
}
