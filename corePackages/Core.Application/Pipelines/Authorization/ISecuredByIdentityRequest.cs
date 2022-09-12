namespace Core.Application.Pipelines.Authorization;

public interface ISecuredByIdentityRequest
{
    /// <summary>
    /// An identity of to be accessed entity's owner which attached to JWT name identifier.
    /// </summary>
    public int Identity { get; set; }
    /// <summary>
    /// The roles that can have access to override the Identity property.
    /// </summary>
    public string[] SuperRoles { get; }
}