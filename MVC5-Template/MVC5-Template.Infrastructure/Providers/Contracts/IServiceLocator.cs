namespace MVC5_Template.Infrastructure.Providers.Contracts
{
    public interface IServiceLocator
    {
        T ProvideInstance<T>();
    }
}
