using AutoMapper;
using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Commands.AddItem
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
    {
        private readonly IItemRepository _repository;
        private readonly IMapper _mapper;

        public AddItemCommandHandler(
            IItemRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request);
            await _repository.Add(item);
            return Unit.Value;
        }
    }
}
