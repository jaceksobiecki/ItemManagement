using ItemManagement.Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest<bool>
    {
        public ItemDto ItemDto { get; set; }
    }
}
