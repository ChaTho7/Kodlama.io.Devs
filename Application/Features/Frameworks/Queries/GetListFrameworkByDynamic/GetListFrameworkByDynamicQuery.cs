using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Frameworks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Frameworks.Queries.GetListFrameworkByDynamic
{
    public class GetListFrameworkByDynamicQuery : IRequest<FrameworkListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListFrameworkByDynamicQuery, FrameworkListModel>
        {

            private readonly IMapper _mapper;
            private readonly IFrameworkRepository _frameworkRepository;

            public GetListModelByDynamicQueryHandler(IMapper mapper, IFrameworkRepository frameworkRepository)
            {
                _mapper = mapper;
                _frameworkRepository = frameworkRepository;
            }

            public async Task<FrameworkListModel> Handle(GetListFrameworkByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<Framework> frameworks = await _frameworkRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: m => m.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                FrameworkListModel mappedFrameworks = _mapper.Map<FrameworkListModel>(frameworks);
                return mappedFrameworks;
            }
        }
    }
}
