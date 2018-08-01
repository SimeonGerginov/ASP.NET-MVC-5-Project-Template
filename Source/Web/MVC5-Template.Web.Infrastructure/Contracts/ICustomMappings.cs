using AutoMapper;

namespace MVC5_Template.Web.Infrastructure.Contracts
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
