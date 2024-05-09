using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using Sii.Dealer.DependencyInjection;
using Sii.Dealer.SharedKernel.Sales.ViewModels;

namespace Sii.Dealer.ConsoleApp
{
    class Program
    {
		static void Main(string[] args)
		{
			try
			{
				var builder = new ContainerBuilder();
				builder.RegisterModule<DealerDependencyModule>();
				var container = builder.Build();

				DealerStartup.EnsureDatabaseStructure(container.BeginLifetimeScope());

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			finally
			{
				Console.WriteLine($"{Environment.NewLine}Press <Enter> to exit");
				Console.ReadKey();
			}

			//this classes are not visible because they are in domain project which is not referenced (directly) by ConsoleApp (and shouldn't be)
			//CarConfiguration c = null;
			//Offer o = new Offer(c, 10000);
		}

		private static void DisplayOrders(IList<OrderListViewModel> orders)
        {
            var line = string.Join(string.Empty, Enumerable.Repeat("-", Console.WindowWidth));
            Console.WriteLine($"{line}Orders: {orders.Count}");

            foreach (var o in orders)
            {
                var m = $"[Id: {o.Id}, Customer: {o.CustomerFirstName} {o.CustomerLastName}, Date: {o.CreationDate:HH:mm:ss.fff}, Status: {o.Status}, Price: {o.Price:0.00}.";
                Console.WriteLine(m);
            }

            Console.WriteLine($"{line}");
        }

        private static T GetRandomElement<T>(Random random, IList<T> list)
        {
            var index = random.Next(list.Count);
            return list[index];
        }

        private async static Task RunTest(IContainer container)
        {
            #region Placing order

            OrderDto order;

            using (var scope = container.BeginLifetimeScope())
            {
                var customerDto = new CustomerOrderDto
                {
                    Email = "jane.doe@example.email",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Phone = "123456789"
                };
                var carConfiguration = CarConfigurationGenerator.GenerateConfiguration();

                var orderService = scope.Resolve<IOrdersApplicationService>();
                order = await orderService.PlaceOrder(carConfiguration, customerDto);
            }

            #endregion
        }
    }
}
