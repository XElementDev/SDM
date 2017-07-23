// TODO: Refactor to stand-alone project/solution.
namespace XElement.DesignPatterns.CreationalPatterns.FactoryMethod
{
    public interface IFactory<TOut>
    {
        TOut Get();
    }
}
