using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWheel.Service.Infrasturcture.ErrorHandler
{
    public class ErrorHandler : IErrorHandler
    {
        public string GetMessage(ErrorMessagesEnum message)
        {
            switch (message)
            {
                case ErrorMessagesEnum.EntityNull:
                    return "The entity passed is null {0}. Additional information: {1}";

                case ErrorMessagesEnum.ModelValidation:
                    return "The request data is not correct. Additional information: {0}";

               
                default:
                    throw new ArgumentOutOfRangeException(nameof(message), message, null);
            }

        }

        
    }
}
