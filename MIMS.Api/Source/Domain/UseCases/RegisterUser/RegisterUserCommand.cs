using MediatR;
using MIMS.Api.Source.Domain.Entiities;
using MIMS.Api.Source.Infrastructure.Data;

namespace MIMS.Api.Source.Domain.UseCases.RegisterUser
{
    public class RegisterUserCommand : IRequest<Unit>
    {
        public RegisterUserRequest Request { get; set; }

        public RegisterUserCommand(RegisterUserRequest request) => this.Request = request;

        public class RequestHandler : IRequestHandler<RegisterUserCommand, Unit>
        {
            private readonly DataContext context;

            public RequestHandler(DataContext context) => this.context = context;

            public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Username = request.Request.Username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Request.Password)
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
