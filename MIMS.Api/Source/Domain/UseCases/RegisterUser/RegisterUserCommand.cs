using MediatR;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Infrastructure.Data;

namespace MIMS.Api.Source.Domain.UseCases.RegisterUser
{
    public class RegisterUserCommand : IRequest<int>
    {
        public RegisterUserRequest Request { get; set; }

        public RegisterUserCommand(RegisterUserRequest request) => Request = request;

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
        {
            private readonly DataContext context;

            public RegisterUserCommandHandler(DataContext context) => this.context = context;

            public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Username = request.Request.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Request.Password)
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return user.Id;
            }
        }
    }
}
