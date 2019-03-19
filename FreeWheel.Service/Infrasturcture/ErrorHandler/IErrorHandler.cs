using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWheel.Service.Infrasturcture.ErrorHandler
{
    public interface IErrorHandler
    {
        string GetMessage(ErrorMessagesEnum message);
    }


    public enum ErrorMessagesEnum
    {
        EntityNull = 1,
        ModelValidation = 2,
    }
}
