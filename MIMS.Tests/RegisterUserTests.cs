using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MIMS.Api.Source.Domain.UseCases.RegisterUser;
using MIMS.Api.Source.Infrastructure.Data;
using static MIMS.Api.Source.Domain.UseCases.RegisterUser.RegisterUserCommand;

namespace MIMS.Tests
{
    public class RegisterUserTests
    {
        private readonly DataContext context;
        private readonly RegisterUserCommandHandler handler;

        public RegisterUserTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "MIMSDatabase")
                .Options;

            context = new DataContext(options);
            handler = new RegisterUserCommandHandler(context);
        }

        [Fact]
        public async Task ReturnsUser()
        {
            // Arrange
            var command = new RegisterUserCommand(new RegisterUserRequest
            {
                Username = "username.test",
                Password = "password123.test"
            });

            // Act
            var userId = await handler.Handle(command, CancellationToken.None);

            // Assert
            userId.Should().BeGreaterThan(0);
            var user = await context.Users.FindAsync(userId);
            user.Should().NotBeNull();
        }
    }
}
