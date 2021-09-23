using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class MateriaResult
    {
        /// <summary>
        /// Código identificador da matéria
        /// </summary>
        public int MatId { get; set; }

        /// <summary>
        /// Título da matéria
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// SubTitulo da matéria
        /// </summary>
        public string Subtitulo { get; set; }

        /// <summary>
        /// Texto da matéria
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Tipo de mídia
        /// </summary>
        public string Midia { get; set; }

        /// <summary>
        /// Data da matéria
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Veículo/Emissora que noticiou a matéria
        /// </summary>
        public string Veiculo { get; set; }

        /// <summary>
        /// Programa que noticiou a matéria
        /// </summary>
        public string Programa { get; set; }

        /// <summary>
        /// URL da matéria
        /// </summary>
        public string UrlMateria { get; set; }

        /// <summary>
        /// URL do arquivo da matéria
        /// </summary>
        public string UrlFile { get; set; }

        /// <summary>
        /// Valoração da matéria
        /// </summary>
        public string Valoracao { get; set; }

        /// <summary>
        /// Alcance da matéria
        /// </summary>
        public string Alcance { get; set; }

        /// <summary>
        /// Avaliação da matéria
        /// </summary>
        public string Avaliacao { get; set; }
    }
}