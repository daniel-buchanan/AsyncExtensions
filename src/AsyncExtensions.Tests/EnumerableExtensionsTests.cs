using FluentAssertions;
using Xunit;

namespace AsyncExtensions.Tests;

public class EnumerableExtensionsTests
{
    [Fact]
    public async Task ArrayToListSucceeds()
    {
        // Arrange
        async Task<string[]> Method()
        {
            await Task.Delay(10);
            return ["a", "b", "c"];
        }

        // Act
        var result = await Method().ToListAsync();

        // Assert
        result.Should().BeAssignableTo<List<string>>();
    }
    
    [Fact]
    public async Task EnumerableToListSucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>> Method()
        {
            await Task.Delay(10);
            return Enumerable.Repeat("a", 4);
        }

        // Act
        var result = await Method().ToListAsync();

        // Assert
        result.Should().BeAssignableTo<List<string>>();
    }
    
    [Fact]
    public async Task EnumerableToArraySucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>> Method()
        {
            await Task.Delay(10);
            return Enumerable.Repeat("a", 4);
        }

        // Act
        var result = await Method().ToArrayAsync();

        // Assert
        result.Should().BeAssignableTo<string[]>();
    }
    
    [Fact]
    public async Task ListToArraySucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>> Method()
        {
            await Task.Delay(10);
            return new List<string>() { "a", "b", "c" };
        }

        // Act
        var result = await Method().ToArrayAsync();

        // Assert
        result.Should().BeAssignableTo<string[]>();
    }
}