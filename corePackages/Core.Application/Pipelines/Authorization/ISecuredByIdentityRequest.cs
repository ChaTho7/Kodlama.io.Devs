namespace Core.Application.Pipelines.Authorization;

public interface ISecuredByIdentityRequest
{
    public string[] Identities { get; set; }
    public string[] SuperRoles { get; }
}