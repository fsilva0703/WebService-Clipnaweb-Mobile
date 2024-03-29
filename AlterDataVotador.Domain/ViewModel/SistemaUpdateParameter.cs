﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel
{
    public class SistemaUpdateParameter
    {

        /// <summary>
        /// ID do Sistema
        /// </summary>
        [Required(ErrorMessage = "O ID do do sistema é obrigatório.", AllowEmptyStrings = false)]
        public Int32 IdSistema { get; set; }

        /// <summary>
        /// Nome do Sistema
        /// </summary>
        [Required(ErrorMessage = "O nome do sistema é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public String NomeSistema { get; set; }

        /// <summary>
        /// URL de Produção
        /// </summary>
        [Required(ErrorMessage = "A URL do sistema é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public String Url { get; set; }

        /// <summary>
        /// Nome da Plataforma de Desenvolvimento
        /// </summary>
        [Required(ErrorMessage = "O nome da plataforma do sistema é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1)]
        public String NomePlataformnaDesenv { get; set; }
    }
}
