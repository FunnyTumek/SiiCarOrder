namespace Sii.Dealer.ReadModel.Models;
    public class OrderDetailReadModel
    {
        public OrderDetailReadModel(OrderDetailCustomerReadModel customer, OrderDetailInfoReadModel order, OrderDetailConfigurationReadModel configuration)
        {
            Configuration = configuration;
            Customer = customer;
            Order = order;
        }

        public OrderDetailConfigurationReadModel Configuration { get; set; }
        public OrderDetailCustomerReadModel Customer { get; set; }
        public OrderDetailInfoReadModel Order { get; set; }
    }

