namespace MVC5_Template.Core.Contracts
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
