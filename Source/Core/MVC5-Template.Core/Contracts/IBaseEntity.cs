namespace MVC5_Template.Core.Contracts
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
