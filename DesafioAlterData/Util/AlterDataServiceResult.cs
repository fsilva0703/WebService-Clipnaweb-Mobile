using AlterDataVotador.Domain.ViewModel.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioAlterData.Util
{
    public class ResultError
    {
        public String Message;
    }

    public class ResultErrorCode : ResultError
    {
        public Int32? Code;
    }

    public static class AlterDataServiceResult<T>
    {
        /// <summary>
        /// Creates a new <see cref="T:Microsoft.AspNetCore.Mvc.JsonResult" /> with the given <paramref name="value" />.
        /// </summary>
        /// <param name="value">The value to format as JSON.</param> 
        /// <inheritdoc />
        public static ObjectResult ExecuteResult(ServiceResult<T> value, int? statusCode = null)
        {
            ObjectResult obj;

            if (value.IsValid)
                obj = new OkObjectResult(value.Data);
            else
            {
                if (value.ErrorCode.HasValue)
                    obj = new ObjectResult(new ResultErrorCode() { Message = value.MessageError, Code = value.ErrorCode });
                else
                    obj = new ObjectResult(new ResultError() { Message = value.MessageError });

                obj.StatusCode = statusCode ?? value.StatusCode;
            }
            return obj;
        }
    }
}
