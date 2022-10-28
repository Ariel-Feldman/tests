
namespace Ariel.Systems
{
    public interface IPool<T>
    {
        public T PullFromPool();
        public void PushToPool(T t);
    }
}
