using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class SetorUpdateParameter : SetorInsertParameter
    {

        /// <summary>
        /// Id do setor.
        /// </summary>
        [Required(ErrorMessage = "O ID do setor é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdSetor { get; set; }

    }
}
