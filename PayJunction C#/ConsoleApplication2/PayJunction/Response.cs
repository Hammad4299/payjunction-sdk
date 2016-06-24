using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayJunction
{
    abstract class Response
    {
        public List<ResponseError> Errors { get; set; }

        public Response()
        {
            Errors = new List<ResponseError>();
        }
    }
}
