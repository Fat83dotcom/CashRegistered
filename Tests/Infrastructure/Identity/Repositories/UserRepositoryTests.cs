using Domain.Identity.Entities;
using Domain.Identity.Enums;
using Infrastructure.Identity.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Shared.Identity.Request;
using FluentAssertions;

namespace Tests.Infrastructure.Identity.Repositories;

public class UserRepositoryTests
{
    private CashRegisterDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<CashRegisterDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new CashRegisterDbContext(options);
    }

    [Fact]
    [Trait("Category", "User Repository - Search")]
    public async Task SearchAsync_FilterByName_ShouldReturnFilteredUsers()
    {
        // Arrange
        using var context = GetDbContext();
        var person1 = new Person(PersonType.Physical, "Alice", "Wonderland", "111", DateTime.Now, "alice@test.com");
        var person2 = new Person(PersonType.Physical, "Bob", "Builder", "222", DateTime.Now, "bob@test.com");
        
        var user1 = new User(1, "Pass123456789", "alice.user", UserRole.Admin);
        var user2 = new User(2, "Pass123456789", "bob.user", UserRole.Logistics);
        
        // Reflection to set Person because it's navigation and we are in memory
        typeof(User).GetProperty("Person")?.SetValue(user1, person1);
        typeof(User).GetProperty("Person")?.SetValue(user2, person2);

        await context.People.AddRangeAsync(person1, person2);
        await context.Users.AddRangeAsync(user1, user2);
        await context.SaveChangesAsync();

        var repository = new UserRepository(context);
        var request = new SearchUserRequest { Name = "Alice" };

        // Act
        var result = await repository.SearchAsync(request);

        // Assert
        result.Items.Should().HaveCount(1);
        result.Items.First().UserName.Should().Be("alice.user");
    }

    [Fact]
    [Trait("Category", "User Repository - Search")]
    public async Task SearchAsync_FilterByTaxId_ShouldReturnFilteredUsers()
    {
        // Arrange
        using var context = GetDbContext();
        var person = new Person(PersonType.Physical, "Alice", "Wonderland", "12345678901", DateTime.Now, "alice@test.com");
        var user = new User(1, "Pass123456789", "alice.user", UserRole.Admin);
        typeof(User).GetProperty("Person")?.SetValue(user, person);

        await context.People.AddAsync(person);
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        var repository = new UserRepository(context);
        var request = new SearchUserRequest { TaxId = "12345678901" };

        // Act
        var result = await repository.SearchAsync(request);

        // Assert
        result.Items.Should().HaveCount(1);
    }
}
