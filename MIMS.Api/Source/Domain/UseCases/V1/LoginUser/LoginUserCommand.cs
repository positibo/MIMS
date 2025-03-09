using MediatR;
using Microsoft.EntityFrameworkCore;
using MIMS.Api.Source.Domain.BusinessRules;
using MIMS.Api.Source.Infrastructure.Data;
using MIMS.Api.Source.Infrastructure.Helpers;

namespace MIMS.Api.Source.Domain.UseCases.V1.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        public LoginUserRequest Request { get; set; }

        public LoginUserCommand(LoginUserRequest request) => Request = request;

        public class RequestHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
        {
            private readonly DataContext context;
            private readonly IJwtService jwtService;

            public RequestHandler(DataContext context, IJwtService jwtService) 
            {
                this.context = context;
                this.jwtService = jwtService;
            }

            public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await context.Users.SingleOrDefaultAsync(o => o.Username == request.Request.Username);
                if(user == null)
                {
                    throw new UsernamePasswordIncorrectException();
                }

                if (!BCrypt.Net.BCrypt.Verify(request.Request.Password, user.PasswordHash.ToString()))
                {
                    throw new UnauthorizedException();
                }

                var token = jwtService.GenerateToken(user);
                return new LoginUserResponse { Id = user.Id, Username = user.Username, Token = token };

            }
        }
    }
}
