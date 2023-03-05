using AutoMapper;
using ItemManagement.Application.DataTransferObjects;
using ItemManagement.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Queries.GetItems
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<ItemDto>>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(
            IItemRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAll();

            return _mapper.Map<List<ItemDto>>(items);
        }
    }
}
