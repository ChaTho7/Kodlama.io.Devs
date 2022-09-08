using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FrameworkRepository : EfRepositoryBase<Framework, BaseDbContext>, IFrameworkRepository
{
    public FrameworkRepository(BaseDbContext context) : base(context)
    {
    }
}