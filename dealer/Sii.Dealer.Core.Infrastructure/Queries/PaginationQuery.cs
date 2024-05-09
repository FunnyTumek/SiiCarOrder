namespace Sii.Dealer.Core.Application.Queries
{
    public class PaginationQuery
    {
        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber=pageNumber;
            PageSize=pageSize > 50 ? 50 : pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
