using ItemManagement.Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Queries.GetColors
{
    public class GetColorsQuery : IRequest<List<ColorDto>>
    {
        public DateTime? Date { get; set; }
    }
}
