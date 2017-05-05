// TODO: Merge with RYB project.
namespace XElement.DesignPatterns.CreationalPatterns.FactoryMethod
{
    public interface IFactory<TOut, TIn>
    {
        TOut Get( TIn parameter );
    }
}
