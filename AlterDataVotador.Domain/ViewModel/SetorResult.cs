using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class SetorResult
    {

        /// <summary>
        /// Id do Setor
        /// </summary>
        public Int32 IdSetor { get; set; }

        /// <summary>
        /// Nome do Setor
        /// </summary>
        public String NomeSetor { get; set; }

        /// <summary>
        /// Nome do Gerente do Setor
        /// </summary>
        public String NomeGerenteSetor { get; set; }
    }
}
