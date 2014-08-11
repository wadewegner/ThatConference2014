using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salesforce.Force
{
    public class ErrorResponses : List<ErrorResponse> { }

    public class ErrorResponse
    {
        public string message;
        public string errorCode;
    }
                
}
