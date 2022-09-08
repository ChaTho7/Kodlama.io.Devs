using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IFrameworkRepository : IAsyncRepository<Framework>, IRepository<Framework>
{

}