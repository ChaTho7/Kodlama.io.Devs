using Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auth.Rules;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<AccessToken>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMapper _mapper;

            public RegisterCommandHandler(AuthBusinessRules authBusinessRules, ITokenHelper tokenHelper, 
                IUserRepository userRepository, IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _authBusinessRules = authBusinessRules;
                _tokenHelper = tokenHelper;
                _userRepository = userRepository;
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserCanNotBeDuplicatedWhenRegister(request.UserForRegisterDto.Email);

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out passwordHash,out passwordSalt);

                User user = _mapper.Map<User>(request.UserForRegisterDto,
                    opt =>
                    {
                        opt.Items.Add("PasswordHash", passwordHash);
                        opt.Items.Add("PasswordSalt", passwordSalt);

                    });
                _userRepository.Add(user);

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
