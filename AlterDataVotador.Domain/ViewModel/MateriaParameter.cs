using System;

namespace AlterDataVotador.Domain.ViewModel
{
    public class MateriaParameter
    {
        /// <summary>
        /// Tipo de mídia. Valores permitidos: tv, rd, impresso, online, inter e msocial
        /// </summary>
        public string Midia { get; set; }

        /// <summary>
        /// Data de início da matéria
        /// </summary>
        public DateTime DataIni { get; set; }

        /// <summary>
        /// Data de fim da matéria
        /// </summary>
        public DateTime DataFim { get; set; }

        /// <summary>
        /// Palavra a ser encontrada no conteúdo da matéria
        /// </summary>
        public string PesquisaTexto { get; set; }
    }
}