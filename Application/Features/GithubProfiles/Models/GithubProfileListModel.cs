using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.GithubProfiles.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.GithubProfiles.Models
{
    public class GithubProfileListModel : BasePageableModel
    {
        public IList<GithubProfileListDto> Items { get; set; }
    }
}
