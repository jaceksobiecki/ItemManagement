using ItemManagement.Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Application.Commands.AddItem
{
    public class AddItemCommand : IRequest
    {
        public ItemDto ItemDto { get; set; }
    }
}
