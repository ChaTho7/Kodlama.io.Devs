using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationByIdentityBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredByIdentityRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationByIdentityBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
                                        RequestHandlerDelegate<TResponse> next)
    {
        string? identityClaim = _httpContextAccessor.HttpContext.User.GetUserId();
        if (identityClaim == null) throw new AuthorizationException("Identity not found.");
        List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
        if (roleClaims.Count == 0) throw new AuthorizationException("Claims not found.");

        bool isNotMatchedARoleClaimWithRequestRoles =
            roleClaims.FirstOrDefault(roleClaim => request.SuperRoles.Any(superRole => superRole == roleClaim)).IsNullOrEmpty();
        bool isMatchedIdentityClaimWithRequestIdentities = request.Identities.Any(identity => identity == identityClaim);

        if (!isMatchedIdentityClaimWithRequestIdentities)
        {
            if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");
        }

        TResponse response = await next();
        return response;
    }
}