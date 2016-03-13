namespace DynamicResolver.Interfaces
{
    public interface IRoot
    {
        T Resolve<T>();
    }
}