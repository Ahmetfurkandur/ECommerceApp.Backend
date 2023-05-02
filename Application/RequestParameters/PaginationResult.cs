using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestParameters
{
    public record PaginationResult
    {
        public object Data { get; set; }
        public int TotalCount { get; set; }
    }
}
