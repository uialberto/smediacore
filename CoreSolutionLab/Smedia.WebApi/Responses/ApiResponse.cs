using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smedia.WebApi.Responses
{
    public class ApiResponse<TData>
    {
        public ApiResponse(TData data)
        {
            Data = data;
        }
        public TData  Data { get; set; }
    }
}
