using System.Collections.Generic;

namespace Sii.Dealer.Core.Application.Responces
{
    public class PagedResponse<T>
    {
        public PagedResponse(){}

        public PagedResponse(IEnumerable<T> data) 
        {
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

    } 
}
