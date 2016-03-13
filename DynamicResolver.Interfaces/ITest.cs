namespace DynamicResolver.Interfaces
{
    public interface ITest
    {
        int MyProperty { get; set; }

        IExample Test();
    }
}