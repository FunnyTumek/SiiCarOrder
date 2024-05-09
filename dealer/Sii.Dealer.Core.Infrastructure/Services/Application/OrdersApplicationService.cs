using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Logging;
using Sii.CarOrder.Contracts.Dealer;
using Sii.Dealer.Core.Application.DataTransferObjects;
using Sii.Dealer.Core.Application.Services;
using Sii.Dealer.Core.Domain;
using Sii.Dealer.Core.Domain.Entities;
using Sii.Dealer.Core.Domain.Repositories;
using Sii.Dealer.Core.Domain.Services;
using Sii.Dealer.Core.Domain.ValueObjects;
using Sii.Dealer.SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sii.Dealer.Core.Infrastructure.Services.Application
{
    public class OrdersApplicationService : IOrdersApplicationService
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IPriceCalculationService priceCalculationService;
        private readonly ISalesUnitOfWork unitOfWork;
        private readonly IBus bus;
        private readonly IMapper mapper;
        private readonly ILogger<OrdersApplicationService> logger;

        public OrdersApplicationService(IOrdersRepository ordersRepository,
            IPriceCalculationService priceCalculationService, ISalesUnitOfWork unitOfWork, IBus bus, IMapper mapper, ILogger<OrdersApplicationService> logger)
        {
            this.ordersRepository = ordersRepository;
            this.priceCalculationService = priceCalculationService;
            this.unitOfWork = unitOfWork;
            this.bus = bus;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrderDto> Get(int id)
        {
            var order = ordersRepository.Get(id);
            return order != null ? new OrderDto(order) : null;
        }

        public async Task<OrderDto> PlaceOrder(CarConfigurationDto confDto, CustomerOrderDto customerDto)
        {
            var customer = new Customer(customerDto.FirstName, customerDto.LastName, customerDto.Email, customerDto.Phone);

            var carConfiguration = new CarConfiguration()
            {
                BrandCode = confDto.BrandCode,
                ModelCode = confDto.ModelCode,
                EquipmentVersionCode = confDto.EquipmentVersionCode,
                CarClassCode = confDto.ClassCode,
                ColorCode = confDto.ColorCode,
                InteriorCode = confDto.InteriorCode,
                EngineCode = confDto.EngineCode,
                GearboxCode = confDto.GearboxCode,
                AdditionalEquipmentCodes = confDto.AdditionalEquipmentCodes
            };

            var price = await priceCalculationService.CalculatePrice(carConfiguration);
            var order = Order.Create(carConfiguration, price, customer);

            ordersRepository.Add(order);
            unitOfWork.Commit();

            logger.LogInformation("Order created OrderId = {OrderId} ,CustomerEmail = {Email}.", order.Id, order.Customer.Email);
            await bus.Publish(new UpdateClientDataEvent(order.Customer.FirstName, order.Customer.LastName, order.Customer.Email, order.Customer.Phone));

            return new OrderDto(order);
        }

        public async Task ApplyDiscount(int orderId, decimal discount, string comment)
        {
            var order = ordersRepository.Get(orderId);
            order.ApplyDiscount(discount);
            order.AddComment(comment);

            unitOfWork.Commit();
            logger.LogInformation("Discount applied OrderId = {OrderId},  Discount = {Discount}.", order.Id, discount);
        }

        public async Task CancelOrder(int id)
        {
            var order = ordersRepository.Get(id);
            if (order == null)
            {
                logger.LogError("There is no such ID.");
                throw new Exception("There is no such ID.");
            }

            order.CancelOrder();
            unitOfWork.Commit();
        }

        public async Task ConfirmOrder(int id, bool accept, float percentage)
        {
            var order = ordersRepository.Get(id);
            if (order == null)
            {
                logger.LogError("There is no such ID.");
                throw new Exception("There is no such ID.");
            }

            if (accept == false)
            {
                logger.LogError("The agreement must be accepted.");
                throw new Exception("The agreement must be accepted.");
            }

            order.ConfirmOrderAndCreatePaymentsUsingPercentages(percentage);
            unitOfWork.Commit();
            logger.LogInformation("Status has been changed OrderId = {OrderId}, Status  = {Status}.", order.Id, order.Status);
        }

        public async Task ConfirmPayment(int id, int PaymentId)
        {
            var order = ordersRepository.Get(id);
            if (order == null)
            {
                logger.LogError("There is no such ID.");
                throw new Exception("There is no such ID.");
            }

            var payment = order.Payments.FirstOrDefault(x => x.Id == PaymentId);
            if (payment == null)
            {
                logger.LogError("There is no such ID.");
                throw new Exception("There is no such ID.");
            }

            order.ConfirmPayment(payment);
            unitOfWork.Commit();
            logger.LogInformation("Status has been changed OrderId = {OrderId},  Status  = {Status}.", order.Id, order.Status);
        }

        public async Task<IList<PaymentDto>> GetPaymentsByOrder(int id)
        {
            var order = ordersRepository.Get(id);
            if (order == null)
            {
                logger.LogError("There is no such ID.");
                return null;
            }
            var payments = order.Payments.ToList();

            logger.LogInformation("Returned payments for orderId = {PrderId}.", order.Id);
            return payments != null ? mapper.Map<List<PaymentDto>>(payments) : null;
        }

        public async Task <IList<PaymentDto>> CalculatePaymentsByOrder(int id, float percentage)
        {
            var order = ordersRepository.Get(id);
            if (order == null)
            {
                logger.LogError("There is no such ID.");
                return null;
            }

            var payments = order.CalculatePayments(percentage);
            logger.LogInformation("Returned calculate payments for orderId = {OrderId}.", order.Id);
            return payments != null ? mapper.Map<List<PaymentDto>>(payments) : null;
        }

        public async Task SetPlannedDeliveryDate(int id, int factoryId, DateTime? dateTime)
        {
            var order = ordersRepository.Get(id);
            order.SetPlannedDeliveryDate(factoryId, dateTime);

            logger.LogInformation("Planned delivery date has been set DataTime = {DataTime},  FacotryId = {FactoryId}.", dateTime, factoryId);
            unitOfWork.Commit();
        }

        public async Task SetStatusProduction(int id)
        {
            var order = ordersRepository.Get(id);
            order.SetStatusProduction(order);

            logger.LogInformation("Status has been changed OrderId = {OrderId}, Status  = {Status}.", order.Id, order.Status);
            unitOfWork.Commit();
        }

        public async Task<FactoryDto> GetCarConfiguration(int id)
        {
            var order = ordersRepository.Get(id);

            return order != null ? new FactoryDto() 
            { 
                BrandCode = order.Configuration.BrandCode,
                ModelCode = order.Configuration.ModelCode,
                EquipmentVersionCode = order.Configuration.EquipmentVersionCode,
                ClassCode = order.Configuration.CarClassCode,
                EngineCode = order.Configuration.EngineCode,
                GearboxCode = order.Configuration.GearboxCode,
                ColorCode = order.Configuration.ColorCode,
                InteriorCode = order.Configuration.InteriorCode,
                AdditionalEquipmentCodes = order.Configuration.AdditionalEquipmentCodes 
            } : null;
        }

        public Task SetStatusToProductionAfterResponse(int id)
        {
            var order = ordersRepository.Get(id);
            order.UpdateOrderStatus(OrderStatus.Produced);
            unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task SetStatusToProducted(int id, Guid carVin, DateTime productionStartDate, DateTime plannedDeliveryDate)
        {
            var order = ordersRepository.Get(id);
            order.SetVinDuringTheStartOfProduction(carVin, productionStartDate, plannedDeliveryDate);
            unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public Task SetStatusToCollected(int orderId)
        {
            var order = ordersRepository.Get(orderId);
            order.UpdateOrderStatus(OrderStatus.Collected);
            unitOfWork.Commit();
            return Task.CompletedTask;
        }
        
        public Task SetStatusToDelivered(int orderId)
        {
            var order = ordersRepository.Get(orderId);
            order.UpdateOrderStatus(OrderStatus.Delivered);
            unitOfWork.Commit();
            return Task.CompletedTask;
        }
    }
}
