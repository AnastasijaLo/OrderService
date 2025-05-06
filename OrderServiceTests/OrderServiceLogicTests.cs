using Moq;
using Microsoft.EntityFrameworkCore;
using OrderService.DTOs;
using OrderService.Services;
using OrderService.Data;
using OrderService.Models;
using FluentAssertions;

public class OrderServiceLogicTests
{
    private readonly OrderServiceLogic _service;
    private readonly Mock<IPaymentGatewayLogic> _mockGateway;
    private readonly Mock<IAppDbContext> _mockContext;
    private readonly Mock<DbSet<Order>> _mockOrderSet;
    private readonly Mock<DbSet<Receipt>> _mockReceiptSet;

    public OrderServiceLogicTests()
    {
        _mockOrderSet = new Mock<DbSet<Order>>();
        _mockReceiptSet = new Mock<DbSet<Receipt>>();
        _mockGateway = new Mock<IPaymentGatewayLogic>();
        _mockContext = new Mock<IAppDbContext>();
        _mockContext.Setup(x => x.Orders).Returns(_mockOrderSet.Object);
        _mockContext.Setup(x => x.Receipts).Returns(_mockReceiptSet.Object);
        _service = new OrderServiceLogic(_mockContext.Object, _mockGateway.Object);
    }

    [Fact]
    public async Task ProcessOrderAsync_PaymentIsSuccessful_CreatesReceipt()
    {
        // Arrange
        var orderId = 1000;
        var orderDto = new OrderDto { Id = orderId, OrderNumber = 1, PayableAmount = 20, };
        var receipt = new ReceiptDto { Id = 1000, IsSuccessful = true, OrderDate = DateTime.Now, };
        _mockGateway.Setup(p => p.IsPaymentProcessedAsync(It.IsAny<Order>())).ReturnsAsync(true);

        // Act
        var result = await _service.ProcessOrderAsync(orderDto);

        // Assert
        result.Should().NotBeNull();
        result.IsSuccessful.Should().BeTrue();
        result.Id.Should().Be(orderDto.Id);
    }

    [Fact]
    public async Task GetReceiptById_OrderExists_ReturnsOrder()
    {
        // Arrange
        long orderId = 1000;
        var order = new Order { Id = 1000, UserId = 2, OrderNumber = 33, PayableAmount = 100, };
        _mockOrderSet.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync(order);
        _mockContext.Setup(c => c.Orders).Returns(_mockOrderSet.Object);

        // Act
        var result = await _service.GetOrderById(orderId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(orderId);
    }

    [Fact]
    public async Task GetReceiptById_OrderNotFound_ReturnsNull()
    {
        // Act
        var result = await _service.GetOrderById(1);

        // Assert
        result.Should().BeNull();
    }
}