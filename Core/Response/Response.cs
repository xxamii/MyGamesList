using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class Response
    {
        public StatusCodes Status { get; }
        public List<string> Messages { get; }

        public Response(StatusCodes status, List<string> messages)
        {
            Status = status;
            Messages = messages;
        }
    }
}
