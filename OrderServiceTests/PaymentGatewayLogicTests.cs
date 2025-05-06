using OrderService.Models;
using OrderService.Services;
using FluentAssertions;

public class PaymentGatewayLogicTests
{
    private readonly PaymentGatewayLogic _gateway;

    public PaymentGatewayLogicTests()
    {
        _gateway = new PaymentGatewayLogic();
    }

    [Fact]
    public async Task IsPaymentProcessedAsync_PositivePayableAmount_ReturnsTrue()
    {
        // Arrange
        var order = new Order { Id = 1, PayableAmount = 10 };

        // Act
        var result = await _gateway.IsPaymentProcessedAsync(order);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task IsPaymentProcessedAsync_ZeroAmount_ReturnsFalse()
    {
        // Arrange
        var order = new Order { Id = 1, PayableAmount = 0 };

        // Act
        var result = await _gateway.IsPaymentProcessedAsync(order);

        // Assert
        result.Should().BeFalse();
    }
}
