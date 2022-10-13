using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Rules;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Application.Services.AuthService;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IAuthService _authService;

            public LoginCommandHandler(AuthBusinessRules authBusinessRules, IAuthService authService)
            {
                _authBusinessRules = authBusinessRules;
                _authService = authService;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user = await _authBusinessRules.UserShouldExistWhenLogin(request.UserForLoginDto.Email);
                await _authBusinessRules.PasswordCheckWhenLogin(request.UserForLoginDto.Password, user.PasswordHash,
                    user.PasswordSalt);

                AccessToken accessToken = await _authService.CreateAccessToken(user);

                return accessToken;
            }
        }
    }
}
