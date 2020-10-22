using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uibasoft.Smedia.Core.CustomEntities;

namespace Smedia.WebApi.Responses
{
    public class ApiResponse<TData>
    {
        public ApiResponse(TData data)
        {
            Data = data;
        }
        public TData  Data { get; set; }

        public MetaData MetaData { get; set; }
    }
}
