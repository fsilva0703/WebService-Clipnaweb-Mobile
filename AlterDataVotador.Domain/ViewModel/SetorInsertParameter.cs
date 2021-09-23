using AlterDataVotador.Domain.ViewModel.Common;
using AlterDataVotador.Domain.ViewModel.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlterDataVotador.Domain.ViewModel
{
    public class SetorInsertParameter : BaseValidateEntity
    {
        /// <summary>
        /// Nome do setor.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(DataAnnotationsMessages), ErrorMessageResourceName = "NomeSetor_Required", AllowEmptyStrings = false)]
        [StringLength(30, MinimumLength = 1, ErrorMessageResourceType = typeof(DataAnnotationsMessages), ErrorMessageResourceName = "NomeSetor_Length")]
        public String NomeSetor { get; set; }

        /// <summary>
        /// Nome do gerente do setor.
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(DataAnnotationsMessages), ErrorMessageResourceName = "NomeGerenteSetor_Required", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 1, ErrorMessageResourceType = typeof(DataAnnotationsMessages), ErrorMessageResourceName = "NomeGerenteSetor_Length")]
        public String NomeGerenteSetor { get; set; }

    }
}
