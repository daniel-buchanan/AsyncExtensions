using FluentAssertions;
using Xunit;

namespace Common.AsyncExtensions.Tests;

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
    public async Task NullArrayToListSucceeds()
    {
        // Arrange
        async Task<string[]?> Method()
        {
            await Task.Delay(10);
            return null;
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
    public async Task NullEnumerableToListSucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>?> Method()
        {
            await Task.Delay(10);
            return null;
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
    public async Task NullEnumerableToArraySucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>?> Method()
        {
            await Task.Delay(10);
            return null;
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
        async Task<List<string>> Method()
        {
            await Task.Delay(10);
            return new List<string>() { "a", "b", "c" };
        }

        // Act
        var result = await Method().ToArrayAsync();

        // Assert
        result.Should().BeAssignableTo<string[]>();
    }
    
    [Fact]
    public async Task NullListToArraySucceeds()
    {
        // Arrange
        async Task<List<string>?> Method()
        {
            await Task.Delay(10);
            return null;
        }

        // Act
        var result = await Method().ToArrayAsync();

        // Assert
        result.Should().BeAssignableTo<string[]>();
    }
    
    [Fact]
    public async Task EnumerableToEnumerableSucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>> Method()
        {
            await Task.Delay(10);
            return Enumerable.Repeat("a", 4);
        }

        // Act
        var result = await Method().ToEnumerableAsync();

        // Assert
        result.Should().BeAssignableTo<IEnumerable<string>>();
    }
    
    [Fact]
    public async Task ArrayToEnumerableSucceeds()
    {
        // Arrange
        async Task<string[]> Method()
        {
            await Task.Delay(10);
            return ["a", "b", "c"];
        }

        // Act
        var result = await Method().ToEnumerableAsync();

        // Assert
        result.Should().BeAssignableTo<IEnumerable<string>>();
    }
    
    [Fact]
    public async Task ListToEnumerableSucceeds()
    {
        // Arrange
        async Task<IEnumerable<string>> Method()
        {
            await Task.Delay(10);
            return Enumerable.Repeat("a", 4);
        }

        // Act
        var result = await Method().ToEnumerableAsync();

        // Assert
        result.Should().BeAssignableTo<IEnumerable<string>>();
    }
    
    [Fact]
    // ReSharper disable once InconsistentNaming
    public async Task IListToEnumerableSucceeds()
    {
        // Arrange
        async Task<IList<string>> Method()
        {
            await Task.Delay(10);
            return new List<string> { "a", "b", "c" };
        }

        // Act
        var result = await Method().ToEnumerableAsync();

        // Assert
        result.Should().BeAssignableTo<IEnumerable<string>>();
    }
}