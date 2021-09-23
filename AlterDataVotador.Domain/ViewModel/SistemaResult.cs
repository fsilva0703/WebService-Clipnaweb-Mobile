using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class SistemaResult
    {
        /// <summary>
        /// Id do Sistema
        /// </summary>
        public Int32 IdSistema { get; set; }

        /// <summary>
        /// Nome do Sistema
        /// </summary>
        public String NomeSistema { get; set; }

        /// <summary>
        /// URL de Produção
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// Quantidade de Assinaturas
        /// </summary>
        public Int32 QuantidadeAssinatura { get; set; }

        /// <summary>
        /// Nome da Plataforma de Desenvolvimento
        /// </summary>
        public String NomePlataformnaDesenv { get; set; }
    }
}
