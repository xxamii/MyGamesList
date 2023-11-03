using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class ResponseObject<T>
    {
        public T ReturnObject { get; }
        public StatusCodes Status { get; }
        public List<string> Messages { get; }

        public ResponseObject(T returnObject, StatusCodes status, List<string> messages)
        {
            ReturnObject = returnObject;
            Status = status;
            Messages = messages;
        }
    }
}
