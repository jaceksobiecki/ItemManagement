using ItemManagement.Application.DataTransferObjects;
using ItemManagement.Domain.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace ItemManagement.Infrastructure.Extensions.OData
{
    public static class EdmConfigurer
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EnableLowerCamelCase();
            builder.EntitySet<ItemDto>("Items");
            return builder.GetEdmModel();
        }
    }
}
