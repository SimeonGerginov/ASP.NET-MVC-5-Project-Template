using AutoMapper;

namespace MVC5_Template.Infrastructure.Contracts
{
    public interface ICustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
