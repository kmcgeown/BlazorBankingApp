using Application.Services;
using FluentAssertions;

namespace UnitTests.Application;

public class InterestCalculatorTests
{
    private readonly LoanService _sut;

    public InterestCalculatorTests()
    {
        _sut = new LoanService();
    }

    [Theory]
    [InlineData(20, 1, 20)]
    [InlineData(30, 3, 15)]
    [InlineData(50, 5, 10)]
    [InlineData(60, 1, 12)]
    [InlineData(75, 3, 8)]
    [InlineData(100, 5, 5)]
    public void ApplyForLoan_ValidInputs_ReturnsExpectedInterest(
        int creditRating,
        int duration,
        decimal expectedInterestRate
    )
    {
        // Arrange
        decimal amount = 10000m;

        // Act
        var result = _sut.ApplyForLoan(creditRating, amount, duration);

        // Assert
        result.IsApproved.Should().BeTrue();
        result.InterestRate.Should().Be(expectedInterestRate / 100);
        result.Message.Should().Contain("approved");
    }

    [Theory]
    [InlineData(10, 3)]
    [InlineData(110, 5)]
    [InlineData(45, 2)]
    [InlineData(85, 4)]
    public void ApplyForLoan_InvalidInputs_ReturnsNotApproved(int creditRating, int duration)
    {
        // Arrange
        decimal amount = 10000m;

        // Act
        var result = _sut.ApplyForLoan(creditRating, amount, duration);

        // Assert
        result.IsApproved.Should().BeFalse();
        result.InterestRate.Should().BeNull();
    }
}
