namespace MVC5_Template.Services.Contracts
{
    public interface IMappingService
    {
        TMapTo Map<TMapTo>(object from);
    }
}
