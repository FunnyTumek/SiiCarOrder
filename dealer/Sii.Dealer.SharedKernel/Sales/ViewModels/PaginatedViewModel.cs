using System.Collections.Generic;

namespace Sii.Dealer.SharedKernel.Sales.ViewModels
{
    public class PaginatedViewModel<T>
    {
        public IList<T> Data { get; set; } = new List<T>();

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
        
    }
}
