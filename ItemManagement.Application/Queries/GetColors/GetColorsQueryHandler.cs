using AutoMapper;
using ItemManagement.Application.DataTransferObjects;
using ItemManagement.Application.Interfaces.Repositories;
using ItemManagement.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Queries.GetColors
{
    public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, List<ColorDto>>
    {
        private readonly IDictionaryRepository<Color> _repository;
        private readonly IMapper _mapper;

        public GetColorsQueryHandler(
            IDictionaryRepository<Color> repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ColorDto>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.GetAll(request.Date);

            return _mapper.Map<List<ColorDto>>(items);
        }
    }
}
