using Application.Services.Repositories;
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
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public LoginCommandHandler(AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper,
                IUserOperationClaimRepository userOperationClaimRepository)
            {
                _authBusinessRules = authBusinessRules;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user = await _authBusinessRules.UserShouldExistWhenLogin(request.UserForLoginDto.Email);
                await _authBusinessRules.PasswordCheckWhenLogin(request.UserForLoginDto.Password, user.PasswordHash,
                    user.PasswordSalt);

                var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                    predicate: o => o.UserId == user.Id,
                    include: m => m.Include(c => c.OperationClaim)
                    );
                var operationClaims = userOperationClaims.Items.Select(u => u.OperationClaim).ToList();
                var accessToken = _tokenHelper.CreateToken(user, operationClaims);

                return accessToken;
            }
        }
    }
}
