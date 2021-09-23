using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel.Common.Resources
{
    public abstract class BaseValidateEntity
    {
        public virtual Boolean TryValidateObject(ref String paramErros, String paramStringSeparator = ";")
        {
            var ctx = new ValidationContext(this, null, null);
            List<ValidationResult> result = new List<ValidationResult>();
            if (Validator.TryValidateObject(this, ctx, result, true))
                return true;
            else
            {
                if (paramErros == null)
                    paramErros = "";
                paramErros += String.Join(paramStringSeparator, result);
                return false;
            }
        }

    }
}
