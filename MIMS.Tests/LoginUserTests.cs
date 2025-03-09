using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Domain.UseCases.LoginUser;
using MIMS.Api.Source.Infrastructure.Data;
using MIMS.Api.Source.Infrastructure.Helpers;
using static MIMS.Api.Source.Domain.UseCases.LoginUser.LoginUserCommand;

namespace MIMS.Tests
{
    public class LoginUserTests
    {
        private readonly DataContext context;
        private readonly IJwtService jwtService;
        private readonly LoginUserCommandHandler handler;

        public LoginUserTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "MIMSDatabase")
                .Options;

            context = new DataContext(options);
            jwtService = new JwtService(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
            handler = new LoginUserCommandHandler(context, jwtService);
        }

        [Fact]
        public async Task ReturnsToken()
        {
            // Arrange
            var user = new User
            {
                Username = "username01.test",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123.test")
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var command = new LoginUserCommand(new LoginUserRequest
            {
                Username = "username01.test",
                Password = "password123.test"
            });

            // Act
            var token = await handler.Handle(command, CancellationToken.None);

            // Assert
            token.Should().NotBeNull();
        }
    }
}
