using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class GithubProfileRepository : EfRepositoryBase<GithubProfile, BaseDbContext>, IGithubProfileRepository
    {
        public GithubProfileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
